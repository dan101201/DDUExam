using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPicker : MonoBehaviour
{
    public GameObject[] roomInside;
    DungeonGenerationScript generation;
    bool hasPicked;
    float waitTime = 0.1f;

    void Update()
    {
        generation = DungeonGenerationScript.dungGeneration;
        if (generation.canSpawnEnemys && !hasPicked)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                GameObject pickedInside = roomInside[Random.Range(0, roomInside.Length)];
                Instantiate(pickedInside, transform.position, transform.rotation);
                Debug.Log(pickedInside);
                hasPicked = true;
            }
        }
    }
}
