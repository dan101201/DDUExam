using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Roomreveal room;
    public GameObject shoot;
    public float shootSpeed = 1f;
    public float shootFlySpeed = 10f;
    public float shootTravelTime = 10f;
    public float shootSize = 0.7f;
    public float damage;
    public float offsetAngle;
    public int shootAmount;
    public GameObject[] bossMovePoints;
    NavMeshAgent navMeshAgent;
    GameObject player;
    GameObject child;
    float angel;
    public float canShoot;
    public bool isAttacking = false;
    float attackTImeLeft = 10;
    int nextAttack = 0;
<<<<<<< Updated upstream
    GameObject bossHealth;
=======

>>>>>>> Stashed changes
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        room = transform.parent.parent.parent.GetComponent<Roomreveal>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject tempChild = gameObject.transform.GetChild(i).gameObject;
            if (tempChild.name == "Boss_01")
            {
                child = tempChild;
            }
        }
        bossHealth = gameObject.transform.GetChild(0).GetChild(gameObject.transform.childCount - 1).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (room.isPlayerInRoom)
        {
            child.transform.Rotate(0, 0.5f, 0);
             
            if (bossHealth.name == "Dead")
            {
                Destroy();
            }
            if (navMeshAgent.remainingDistance < 0.1f)
            {
                if (isAttacking == false)
                {
                    nextAttack = Random.Range(1, 4);
                    Debug.Log(nextAttack);
                    isAttacking = true;
                    attackTImeLeft = 10;
                }
            }
            if (nextAttack == 1 && isAttacking)
            {
                attackTImeLeft -= Time.fixedDeltaTime;
                shootAmount = 3;
                offsetAngle = 4f;
                shootSize = 10f;
                shootSpeed = 0.2f;
                Attack();
                if (attackTImeLeft <= 0)
                {
                    Move();
                    isAttacking = false;
                }
            }
            if (nextAttack == 2 && isAttacking)
            {
                attackTImeLeft -= Time.fixedDeltaTime;
                shootAmount = 4;
                offsetAngle = 30;
                shootSize = 5;
                shootSpeed = 0.2f;
                Attack();
                if (attackTImeLeft <= 0)
                {
                    Move();
                    isAttacking = false;
                }
            }
            if (nextAttack == 3 && isAttacking)
            {
                attackTImeLeft -= Time.fixedDeltaTime;
                shootAmount = 30;
                offsetAngle = 0f;
                shootSize = 10f;
                shootSpeed = 2f;
                Attack();
                if (attackTImeLeft <= 0)
                {
                    Move();
                    isAttacking = false;
                }
            }
        }
    }
    void Attack()
    {
        canShoot -= Time.deltaTime;
        if (canShoot <= 0f)
        {
            for (int amountShoot = 0; amountShoot < shootAmount; amountShoot += 1)
            {
                GameObject newShoot = Instantiate(shoot, transform.position + new Vector3(0, -0.6f, 0), transform.rotation);
                newShoot.transform.Rotate(0, angel, 0);
                newShoot.GetComponent<Rigidbody>().velocity = newShoot.transform.forward * shootFlySpeed;
                EnemyProjectile projectile = newShoot.GetComponent<EnemyProjectile>();
                projectile.timeUntilDead = shootTravelTime;
                projectile.shootSize = shootSize;
                projectile.damage = damage;
                angel += (360 / shootAmount);
            }
            angel -= (360 / shootAmount * shootAmount);
            angel += offsetAngle;
            canShoot = shootSpeed;
        }
    }
    void Move()
    {
        GameObject nextPosition = bossMovePoints[Random.Range(0, bossMovePoints.Length)];
        navMeshAgent.SetDestination(nextPosition.transform.position);
        Debug.Log(navMeshAgent.destination);
    }
    void Destroy()
    {
        gameObject.transform.position = new Vector3(10000, 10000, 10000);
        StartCoroutine(NextFrame());
    }
    IEnumerator NextFrame()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
