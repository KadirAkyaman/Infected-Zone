using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    //ENEMY CONTROLLER ATTACH
    EnemyController enemyController;

    //SKILL ATTACH
    OrbitalStrike orbitalStrike;
    void Start()
    {
        enemyController = GetComponent<EnemyController>();

        //OrbitalStrike
        orbitalStrike = GameObject.Find("Skill Manager").GetComponent<OrbitalStrike>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OrbitalStrike"))
        {
            enemyController.health -= orbitalStrike.power;
        }
    }
}
