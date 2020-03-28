using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float shootSpeedMultiplyer = 1f;
    public float shootFlySpeedMultiplyer = 1f;
    public float shootTravelTimeMultiplyer = 1f;
    public float fireBallSizeScale = 0f;
    public bool isExplosive;
    public float movementSpeed =1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShootManager player = other.GetComponent<PlayerShootManager>();
            PlayerController playerC = other.GetComponent<PlayerController>();

            player.shootSpeed /= shootFlySpeedMultiplyer;
            player.shootFlySpeed *= shootTravelTimeMultiplyer;
            player.shootTravelTime *= shootFlySpeedMultiplyer;
            player.fireBallSize += fireBallSizeScale;
            if (isExplosive)
            {
                player.isExplosive = true;
            }
            playerC.movementSpeed *= movementSpeed;
            Destroy(gameObject);
        }
    }
}
