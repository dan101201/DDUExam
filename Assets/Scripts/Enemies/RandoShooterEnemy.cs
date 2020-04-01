using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandoShooterEnemy : MonoBehaviour
{
    public Roomreveal room;
    public GameObject shoot;
    public float shootSpeed = 1f;
    public float shootFlySpeed = 10f;
    float canShoot;
    NavMeshAgent navMeshAgent;
    Vector3 savedPlayerTransform;
    GameObject Player;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        canShoot = shootSpeed;
        Player = GameObject.FindGameObjectWithTag("Player");
        savedPlayerTransform = Player.transform.position;
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
                Debug.Log("Player has moved");
            }
            else
            {
                Debug.Log("Player hasn't moved");
            }
            //Debug.Log(navMeshAgent.remainingDistance);
            if (navMeshAgent.remainingDistance < 10f)
            {
                navMeshAgent.isStopped = true;
                transform.LookAt(Player.transform);
                Debug.Log("Close Enough");
            }
            else
            {
                navMeshAgent.isStopped = false;
            }

        }
        else
        {

        }


        canShoot -= Time.deltaTime;
        if (canShoot <= 0f)
        {
            GameObject newShoot = Instantiate(shoot, transform.position, transform.rotation);
            newShoot.GetComponent<Rigidbody>().velocity = transform.forward * shootFlySpeed;
            canShoot = shootSpeed;
        }
    }
}
