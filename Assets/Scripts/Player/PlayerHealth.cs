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
    Material playerMat;

    void Awake()
    {
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        curentHealth = maxHealth;
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
            curentHealth -= damage;
            slider.value = curentHealth;
            PlayAudio();
            StartCoroutine("TurnPlayerRed");
            if (curentHealth <= 0)
            {
                Destroy(gameObject);

            }
        }
    }

    private IEnumerator TurnPlayerRed()
    {
        var oldColour = playerMat.GetColor("_EmissionColor");
        playerMat.SetColor("_EmissionColor",Color.red);
        yield return new WaitForSeconds(invincibleTime);
        playerMat.SetColor("_EmissionColor", oldColour);
        yield return null;
    }

    public AudioClip audioSource;
    private AudioSource source;
    public void PlayAudio() {
        if (source is null) source = transform.GetComponent<AudioSource>();
        source.clip = audioSource;
        source.Play();
    }
}
