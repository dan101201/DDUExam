using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject explosionEffect;
    public bool canExplode;
    public float timeUntilDead;
    public float fireBallSize;
    public float damage;

    // Start is called before the first frame update


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
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        Destroy();
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
        Destroy(gameObject);
    }

}
