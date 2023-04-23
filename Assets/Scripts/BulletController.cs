using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;
    Transform playerPos;

    //Attach GameManager Script
    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bulletRb = GetComponent<Rigidbody>();
        if (gameObject.CompareTag("Bullet"))
        {
            bulletRb.AddForce(transform.forward * gameManager.fireSpeed);
        }
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        MoveToPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("Demon"))
        {
            if (gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("DemonBullet"))
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.CompareTag("DemonBullet"))//Destroy demon bullet if touch a bullet or player
        {
            if (gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }

    void MoveToPlayer()
    {
        if (gameObject.CompareTag("DemonBullet"))
        {
            playerPos = GameObject.Find("Player").GetComponent<Transform>();
            transform.LookAt(playerPos);//player adlý objeye döndür
            transform.position += transform.forward * gameManager.demonBulletSpeed * Time.deltaTime;//Player adlý objeye doðru hareket et
        }
    }
}
