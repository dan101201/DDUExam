using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFloorTeleporter : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {  
        player.transform.position = new Vector3(0, 0.605f, 0);
    }
}
