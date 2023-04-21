using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;
    [SerializeField] float fireSpeed;
    Transform playerPos;


    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        if (gameObject.CompareTag("Bullet"))
        {
            bulletRb.AddForce(transform.forward * fireSpeed);
        }
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        MoveToPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("Demon") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void MoveToPlayer()
    {
        if (gameObject.CompareTag("DemonBullet"))
        {
            playerPos = GameObject.Find("Player").GetComponent<Transform>();
            bulletRb.AddForce((playerPos.position - transform.position).normalized * fireSpeed);
        }
    }
}
