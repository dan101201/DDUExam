using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public float TimeTillDeath;
    public float IntershotDelay;

    bool canShoot;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (canShoot && Input.GetButton("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            Destroy(newBullet, TimeTillDeath);
            canShoot = false;
            StartCoroutine(ShootWait());
        }
    }

    IEnumerator ShootWait()
    {
        yield return new WaitForSeconds(IntershotDelay);
        canShoot = true;
    }
}
