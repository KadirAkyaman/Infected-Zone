using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderstormController : MonoBehaviour
{
    public float distance;
    public int damageAmount; // Verilecek hasar miktarý
    float timer = 0f; // Zamanlayýcý
    public float timeBetweenDamages = 2f; // Hasar aralýðý

    //Enemy Controller Script Attach
    EnemyController enemyController;

    //ATTACH THUNDERSTORM
    Thunderstorm thunderstorm;

    void Start()
    {
        thunderstorm = GameObject.Find("Skill Manager").GetComponent<Thunderstorm>();
    }
    void Update()
    {
        ThunderstormChangeUpdate();
    }
    void ThunderstormChangeUpdate()
    {
        distance = thunderstorm.distance;
        damageAmount = thunderstorm.damageAmount;
        timeBetweenDamages = thunderstorm.timeBetweenDamages;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zombie") || other.CompareTag("Demon"))
        {
            enemyController = other.GetComponent<EnemyController>();
            timer += Time.deltaTime;
            if (timer >= timeBetweenDamages)
            {
                enemyController.health -= damageAmount;
                timer = 0f;
            }
        }
    }

}
