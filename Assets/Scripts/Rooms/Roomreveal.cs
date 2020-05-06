using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomreveal : MonoBehaviour
{
    public GameObject roof;
    public bool playerIsInRoom;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject mapSprite;

    int colliderCount;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine("LateActivateEnemies");
            roof.SetActive(false);
            colliderCount++;
            mapSprite.SetActive(true);
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

    IEnumerator LateActivateEnemies() {
        yield return new WaitForSeconds(2f);
        playerIsInRoom = true;
        yield return null;
    }

    public void CheckInEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void LateStart()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<IBaseEnemy>().LateStart();
        }
    }
}
