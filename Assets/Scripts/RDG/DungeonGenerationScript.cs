using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;
public class DungeonGenerationScript : MonoBehaviour
{
    public GameObject[] RoomPrefabs;
    public GameObject startingRoom;
    public int roomsWanted = 10;
    public int seed = 312312;
    // Start is called before the first frame update

    private void Awake()
    {
<<<<<<< Updated upstream
        Generate();   
=======
        Generate();
>>>>>>> Stashed changes
    }

    public void Generate()
    {
        StartCoroutine("GenerateDungeon");
    }

    private IEnumerator GenerateDungeon()
    {
        Random.InitState(seed);
        List<GameObject> rooms = new List<GameObject>();
        rooms.Add(startingRoom);
        for (int i = 0; i < roomsWanted; )
        {
            int rnd = Random.Range(0,rooms.Count);
            var currentRoom = rooms[rnd].GetComponent<Room>();

            var doorsTried = new List<GameObject>(currentRoom.usedDoors);
            bool done = false;
            while(!done)
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

                var roomsTried = new List<GameObject>();
                bool roomFits = false;
                while(!roomFits)
                {
                    
                    rnd = Random.Range(0, RoomPrefabs.Length - 1);
                    var roomPrefab = RoomPrefabs[rnd];
                    

                    if (roomsTried.Contains(roomPrefab))
                    {
                        if (roomsTried.Count == RoomPrefabs.Length)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    roomsTried.Add(roomPrefab);

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
                                Debug.Log("break");
                                break;
                            } 
                            else
                            {
                                continue;
                            }
                        }
                        newRoomDoorsTried.Add(rnd);

                        var newRoom = Instantiate(roomPrefab, door.transform.position, new Quaternion());

                        Debug.Log("place room");

                        var newRoomScript = newRoom.GetComponent<Room>();
                        var newDoor = newRoomScript.doors[rnd];

                        newDoor.transform.parent = null;
                        newRoom.transform.parent = newRoomScript.doors[rnd].transform;
                        newDoor.transform.position = door.transform.position;

                        float rotationAngle = Vector3.Angle(door.transform.forward, newDoor.transform.forward);
                        newDoor.transform.rotation = Quaternion.Euler(0, (180 - rotationAngle) + newDoor.transform.rotation.eulerAngles.y , 0);


                        //yield return new WaitForSeconds(2f);
                        yield return new WaitForFixedUpdate();

                        roomFits = newRoom.GetComponent<Room>().roomFits;
                        Debug.Log(roomFits);
                        if (roomFits)
                        {
                            currentRoom.usedDoors.Add(door);
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
            }
        }
        yield return null;
    }
}
