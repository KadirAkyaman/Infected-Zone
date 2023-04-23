using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public GameObject[] collisionEffectPrefab; // Çarpýþma efekti
    public float effectDuration = 2.0f; // Efekt süresi
    GameObject weaponBoost;

    //Attach PlayerController
    PlayerController playerController;

    private void Start()
    {
        weaponBoost = GameObject.Find("BoostEffect");
        if (gameObject.CompareTag("Player"))//eðer player isen efekti false yap. Sebebi bullette de bu olduðundan dolayý ateþ edince efekt iptal oluyor
        {
            weaponBoost.SetActive(false);
        }
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("Boost"))
            {
                StartCoroutine(WeaponBoost());
            }
        }

    }

    IEnumerator WeaponBoost()
    {
        weaponBoost.SetActive(true);
        playerController.firePower *= 2;                    //FIRE POWER * 2
        yield return new WaitForSeconds(10);
        weaponBoost.SetActive(false);
        playerController.firePower /= 2;
    }

    private void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
