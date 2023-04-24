using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public GameObject[] collisionEffectPrefab; // Çarpýþma efekti
    public float effectDuration = 2.0f; // Efekt süresi


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
                // Çarpýþma noktasýndaki efekt instantiate edilir
                ContactPoint contact = collision.contacts[0];
                Instantiate(collisionEffectPrefab[0], contact.point, Quaternion.identity);

                // Efektin belirtilen süre sonra yok edilmesi için Invoke metodu kullanýlýr
                Invoke("DestroyEffect", effectDuration);
            }

            if (collision.gameObject.CompareTag("DemonBullet"))
            {
                // Çarpýþma noktasýndaki efekt instantiate edilir
                ContactPoint contact = collision.contacts[0];
                Instantiate(collisionEffectPrefab[1], contact.point, Quaternion.identity);

                // Efektin belirtilen süre sonra yok edilmesi için Invoke metodu kullanýlýr
                Invoke("DestroyEffect", effectDuration);
            }

            if (collision.gameObject.CompareTag("Wall"))
            {
                // Çarpýþma noktasýndaki efekt instantiate edilir
                ContactPoint contact = collision.contacts[0];
                Instantiate(collisionEffectPrefab[2], contact.point, Quaternion.identity);

                // Efektin belirtilen süre sonra yok edilmesi için Invoke metodu kullanýlýr
                Invoke("DestroyEffect", effectDuration);
            }
        }


    }


    private void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
