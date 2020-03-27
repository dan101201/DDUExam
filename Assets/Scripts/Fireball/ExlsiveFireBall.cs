using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExlsiveFireBall : MonoBehaviour
{
    public float delay = 3f;
    public GameObject explosionEffect;
    float countDown;

    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f)
        {
            Explode();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosionEffect);
    }

}
