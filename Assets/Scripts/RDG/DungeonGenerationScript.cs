using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class DungeonGenerationScript : MonoBehaviour
{
    public GameObject[] roomPrefabs;
    public bool DoneGenerating;
    public GameObject[] treasureRoomPrefabs;
    public GameObject bossRoom;
    public GameObject startingRoom;
    public int minRoomsBeforeTreasure = 2;
    public int normalRoomsWanted = 10;
    public int treasureRoomsWanted = 2;
    public int seed = 0;

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
        DontDestroyOnLoad(gameObject);
        Generate(GameObject.FindGameObjectWithTag("Player") == null);
    }

    public void Generate(bool placePlayerOnGenerate)
    {
        StartCoroutine(GenerateDungeon(placePlayerOnGenerate));
    }

    private IEnumerator GenerateDungeon(bool placePlayerOnGenerate)
    {
        if (seed != 0)
        Random.InitState(seed);
        rooms.Add(startingRoom);
        for (int i = 0; i < normalRoomsWanted + treasureRoomsWanted;)
        {
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
                    bool treasureRoom;
                    var roomPrefab = GetRoomPrefab(out treasureRoom);

                    if (newRoomsTried.Contains(roomPrefab) || treasureRoomsTried.Contains(roomPrefab))
                    {
                        if (newRoomsTried.Count + treasureRoomsTried.Count >= roomPrefabs.Length + treasureRoomPrefabs.Length)
                        {
                            break;
                        }
                        else if (treasureRoomsTried.Count >= treasureRoomPrefabs.Length)
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


                        //yield return new WaitForSeconds(0.5f);
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

                                newRoom.transform.GetChild(1).GetComponent<RoomPicker>().PopulateRoom();
                                normalRoomsPlaced++;
                            }
                            newRoomScript.usedDoors.Add(newDoor);
                            rooms.Add(newRoom);
                            placedSuccesfullRoom = true;
                            done = true;
                            i++;                          
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
                                newRoomScript.usedDoors.Add(newDoor);
                                rooms.Add(newRoom);
                                bossRoomPlaced = true;
                                placedSuccesfullRoom = true;
                                done = true;
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
        }
        yield return new WaitForFixedUpdate();
        DoneGenerating = true;
        if (placePlayerOnGenerate)
        {
            startingRoom.GetComponent<PlayerSpawner>().SpawnPlayer();
        }
        foreach (GameObject room in rooms)
        {
            room.GetComponent<Roomreveal>().LateStart();
        }
        yield return null;
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
