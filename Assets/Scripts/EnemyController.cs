using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] int health;
    Rigidbody enemyRb;

    //XP Components
    [SerializeField] GameObject xpPrefab;


    //Demon Attack
    [SerializeField] GameObject bulletPrefab;
    Transform demonFirePos;
    [SerializeField] float demonAttackDistance;

    //Attack Time Components
    float nextAttackTime = 0f;
    float intervalTime = 2f;

    //Attach BulletController Script
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();//Attach player
        if (gameObject.CompareTag("Demon"))
        {
            demonFirePos = transform.GetChild(0);
        }
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        enemyRb.velocity = new Vector3(0,0,0);

        if (gameObject.CompareTag("Zombie"))
        {
            ZombieMoveToPlayer();

            DeathController();
        }

        if (gameObject.CompareTag("Demon"))
        {
            DemonMoveToPlayer();

            DeathController();
        }
    }

    

    void DemonMoveToPlayer()
    {
        Vector3 playerDemonDistance = player.transform.position - transform.position;
        float distance = Mathf.Sqrt(Mathf.Pow(playerDemonDistance.x, 2) + Mathf.Pow(playerDemonDistance.z, 2));
        if (distance>demonAttackDistance)
        {
            transform.LookAt(player);//player adlý objeye döndür
            transform.position += transform.forward * speed * Time.deltaTime;//Player adlý objeye doðru hareket et
        }
        else
        {
            transform.LookAt(player);
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + intervalTime;
                DemonAttack();

            }
        }
    }

    void DemonAttack()
    {
        GameObject bullet = Instantiate(bulletPrefab, demonFirePos.transform.position, demonFirePos.transform.rotation);
    }

    void ZombieMoveToPlayer()
    {
        transform.LookAt(player);//player adlý objeye döndür
        transform.position += transform.forward * speed * Time.deltaTime;//Player adlý objeye doðru hareket et
    }

    void DeathController()
    {
        if (health <= 0)
        {
            if (gameObject.CompareTag("Demon"))
            {
                //isDead = true;
            }
            Destroy(gameObject);
            GameObject xp = Instantiate(xpPrefab, transform.position, xpPrefab.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            transform.position -= transform.forward * gameManager.bulletPower * Time.deltaTime;
            health -= gameManager.bulletPower;
        }
    }

}
