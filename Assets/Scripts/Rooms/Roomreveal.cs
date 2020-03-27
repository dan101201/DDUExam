using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomreveal : MonoBehaviour
{
    public GameObject roof;
    public bool isPlayerInRoom;

    int colliderCount;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInRoom = true;
            roof.SetActive(false);
            colliderCount++;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            colliderCount--;
            if (colliderCount == 0)
            {
                isPlayerInRoom = false;
                roof.SetActive(true);
            }
        }
    }
}
