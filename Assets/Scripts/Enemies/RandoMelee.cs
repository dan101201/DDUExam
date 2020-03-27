using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandoMelee : MonoBehaviour
{
    public Roomreveal room;

    NavMeshAgent navMeshAgent;
    Vector3 savedPlayerTransform;
    GameObject Player;
    bool Continue;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        savedPlayerTransform = Player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
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
            Debug.Log(navMeshAgent.remainingDistance);
            if (navMeshAgent.remainingDistance < 1f)
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
    }
}
