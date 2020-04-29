using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public FireballStats stats;
    public float movementSpeedUp;
    public float healthUp;
    public float maxHealthUp;
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShootManager player = other.GetComponent<PlayerShootManager>();
            if (stats != null)
            {
                player.AddStats(stats);
            }

            PlayerController playerC = other.GetComponent<PlayerController>();
            PlayerHealth playerH = other.GetComponent<PlayerHealth>();
            player.PlayAudio();

            playerC.movementSpeed += movementSpeedUp;
            playerH.curentHealth += healthUp;
            playerH.maxHealth += maxHealthUp;
            Destroy(gameObject);
        }
    }
}
