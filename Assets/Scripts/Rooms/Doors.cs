using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    DungeonGenerationScript generation;
    GameObject door;
    Collider temp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Destroy(other.gameObject);
        }
    }
}
