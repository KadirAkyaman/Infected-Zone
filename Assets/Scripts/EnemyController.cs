using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    public int health;
    Rigidbody enemyRb;

    //TOUCH PLAYER
    public bool touchedPlayer;

    //ATTACK PLAYER
    public bool attackToPlayer;

    //IS DEAD
    public bool isDead;

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

    //Demon Death Effect
    [SerializeField] GameObject deathEffect;
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
        enemyRb.velocity = new Vector3(0, 0, 0);

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
        if (distance > demonAttackDistance)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            attackToPlayer = false;
        }
        else
        {
            transform.LookAt(player);
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + intervalTime;
                DemonAttack();
                attackToPlayer = true;

            }
        }
    }

    void DemonAttack()
    {
        GameObject bullet = Instantiate(bulletPrefab, demonFirePos.transform.position, demonFirePos.transform.rotation);

    }

    void ZombieMoveToPlayer()
    {
        if (!isDead)
        {
            transform.LookAt(player);//player adlý objeye döndür
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            transform.position = new Vector3(transform.position.x, -0.51f, transform.position.z);
            if (!touchedPlayer)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);//Player adlý objeye doðru hareket et
            }
        }
    }

    void DeathController()
    {
        if (health <= 0)
        {
            if (gameObject.CompareTag("Demon"))
            {
                StartCoroutine(DemonDeathEffect());
            }
            if (gameObject.CompareTag("Zombie"))
            {

                StartCoroutine(ZombieDeathEffect());
            }
        }
    }

    IEnumerator ZombieDeathEffect() {
        isDead = true;
        yield return new WaitForSeconds(2);
        GameObject xp = Instantiate(xpPrefab, transform.position, xpPrefab.transform.rotation);
        Destroy(gameObject);
    }
    IEnumerator DemonDeathEffect()
    {
        GameObject xp = Instantiate(xpPrefab, transform.position, xpPrefab.transform.rotation);
        GameObject deathEffectPrefab = Instantiate(deathEffect, gameObject.transform.position, deathEffect.transform.rotation);
        Destroy(gameObject);
        yield return new WaitForSeconds(3);
        Destroy(deathEffectPrefab);
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            transform.position -= transform.forward * gameManager.bulletPower * Time.deltaTime;
            health -= gameManager.bulletPower;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            touchedPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchedPlayer = false;
        }
    }

}
