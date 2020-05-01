using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cullas : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        GetComponent<BoxCollider>().isTrigger = false;
    }
}
