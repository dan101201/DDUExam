using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float curentHealth;
    public Slider slider;
    public bool canBeAttacked = true;
    public float invincibleTime = 2f;
    float timer;

    void Awake()
    {
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        curentHealth = maxHealth;
        timer = invincibleTime;
    }

    void Update()
    {
       timer += Time.deltaTime;
    }
    public void TakeDamage(float damage)
    {
        if (timer > invincibleTime)
        {
            timer = 0;
            curentHealth -= damage;
            slider.value = curentHealth;
            if (curentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
