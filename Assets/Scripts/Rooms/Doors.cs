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
        generation = GameObject.FindGameObjectWithTag("GameController").GetComponent<DungeonGenerationScript>();
    }

    private void OnTriggeStay(Collider other)
    {
        
        if (other.CompareTag("Door") && generation.DoneGenerating)
        {
            Destroy(other.gameObject);
            
        }
        
    }
}
