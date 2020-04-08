using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPicker : MonoBehaviour
{
    public GameObject[] roomInside;

    public void PopulateRoom()
    { 
        GameObject pickedInside = roomInside[Random.Range(0, roomInside.Length)];
        Instantiate(pickedInside, transform.position, transform.rotation, transform);
    }         
}
