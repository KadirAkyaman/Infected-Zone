using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public GameObject[] collisionEffectPrefab; // �arp��ma efekti
    public float effectDuration = 2.0f; // Efekt s�resi
    GameObject weaponBoost;

    //Attach PlayerController
    PlayerController playerController;

    private void Start()
    {
        weaponBoost = GameObject.Find("BoostEffect");
        if (gameObject.CompareTag("Player"))//e�er player isen efekti false yap. Sebebi bullette de bu oldu�undan dolay� ate� edince efekt iptal oluyor
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
