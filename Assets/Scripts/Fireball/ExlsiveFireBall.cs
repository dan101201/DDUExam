using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExlsiveFireBall : MonoBehaviour
{
    public GameObject explosionEffect;
    public bool canExplode;
    public float timeUntilDead;

    // Start is called before the first frame update
    void Start()
    {

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
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        Destroy();
    }
    void Explode()
    {
        if(canExplode)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
        Destroy(explosionEffect);
    }

}
