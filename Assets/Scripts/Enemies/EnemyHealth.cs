using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float curentHealth;

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
        }
    }
  
    void TakeDamage(float damage)
    {
        curentHealth -= damage;
        if (curentHealth <= 0)
        {
            gameObject.transform.position = new Vector3(10000, 10000, 10000);
            gameObject.name = "Dead";
            StartCoroutine(NextFrame());
        }
    }

    public AudioClip audioSource;
    private AudioSource source;
    public void PlayAudio() {
        if (source is null) source = transform.GetComponent<AudioSource>();
        source.clip = audioSource;
        source.Play();
    }

    IEnumerator NextFrame()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
