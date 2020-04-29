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
            FireBallEffect fireBall = other.GetComponent<FireBallEffect>();
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
            gameObject.transform.position = new Vector3(10000, 10000, 10000);
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
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    void DropHealth()
    {
        if (Random.value <= healthDropChance)
        {
            Instantiate(healthDrop, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
