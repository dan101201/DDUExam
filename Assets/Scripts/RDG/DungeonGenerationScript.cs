using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DungeonGenerationScript : MonoBehaviour
{
    public GameObject[] roomPrefabs;
    public GameObject[] treasureRoomPrefabs;
    public GameObject bossRoom;
    public GameObject startingRoom;
    public GameObject player;
    public GameObject camara;
    public int minRoomsBeforeTreasure = 2;
    public int normalRoomsWanted = 10;
    public int treasureRoomsWanted;
    public int seed = 312312;
    private List<GameObject> rooms = new List<GameObject>();


    [SerializeField]
    public int roomsPlaced
    {
        get
        {
            return treasureRoomsPlaced + normalRoomsPlaced;
        }
    }

    [SerializeField] private int treasureRoomsPlaced;

    [SerializeField] private int normalRoomsPlaced;

    [SerializeField] private GameObject roomSelected;
    // Start is called before the first frame update

    private void Awake()
    {
        startingRoom.GetComponent<PlayerSpawner>().SpawnPlayer();
        Generate();
    }

    public void Generate()
    {
        StartCoroutine("GenerateDungeon");
    }

    private IEnumerator GenerateDungeon()
    {
        Random.InitState(seed);
        rooms.Add(startingRoom);
        for (int i = 0; i < normalRoomsWanted + treasureRoomsWanted;)
        {
            int rnd = Random.Range(0, rooms.Count);
            var currentRoom = rooms[rnd].GetComponent<Room>();
            roomSelected = currentRoom.gameObject;
            Debug.Log("Selected room: " + roomSelected.name);

            var doorsTried = new List<GameObject>(currentRoom.usedDoors);
            bool done = false;
            while (!done)
            {

                rnd = Random.Range(0, currentRoom.doors.Count);
                var door = currentRoom.doors[rnd];
                if (doorsTried.Contains(door))
                {
                    if (doorsTried.Count == currentRoom.doors.Count)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                doorsTried.Add(door);

                var newRoomsTried = new List<GameObject>();
                var treasureRoomsTried = new List<GameObject>();
                bool roomFits = false;
                while (!roomFits)
                {

                    rnd = Random.Range(0, roomPrefabs.Length);
                    bool treasureRoom;
                    var roomPrefab = GetRoomPrefab(out treasureRoom);


                    if (newRoomsTried.Contains(roomPrefab))
                    {
                        if (newRoomsTried.Count + treasureRoomsTried.Count == roomPrefabs.Length + treasureRoomPrefabs.Length)
                        {
                            break;
                        }
                        else if (treasureRoomsTried.Count == treasureRoomPrefabs.Length)
                        {
                            break;
                        }
                        else if (newRoomsTried.Count == roomPrefabs.Length)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (treasureRoom)
                    {
                        treasureRoomsTried.Add(roomPrefab);
                    }
                    else
                    {
                        newRoomsTried.Add(roomPrefab);
                    }


                    List<int> newRoomDoorsTried = new List<int>();
                    bool placedSuccesfullRoom = false;
                    while (!placedSuccesfullRoom)
                    {

                        int doors = roomPrefab.GetComponent<Room>().doors.Count;

                        rnd = Random.Range(0, doors);


                        if (newRoomDoorsTried.Contains(rnd))
                        {
                            if (newRoomDoorsTried.Count == doors)
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        newRoomDoorsTried.Add(rnd);

                        var newRoom = Instantiate(roomPrefab, door.transform.position, new Quaternion());

                        var newRoomScript = newRoom.GetComponent<Room>();
                        var newDoor = newRoomScript.doors[rnd];

                        newDoor.transform.parent = null;
                        newRoom.transform.parent = newRoomScript.doors[rnd].transform;
                        newDoor.transform.position = door.transform.position;

                        float rotationAngle = Vector3.Angle(door.transform.forward, newDoor.transform.forward);
                        newDoor.transform.rotation = Quaternion.Euler(0, (180 - rotationAngle) + newDoor.transform.rotation.eulerAngles.y, 0);


                        //yield return new WaitForSeconds(2f);
                        yield return new WaitForFixedUpdate();

                        roomFits = newRoom.GetComponent<Room>().roomFits;
                        if (roomFits)
                        {
                            if (treasureRoom)
                            {
                                treasureRoomsPlaced++;
                            }
                            else
                            {
                                normalRoomsPlaced++;
                            }
                            newRoomScript.usedDoors.Add(newDoor);
                            rooms.Add(newRoom);
                            placedSuccesfullRoom = true;
                            done = true;
                            i++;

                            newRoom.transform.GetChild(1).GetComponent<RoomPicker>().PopulateRoom();
                        }
                        else
                        {
                            Destroy(newDoor);
                        }

                    }
                }
                currentRoom.usedDoors.Add(door);
            }
            
        }
        {
            bool bossRoomPlaced = false;
            while (!bossRoomPlaced)
            {
                Debug.Log("placing bossroom");
                int rnd = Random.Range(0, rooms.Count);
                var currentRoom = rooms[rnd].GetComponent<Room>();
                roomSelected = currentRoom.gameObject;

                var doorsTried = new List<GameObject>(currentRoom.usedDoors);
                bool done = false;
                while (!done)
                {

                    rnd = Random.Range(0, currentRoom.doors.Count);
                    var door = currentRoom.doors[rnd];
                    if (doorsTried.Contains(door))
                    {
                        if (doorsTried.Count == currentRoom.doors.Count)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    doorsTried.Add(door);

                    var newRoomsTried = new List<GameObject>();
                    var treasureRoomsTried = new List<GameObject>();
                    bool roomFits = false;
                    while (!roomFits)
                    {

                        rnd = Random.Range(0, roomPrefabs.Length);
                        var roomPrefab = bossRoom;


                        if (newRoomsTried.Contains(roomPrefab))
                        {
                            break;
                        }
                        newRoomsTried.Add(roomPrefab);


                        List<int> newRoomDoorsTried = new List<int>();
                        bool placedSuccesfullRoom = false;
                        while (!placedSuccesfullRoom)
                        {

                            int doors = roomPrefab.GetComponent<Room>().doors.Count;

                            rnd = Random.Range(0, doors);


                            if (newRoomDoorsTried.Contains(rnd))
                            {
                                if (newRoomDoorsTried.Count == doors)
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            newRoomDoorsTried.Add(rnd);

                            var newRoom = Instantiate(roomPrefab, door.transform.position, new Quaternion());

                            var newRoomScript = newRoom.GetComponent<Room>();
                            var newDoor = newRoomScript.doors[rnd];

                            newDoor.transform.parent = null;
                            newRoom.transform.parent = newRoomScript.doors[rnd].transform;
                            newDoor.transform.position = door.transform.position;

                            float rotationAngle = Vector3.Angle(door.transform.forward, newDoor.transform.forward);
                            newDoor.transform.rotation = Quaternion.Euler(0, (180 - rotationAngle) + newDoor.transform.rotation.eulerAngles.y, 0);


                            //yield return new WaitForSeconds(2f);
                            yield return new WaitForFixedUpdate();

                            roomFits = newRoom.GetComponent<Room>().roomFits;
                            if (roomFits)
                            {
                                Debug.Log("placed boss");
                                newRoomScript.usedDoors.Add(newDoor);
                                rooms.Add(newRoom);
                                bossRoomPlaced = true;
                                placedSuccesfullRoom = true;
                                done = true;
                                newRoom.GetComponent<RoomPicker>().PopulateRoom();
                            }
                            else
                            {
                                Destroy(newDoor);
                            }

                        }
                    }
                    currentRoom.usedDoors.Add(door);
                }
            }
        }
        
        yield return null;
    }

    private void FinishGeneration()
    {

    }

    private GameObject GetRoomPrefab(out bool treasureRoom)
    {
        int rnd = UnityEngine.Random.Range(0, roomPrefabs.Length + treasureRoomPrefabs.Length);
        try
        {
            if (rnd >= roomPrefabs.Length && treasureRoomsWanted > treasureRoomsPlaced && roomsPlaced > minRoomsBeforeTreasure || normalRoomsPlaced == normalRoomsWanted && treasureRoomsPlaced < treasureRoomsWanted)
            {
                treasureRoom = true;
                rnd = Random.Range(0, treasureRoomPrefabs.Length);
                return treasureRoomPrefabs[rnd];
            }
            else
            {
                rnd = Random.Range(0, roomPrefabs.Length);
                treasureRoom = false;
                return roomPrefabs[rnd];
            }
        }
        catch (System.IndexOutOfRangeException)
        {
            throw new System.Exception("prefab array is empty");
        }
    }


}
