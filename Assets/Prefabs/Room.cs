using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> doors = new List<GameObject>();
    public List<GameObject> usedDoors = new List<GameObject>();
    public bool roomFits
    {
        get;
        private set;
    } = true;

    public void OnTriggerEnter(Collider other)
    {
        roomFits = false;
    }
}
