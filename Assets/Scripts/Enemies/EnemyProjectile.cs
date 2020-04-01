using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject explosionEffect;
    public bool canExplode;
    public float timeUntilDead;
    public float fireBallSize;
    public float damage = 20;

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
        gameObject.transform.position = new Vector3(10000, 10000, 10000);
        StartCoroutine(NextFrame());
    }
    IEnumerator NextFrame()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
