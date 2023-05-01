using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBlastController : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody bulletRb;

    public int bulletDamage;

    public GameObject explosionEffect; // Patlama efekti
    public float explosionRadius = 5.0f; // Patlama yarýçapý

    EnemyController enemyController;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        bulletRb = GetComponent<Rigidbody>();

        bulletRb.AddForce(transform.forward * gameManager.fireSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Demon") || collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Barrel"))
        {
            Explode();
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
    private void Explode()
    {
        // Patlama efekti instantiate edilir
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Belirli alandaki rakipler fýrlatýlýr
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.CompareTag("Demon") || hit.gameObject.CompareTag("Zombie"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null && rb.gameObject.CompareTag("Zombie") || rb.gameObject.CompareTag("Demon"))
                {
                    enemyController = rb.gameObject.GetComponent<EnemyController>();//ÇARPILAN OBJENÝN ENEMY CONTROLLER SCRÝPTÝNE ERÝÞ
                    enemyController.health -= bulletDamage;
                }
            }
        }

        // Bu obje yok edilir
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
