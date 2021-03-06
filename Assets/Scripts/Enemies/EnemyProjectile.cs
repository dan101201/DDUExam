﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject explosionEffect;
    public bool canExplode;
    public float timeUntilDead;
    public float shootSize;
    public float damage;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(shootSize, shootSize, shootSize);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            //Stores the child so unity doesnt have to get it every time, better for performance
            var child = gameObject.transform.GetChild(1).GetChild(i).gameObject;
            if (child.name == "PS_Fire_ALPHA" || child.name == "PS_Fire_ADD" || child.name == "PS_Glow" || child.name == "PS_Sparks")
            {
                child.transform.localScale = new Vector3(shootSize, shootSize, shootSize);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilDead -= Time.deltaTime;
        if(timeUntilDead <= 0f)
        {
            Explode();
            Destroy();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }

        if (!other.CompareTag("EnemyProjectile") && !other.CompareTag("Enemy") && !other.CompareTag("Room") && !other.CompareTag("Spikes") && !other.CompareTag("FireBall") && !other.CompareTag("Item") && !other.CompareTag("Door Cube"))
        {
            Explode();
            Destroy();
        }
    }

    void Explode()
    {
        if(canExplode)
        {
            explosionEffect = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosionEffect, 5f);
        }
    }

    void Destroy()
    {
        gameObject.transform.position = new Vector3(10000, 10000, 10000);
        StartCoroutine(NextFrame());
    }

    IEnumerator NextFrame()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
