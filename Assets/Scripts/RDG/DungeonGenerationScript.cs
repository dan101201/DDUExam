using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerationScript : MonoBehaviour
{
    public GameObject[] RoomPrefabs;
    public GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        var testRoom = Instantiate(RoomPrefabs[0]);
        Debug.Log(room.GetComponent<Room>().doors[1].transform.position);
        Debug.Log(testRoom.GetComponent<Room>().doors[1].transform.localPosition);
        testRoom.transform.position = (room.GetComponent<Room>().doors[1].transform.position + testRoom.GetComponent<Room>().doors[1].transform.position) - new Vector3(0, testRoom.GetComponent<Room>().doors[1].transform.position.y*2, 0);
        //GenerateDungeon(room,10,10);
    }

    public void GenerateDungeon(GameObject startingRoom,int seed, int roomsWanted)
    {
        Random.InitState(seed);
        List<GameObject> rooms = new List<GameObject>();
        rooms.Add(startingRoom);
        for (int i = 0; i < roomsWanted; i++)
        {
            int rnd = Random.Range(0,i);
            var currentRoom = rooms[rnd].GetComponent<Room>();

            var doorsTried = new List<GameObject>();
            bool done = false;
            while(!done)
            {
                rnd = Random.Range(0, currentRoom.doors.Length - 1);
                var door = currentRoom.doors[rnd];
                if (doorsTried.Contains(door))
                {
                    continue;
                }
                doorsTried.Add(door);

                var roomsTried = new List<GameObject>();
                bool roomFits = false;
                while(!roomFits)
                {
                    rnd = Random.Range(0, RoomPrefabs.Length - 1);
                    var newRoom = RoomPrefabs[rnd];
                    if (roomsTried.Contains(door))
                    {
                        continue;
                    }
                    roomsTried.Add(newRoom);

                    var roomObject = Instantiate(newRoom);
                    var roomObjectRoom = roomObject.GetComponent<Room>();
                    var newRoomDoorsTried = new List<GameObject>();
                    bool newRoomDoorFound = false;
                    while (!newRoomDoorFound)
                    {
                        rnd = Random.Range(0, roomObjectRoom.doors.Length - 1);
                        var newRoomDoor = roomObjectRoom.doors[rnd];
                        if (newRoomDoorsTried.Contains(door))
                        {
                            continue;
                        }
                        newRoomDoorsTried.Add(door);

                        roomObject.transform.position = door.transform.position - newRoomDoor.transform.localPosition;
                    }
                }
            }
            
        }
    }

}
