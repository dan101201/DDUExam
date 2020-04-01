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
        if (canBeAttacked)
        {
            curentHealth -= 20;
            canBeAttacked = false;
        }
    }
}
