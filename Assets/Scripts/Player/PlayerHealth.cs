using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float curentHealth;
    public bool canBeAttacked = true;
    public float invincibleTime = 2f;
    float timer;
    bool isBeingHit;

    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;
        timer = invincibleTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isBeingHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isBeingHit = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isBeingHit)
        {
            Takedamage();
        }
        if (canBeAttacked == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canBeAttacked = true;
                timer = invincibleTime;
            }
        }
    }
    void Takedamage()
    {
        {
            if (canBeAttacked)
            {
                curentHealth -= 20;
                canBeAttacked = false;
            }
        }
    }
}
