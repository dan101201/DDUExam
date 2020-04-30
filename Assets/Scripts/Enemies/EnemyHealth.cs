using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float curentHealth;
    public float healthDropChance;
    public GameObject healthDrop;
    public AudioClip hurtClip;
    public AudioClip deathClip;

    private AudioSource source;

    void Start()
    {
        curentHealth = maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("FireBall"))
        {
            FireBall fireBall = other.GetComponent<FireBall>();
            TakeDamage(fireBall.damage);
            PlayAudio(hurtClip);
        }
    }
  
    void TakeDamage(float damage)
    {
        curentHealth -= damage;
        if (curentHealth <= 0)
        {
            DropHealth();
            gameObject.name = "Dead";
            StartCoroutine(Die());
        }
    }

    public void PlayAudio(AudioClip audioClip) {
        if (source is null) source = transform.GetComponent<AudioSource>();
        if (source is null) return;
        source.clip = audioClip;
        source.Play();
    }

    IEnumerator Die()
    {
        Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<ReferenceContainer>().PostMortemSoundObject, transform.position, transform.rotation).GetComponent<IndependentAudioPlayer>().PlaySound(deathClip);
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    void DropHealth()
    {
        while (healthDropChance >= 1)
        {
            Instantiate(healthDrop, transform.position, new Quaternion(0, 0, 0, 0));
            healthDropChance--;
        }
        if (Random.value <= healthDropChance)
        {
            Instantiate(healthDrop, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
