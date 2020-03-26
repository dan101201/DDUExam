using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomreveal : MonoBehaviour
{
    public Roofreveal Roof;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Roof.ChangeRoofState();
        }
    }
}
