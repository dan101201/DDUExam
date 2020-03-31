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
            curentHealth -= fireBall.damage;
        }
    }
    void Update()
    {

        if (curentHealth <= 0)
        {
            gameObject.transform.position = new Vector3(10000, 10000, 10000);
            StartCoroutine(nextFrame());
        }
    }
    IEnumerator nextFrame()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
