using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] Image health;
    float maxHealth;

    //Attach EnemyController
    EnemyController enemyController;
    PlayerController playerController;
    void Start()
    {
        if (gameObject.CompareTag("Zombie") || gameObject.CompareTag("Demon"))
        {
            enemyController = GetComponent<EnemyController>();
            maxHealth = enemyController.health;
        }
        if (gameObject.CompareTag("Player"))
        {
            playerController = GetComponent<PlayerController>();
            maxHealth = playerController.maxHealth;
        }
    }

    void Update()
    {
        if (gameObject.CompareTag("Zombie") || gameObject.CompareTag("Demon"))
        {
            health.fillAmount = enemyController.health / maxHealth;
        }
        if (gameObject.CompareTag("Player"))
        {
            health.fillAmount = playerController.currentHealth / maxHealth;
        }
    }
}
