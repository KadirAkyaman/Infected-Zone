using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] float healthAmount;
    [SerializeField] float speedAmount;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health"))              //HEALTH
        {
            playerController.currentHealth += healthAmount;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Speed"))              //SPEED
        {
            playerController.speed += speedAmount;
            Destroy(other.gameObject);
            StartCoroutine(speenController());
        }

        if (other.gameObject.CompareTag("Boost"))              //Boost
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator speenController()
    {
        yield return new WaitForSeconds(5);
        playerController.speed -= speedAmount;
    }
}
