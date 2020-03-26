using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomreveal : MonoBehaviour
{
    public GameObject roof;

    void OnTriggerEnter(Collider col)
    {
        roof.SetActive(false);
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("wow");
        roof.SetActive(true);
    }
}
