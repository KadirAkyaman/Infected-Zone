using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float bulletPower;


    void Start()
    {

    }

    void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        transform.LookAt(player);//player adl� objeye d�nd�r
        transform.position += transform.forward * speed * Time.deltaTime;//Player adl� objeye do�ru hareket et
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            transform.position -= transform.forward * bulletPower * Time.deltaTime;
        }
    }

}
