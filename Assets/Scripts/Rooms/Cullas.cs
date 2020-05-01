using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cullas : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
}
