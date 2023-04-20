using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;
    [SerializeField] float fireSpeed;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * fireSpeed);
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }
}
