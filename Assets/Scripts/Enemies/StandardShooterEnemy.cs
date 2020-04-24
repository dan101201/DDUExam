using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandardShooterEnemy : MonoBehaviour
{
    public Roomreveal room;
    public GameObject shoot;
    public float shootSpeed = 1f;
    public float shootFlySpeed = 10f;
    public float shootTravelTime = 10f;
    public bool isExplosive;
    public float shootSize = 0.7f;
    public float damage;
    public float canShoot;
    public float ofsetAngle;
    PlayerHealth playerHealth;
    NavMeshAgent navMeshAgent;
    Vector3 savedPlayerTransform;
    GameObject Player;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        canShoot = shootSpeed;
        Player = GameObject.FindGameObjectWithTag("Player");
        savedPlayerTransform = Player.transform.position;
        room = transform.parent.parent.parent.GetComponent<Roomreveal>();
        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (room.isPlayerInRoom)
        {
            Vector3 tempPlayerTransform = Player.transform.position;
            if (tempPlayerTransform != savedPlayerTransform)
            {
                savedPlayerTransform = tempPlayerTransform;
                navMeshAgent.SetDestination(tempPlayerTransform);
            }
            else
            {
            }
            if (navMeshAgent.remainingDistance < 6f)
            {
                navMeshAgent.isStopped = true;
                transform.LookAt(Player.transform);
            }
            else
            {
                navMeshAgent.isStopped = false;
            }

            canShoot -= Time.deltaTime;
            if (canShoot <= 0f)
            {
                GameObject newShoot = Instantiate(shoot, transform.position, transform.rotation);

                newShoot.GetComponent<Rigidbody>().velocity = newShoot.transform.forward * shootFlySpeed;
                EnemyProjectile projectile = newShoot.GetComponent<EnemyProjectile>();
                projectile.timeUntilDead = shootTravelTime;
                projectile.shootSize = shootSize;
                projectile.damage = damage;
                projectile.playerHealth = playerHealth;
                canShoot = shootSpeed;
                PlayAudio();
            }
        }
        else
        {

        }
        
        
    }

    public AudioSource audioSource;

    public void PlayAudio() {
        audioSource.Play();
    }
}
