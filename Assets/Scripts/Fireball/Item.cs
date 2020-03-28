using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float shootSpeed = 1f;
    public float shootFlySpeed = 1f;
    public bool isExplosive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShootManager player = other.GetComponent<PlayerShootManager>();
            player.shootSpeed *= shootSpeed;
            player.shootFlySpeed *= shootFlySpeed;

            if (isExplosive)
            {
                player.isExplosive = true;
            }
        }
    }
}
