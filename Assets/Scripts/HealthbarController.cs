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
    void Start()
    {
        if (gameObject.CompareTag("Zombie"))
        {
            enemyController = GetComponent<EnemyController>();
            maxHealth = enemyController.health;
        }
    }

    void Update()
    {
        health.fillAmount = enemyController.health / maxHealth;
    }
}
