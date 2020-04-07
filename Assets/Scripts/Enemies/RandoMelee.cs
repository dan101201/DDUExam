using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandoMelee : MonoBehaviour
{
    public Roomreveal room;

    NavMeshAgent navMeshAgent;
    GameObject Player;
    float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            room = other.GetComponent<Roomreveal>();
        }
    }
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
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
