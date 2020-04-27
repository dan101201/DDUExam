using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomreveal : MonoBehaviour
{
    public GameObject roof;
    public bool playerIsInRoom;

    List<IBaseEnemy> enemies = new List<IBaseEnemy>();
    int colliderCount;
    bool open = true;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerIsInRoom = true;
            roof.SetActive(false);
            colliderCount++;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            colliderCount--;
            if (colliderCount == 0)
            {
                playerIsInRoom = false;
                roof.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        int deadCount = 0;
        foreach (IBaseEnemy enemy in enemies)
        {
            if (enemy is null)
            {
                deadCount++;
            }
        }

        if (!open)
        {
            if (playerIsInRoom && enemies.Count == deadCount)
            {
                open = true;
            }
        }
        else if (playerIsInRoom && enemies.Count != deadCount)
        {
            open = false;
            CloseCullases();
        }
    }

    void CloseCullases()
    {
        for (int i = 2; i < transform.childCount; i++)
        {
            transform.GetChild(0).GetComponent<Animator>();
        }
    }

    public void CheckInEnemy(IBaseEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void LateStart()
    {
        foreach (IBaseEnemy enemy in enemies)
        {
            enemy.LateStart();
        }
    }
}
