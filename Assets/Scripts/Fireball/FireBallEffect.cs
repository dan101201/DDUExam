using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEffect : MonoBehaviour
{
    public GameObject explosionEffect;
    public bool canExplode;
    public float timeUntilDead;
    public float fireBallSize;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(fireBallSize, fireBallSize, fireBallSize);
        var children = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            //Stores the child so unity doesnt have to get it every time, better for performance
            var child = gameObject.transform.GetChild(1).GetChild(i).gameObject;
            if (child.name == "PS_Fire_ALPHA" || child.name == "PS_Fire_ADD" || child.name == "PS_Glow" || child.name == "PS_Sparks")
            {
                child.transform.localScale = new Vector3(fireBallSize, fireBallSize, fireBallSize);
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
