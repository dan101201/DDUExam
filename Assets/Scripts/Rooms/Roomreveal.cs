using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomreveal : MonoBehaviour
{
    public GameObject roof;

    int colliderCount;
    void OnTriggerEnter(Collider col)
    {
        roof.SetActive(false);
        colliderCount++;
    }
    void OnTriggerExit(Collider col)
    {
        colliderCount--;
        if(colliderCount==0)
        {
            roof.SetActive(true);
        }
    }
}
