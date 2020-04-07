using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    DungeonGenerationScript generation;
    GameObject door;
    Collider temp;

    private void Start()
    {
        temp = gameObject.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            door = other.gameObject;
        }
    }
    private void Update()
    {
        generation = DungeonGenerationScript.dungGeneration;
        if (generation.canSpawnEnemys)
        {
            temp.enabled = true;
            Destroy(door);
        }
    }
}
