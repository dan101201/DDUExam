using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomreveal : MonoBehaviour
{
    public GameObject roof;
    public bool isPlayerInRoom;

    List<IBaseEnemy> enemies = new List<IBaseEnemy>();
    int colliderCount;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInRoom = true;
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
                isPlayerInRoom = false;
                roof.SetActive(true);
            }
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
