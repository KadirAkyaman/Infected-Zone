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
            Debug.Log(playerController.currentHealth);
        }

        if (other.gameObject.CompareTag("Speed"))              //HEALTH
        {
            playerController.speed += speedAmount;
            Destroy(other.gameObject);
            Debug.Log(playerController.speed);
            StartCoroutine(speenController());
        }
    }

    IEnumerator speenController()
    {
        yield return new WaitForSeconds(5);
        playerController.speed -= speedAmount;
        Debug.Log(playerController.speed);
    }
}
