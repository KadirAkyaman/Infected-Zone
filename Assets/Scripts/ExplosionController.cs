using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public GameObject[] explosionEffect; // Patlama efekti
    public float explosionForce = 1000.0f; // F�rlatma kuvveti
    public float explosionRadius = 5.0f; // Patlama yar��ap�

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("DemonBullet"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // Patlama efekti instantiate edilir
        Instantiate(explosionEffect[0], transform.position, Quaternion.identity);
        Instantiate(explosionEffect[1], transform.position, Quaternion.identity);

        // Belirli alandaki rakipler f�rlat�l�r
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && !rb.gameObject.CompareTag("Player") && !rb.gameObject.CompareTag("Wall") && !rb.gameObject.CompareTag("Xp"))
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                Destroy(rb.gameObject);
            }
        }

        // Bu obje yok edilir
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
