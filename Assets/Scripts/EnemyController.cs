using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float bulletPower;
    [SerializeField] int remainingHit;

    //XP Components
    [SerializeField] GameObject xpPrefab;


    //Demon Attack
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform demonFirePos;

    //Attack Time Components
    float nextAttackTime = 0f;
    float intervalTime = 2f;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();//Attach player
        if (gameObject.CompareTag("Demon"))
        {
            demonFirePos = GameObject.FindWithTag("DemonFirePos").GetComponent<Transform>();
        }
    }

    void Update()
    {

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
        if (distance>8)
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
        if (remainingHit <= 0)
        {
            Destroy(gameObject);
            GameObject xp = Instantiate(xpPrefab, transform.position, xpPrefab.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            transform.position -= transform.forward * bulletPower * Time.deltaTime;
            remainingHit--;
        }
    }

}
