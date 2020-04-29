using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEffect : MonoBehaviour
{
    public float damage = 0f;
    private float explosionSize = 0f;
    public GameObject explosionEffect;
    public float destructionDelay = 1f;
    public void StartShot(FireballStats stats) {
        damage = stats.damage;
        explosionSize = stats.ExplosionSize;
        Destroy(gameObject,stats.TimeAlive);
        transform.localScale = new Vector3(stats.fireBallSize, stats.fireBallSize, stats.fireBallSize);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var child = gameObject.transform.GetChild(1).GetChild(i).gameObject;
            child.transform.localScale = new Vector3(stats.fireBallSize, stats.fireBallSize, stats.fireBallSize);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fireball hit object");
        if (!other.CompareTag("EnemyProjectile") && !other.CompareTag("Player") && !other.CompareTag("Room") && !other.CompareTag("Spikes"))
        {
            Explode();
            Destroy(gameObject,destructionDelay);
        }
    }
    void Explode()
    {
        if (explosionSize > 0) {
            explosionEffect = Instantiate(explosionEffect, transform.position, transform.rotation);
            explosionEffect.transform.localScale = new Vector3(explosionSize,explosionSize,explosionSize);
            Destroy(explosionEffect, 5f);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }

}
