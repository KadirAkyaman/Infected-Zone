using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalStrikeController : MonoBehaviour
{
    EnemyController enemyController;
    OrbitalStrike orbitalStrike;

    private void Start()
    {
        orbitalStrike = GameObject.Find("OrbitalStrike").GetComponent<OrbitalStrike>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie")||other.gameObject.CompareTag("Demon"))
        {
            enemyController = other.GetComponent<EnemyController>();
            enemyController.health -= orbitalStrike.power;
        }
    }
}
