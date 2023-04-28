using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderstorm : MonoBehaviour
{
    public float distance;
    public int damageAmount; // Verilecek hasar miktarý
    public float timeBetweenDamages = 2f; // Hasar aralýðý

    [SerializeField] GameObject prefab;
    GameObject thunderStorm;

   


    void Start()
    {
        thunderStorm = Instantiate(prefab, transform.position, prefab.transform.rotation);
        thunderStorm.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    private void Update()
    {
        thunderStorm.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        thunderStorm.transform.localScale = new Vector3(distance, distance, distance);
    }
}