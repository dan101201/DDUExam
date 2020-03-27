using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 bulletVelocityVector;

    PlayerInput playerInputLayout;

    void Start()
    {
        playerInputLayout = GetComponent<PlayerInput>();
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = bulletVelocityVector;
    }
}
