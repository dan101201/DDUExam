using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject camara;
    public void SpawnPlayer()
    {
        /*GameObject newPlay = */Instantiate(player, new Vector3(0, 0.6f, 0), transform.rotation);
        /*GameObject newCamara = */Instantiate(camara, new Vector3(0, 7.5f, -1.8f), new Quaternion(72, 0, 0, 0));
    }
}
