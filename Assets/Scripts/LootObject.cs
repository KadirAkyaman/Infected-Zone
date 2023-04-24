using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour
{
    PlayerController playerController;
    public float healthAmount;
    public float speedAmount;
    public float boostAmount;

    //Effects
    GameObject boostEffect;
    GameObject healEffect;
    GameObject speedEffect;
    GameObject walkEffect;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        boostEffect = GameObject.Find("BoostEffect");
        boostEffect.SetActive(false);
        healEffect = GameObject.Find("HealEffect");
        healEffect.SetActive(false);
        speedEffect = GameObject.Find("SpeedEffect");
        speedEffect.SetActive(false);
        walkEffect = GameObject.Find("WalkEffect");
        walkEffect.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            walkEffect.SetActive(true);
        }
        else
        {
            walkEffect.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerController.currentHealth!=playerController.maxHealth) //E�er can full de�ilse
        {
            if (other.gameObject.CompareTag("Health"))              //HEALTH
            {
                other.gameObject.SetActive(false);
                StartCoroutine(HealEffect());
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Speed"))              //SPEED
        {
            other.gameObject.SetActive(false);
            StartCoroutine(SpeedEffect());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Boost"))              //Boost
        {
            other.gameObject.SetActive(false);
            StartCoroutine(WeaponBoost());
            Destroy(other.gameObject);
        }
    }

    IEnumerator HealEffect()
    {
        if (playerController.currentHealth<=80)                             //BU KOD SATIRINDA KARAKTER�N CANINI YA 20 ARTTIRIYOR YA DA 100E TAMAMLIYOR
        {
            playerController.currentHealth += healthAmount;
            healEffect.SetActive(true);          //HEAL
            yield return new WaitForSeconds(5);
            healEffect.SetActive(false);
        }
        else
        {
            playerController.currentHealth = playerController.maxHealth;
            healEffect.SetActive(true);          //HEAL
            yield return new WaitForSeconds(5);
            healEffect.SetActive(false);
        }
    }
    IEnumerator SpeedEffect()
    {
        playerController.speed += speedAmount;
        speedEffect.SetActive(true);
        yield return new WaitForSeconds(10);
        speedEffect.SetActive(false);
        playerController.speed -= speedAmount;
    }

    IEnumerator WeaponBoost()
    {
        playerController.firePower *= boostAmount;
        boostEffect.SetActive(true);                  //FIRE POWER * 2
        yield return new WaitForSeconds(10);
        boostEffect.SetActive(false);
        playerController.firePower /= boostAmount;
    }

}
