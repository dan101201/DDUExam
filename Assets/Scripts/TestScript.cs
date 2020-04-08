using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " got hit");
    }
}
