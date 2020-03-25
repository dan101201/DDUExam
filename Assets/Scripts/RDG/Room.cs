using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject[] doors;
    public bool roomFits
    {
        get;
        private set;
    } = true;

    public void OnTriggerStay(Collider other)
    {
        roomFits = false;
    }
}
