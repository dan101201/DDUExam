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
    public float damage;
    public float healthUp;
    public float maxHealthUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShootManager player = other.GetComponent<PlayerShootManager>();
            PlayerController playerC = other.GetComponent<PlayerController>();
            PlayerHealth playerH = other.GetComponent<PlayerHealth>();

            player.shootSpeed /= shootFlySpeedMultiplyer;
            player.shootFlySpeed *= shootTravelTimeMultiplyer;
            player.shootTravelTime *= shootFlySpeedMultiplyer;
            player.fireBallSize += fireBallSizeScale;
            player.damage += damage;
            if (isExplosive)
            {
                player.isExplosive = true;
            }
            playerC.movementSpeed *= movementSpeed;
            playerH.curentHealth += healthUp;
            playerH.maxHealth += maxHealthUp;
            Destroy(gameObject);
        }
    }
}
