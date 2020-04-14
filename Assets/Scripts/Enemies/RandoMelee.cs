using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandoMelee : MonoBehaviour
{
    public Roomreveal room;
    NavMeshAgent navMeshAgent;
    GameObject Player;
    PlayerHealth playerHealth;
    public int Damage;
    public int Speed;
    float timer;
    float attackTimer;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && attackTimer >= Speed)
        {
            attackTimer = 0;
            playerHealth.TakeDamage(Damage);
        }
    }

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        room = transform.parent.parent.parent.GetComponent<Roomreveal>();
        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (room.isPlayerInRoom)
        {
            if (navMeshAgent.remainingDistance < 0.3f)
            {
                navMeshAgent.isStopped = true;
                transform.LookAt(Player.transform);
                Move();
            }
            else
            {
                navMeshAgent.isStopped = false;
            }
        }
    }
    void Move()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            navMeshAgent.SetDestination(Player.transform.position);
            timer = 2f;
        }
    }
}
