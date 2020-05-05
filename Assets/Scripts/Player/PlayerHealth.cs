using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;

    private float currentHealth;
    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value < 0f)
            {
                TakeDamage(value);
            }
            else if (value > 0f)
            {
                Heal(value);
            }
        }
    }

    public Slider slider;
    public bool canBeAttacked = true;
    public float invincibleTime = 2f;
    float timer;
    Material playerMat;

    void Awake()
    {
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        currentHealth = maxHealth;
        timer = invincibleTime;
        playerMat = gameObject.GetComponent<MeshRenderer>().material;
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
            currentHealth -= damage;
            slider.value = currentHealth;
            PlayAudio();
            StartCoroutine(TurnPlayerRed());
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        slider.value = currentHealth;
    }

    private IEnumerator TurnPlayerRed()
    {
        var oldColour = playerMat.GetColor("_EmissionColor");
        playerMat.SetColor("_EmissionColor",Color.red);
        yield return new WaitForSeconds(invincibleTime);
        playerMat.SetColor("_EmissionColor", oldColour);
        yield return null;
    }

    public AudioClip audioClip;
    private AudioSource source;
    public void PlayAudio() {
        if (source is null) source = transform.GetComponent<AudioSource>();
        if (source is null) return;
        source.clip = audioClip;
        source.Play();
    }
}
