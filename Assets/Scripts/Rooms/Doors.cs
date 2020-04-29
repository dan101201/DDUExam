using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject arrow;

    DungeonGenerationScript generation;
    GameObject door;
    Collider temp;

    private void Awake()
    {
        generation = GameObject.FindGameObjectWithTag("GameController").GetComponent<DungeonGenerationScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Door") && generation.DoneGenerating)
        {

            arrow.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
