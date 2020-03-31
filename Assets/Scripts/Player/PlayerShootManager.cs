using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    public GameObject shoot;
    public float shootSpeed = 1f;
    public float shootFlySpeed = 10f;
    public float shootTravelTime = 10f;
    public bool isExplosive;
    public float fireBallSize = 0.7f;
    public float damage;
    float canShoot;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = shootSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        canShoot -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot <= 0f)
        {
            GameObject newShoot = Instantiate(shoot, transform.position, transform.rotation);
            newShoot.GetComponent<Rigidbody>().velocity = transform.forward * shootFlySpeed;
            newShoot.GetComponent<FireBallEffect>().timeUntilDead = shootTravelTime;
            newShoot.GetComponent<FireBallEffect>().fireBallSize = fireBallSize;
            newShoot.GetComponent<FireBallEffect>().damage = damage;

            if (isExplosive)
            {
                newShoot.GetComponent<FireBallEffect>().canExplode = true;
            }
            canShoot = shootSpeed;
        }
    }
}
