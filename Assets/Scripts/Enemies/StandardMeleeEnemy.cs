using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandardMeleeEnemy : MonoBehaviour, IBaseEnemy
{
    public Roomreveal Room { get; set; }
    public int Damage;
    public int Speed;

    NavMeshAgent navMeshAgent;
    GameObject Player;
    PlayerHealth playerHealth;
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
        Room = transform.parent.parent.parent.GetComponent<Roomreveal>();
        Room.CheckInEnemy(gameObject);
    }

    public void LateStart()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (Room.playerIsInRoom)
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

    public AudioClip audioClip;
    private AudioSource source;
    public void PlayAudio()
    {
        if (source is null) source = transform.GetComponent<AudioSource>();
        source.clip = audioClip;
        source.Play();
    }
}
