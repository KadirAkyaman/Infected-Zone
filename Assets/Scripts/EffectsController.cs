using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public GameObject[] collisionEffectPrefab; // �arp��ma efekti
    public float effectDuration = 2.0f; // Efekt s�resi


    //Attach Scripts    
    PlayerController playerController;
    EnemyController enemyController;


    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (gameObject.CompareTag("Demon"))
        {
            enemyController = GetComponent<EnemyController>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Bullet"))
        {
            if (collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("Demon"))
            {
                // �arp��ma noktas�ndaki efekt instantiate edilir
                ContactPoint contact = collision.contacts[0];
                Instantiate(collisionEffectPrefab[0], contact.point, Quaternion.identity);

                // Efektin belirtilen s�re sonra yok edilmesi i�in Invoke metodu kullan�l�r
                Invoke("DestroyEffect", effectDuration);
            }

            if (collision.gameObject.CompareTag("DemonBullet"))
            {
                // �arp��ma noktas�ndaki efekt instantiate edilir
                ContactPoint contact = collision.contacts[0];
                Instantiate(collisionEffectPrefab[1], contact.point, Quaternion.identity);

                // Efektin belirtilen s�re sonra yok edilmesi i�in Invoke metodu kullan�l�r
                Invoke("DestroyEffect", effectDuration);
            }

            if (collision.gameObject.CompareTag("Wall"))
            {
                // �arp��ma noktas�ndaki efekt instantiate edilir
                ContactPoint contact = collision.contacts[0];
                Instantiate(collisionEffectPrefab[2], contact.point, Quaternion.identity);

                // Efektin belirtilen s�re sonra yok edilmesi i�in Invoke metodu kullan�l�r
                Invoke("DestroyEffect", effectDuration);
            }


        }


    }

    void OnTriggerEnter(Collider other)                                                             //SKILL
    {
        if (gameObject.CompareTag("DemonBullet") && other.CompareTag("OrbitalStrike"))
        {
            Instantiate(collisionEffectPrefab[0], transform.position, Quaternion.identity);
        }
    }

    private void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
