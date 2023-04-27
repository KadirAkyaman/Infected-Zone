using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalStrike : MonoBehaviour
{
    //POWER
    public int power;

    public GameObject prefab;           // Ýnstantiate edilecek nesne
    public float distance = 1.0f;       // Nesneler arasýndaki mesafe
    public float speed = 1.0f;          // Dönüþ hýzý
    public int numObjects = 10;         // Nesne sayýsý

    private float currentAngle = 0.0f;  // Baþlangýç açýsý

    void Start()
    {
        // Nesneleri oluþtur
        CreateObjects();
    }

    void Update()
    {
        // Nesneleri döndür
        RotateObjects();

        // Nesne sayýsý deðiþtirildiðinde
        if (numObjects < transform.childCount || numObjects > transform.childCount)
        {
            // Yeni nesneleri oluþtur
            CreateObjects();
        }
    }

    void CreateObjects()
    {
        // Eski nesneleri yok et
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Yeni nesneleri instantiate et
        for (int i = 0; i < numObjects; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.transform.localPosition = new Vector3(0, 0, distance);
            obj.transform.RotateAround(transform.position, Vector3.up, currentAngle);
            currentAngle += 360.0f / numObjects;
        }
    }

    void RotateObjects()
    {
        // Nesneleri döndür
        foreach (Transform child in transform)
        {
            child.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }

}
