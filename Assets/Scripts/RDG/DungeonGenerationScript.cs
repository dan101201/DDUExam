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
        PlaceRoom(room,RoomPrefabs[0],room.GetComponent<Room>().doors[0]);
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

                    if (PlaceRoom(currentRoom.gameObject,door, newRoom))
                    {
                        roomFits = true;
                        done = true;
                    }
                }
            }
            
        }
    }

    private bool PlaceRoom(GameObject startingRoom, GameObject newRoom, GameObject door)
    {
        List<int> doorsTried = new List<int>();
        bool done = false;
        var boxCollider = startingRoom.GetComponent<BoxCollider>();
        var startingRoomScript = startingRoom.GetComponent<Room>();
        //while (!doorFits)
        {

            newRoom = Instantiate(newRoom, startingRoomScript.doors[0].transform.position,new Quaternion());
            var newRoomScript = newRoom.GetComponent<Room>();
            int rnd = Random.Range(0,newRoomScript.doors.Length);
            if (doorsTried.Contains(rnd))
            {
                if (doorsTried.Count == newRoomScript.doors.Length)
                {
                    done = true;
                }
            }
            doorsTried.Add(rnd);

            newRoomScript.doors[rnd].transform.parent = null;
            newRoom.transform.parent = newRoomScript.doors[rnd].transform;
            newRoomScript.doors[rnd].transform.position = door.transform.position;
            
            newRoomScript.doors[rnd].transform.rotation = Quaternion.Euler(0, room.transform.rotation.eulerAngles.y + 180, 0);

            bool roomFits = newRoom.GetComponent<Room>().roomFits;
            Debug.Log(roomFits);
            if (roomFits)
            {   
                return true;
            }
            else
            {
                Destroy(newRoom);
            }
        }
        return false;
    }

}
