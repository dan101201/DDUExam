using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    public GameObject shoot;
    public float shootSpeed = 2f;
    public float shootFlySpeed = 1f;
    public bool isExplosive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newShoot = Instantiate(shoot, transform.position, transform.rotation);
            newShoot.GetComponent<Rigidbody>().velocity = transform.forward * shootFlySpeed;
            if (isExplosive)
            {
                newShoot.GetComponent<ExlsiveFireBall>().canExplode = true;
            }
        }
    }
}
