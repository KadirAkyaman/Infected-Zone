using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalStrike : MonoBehaviour
{
    //POWER
    public int power;

    public GameObject prefab;           // �nstantiate edilecek nesne
    public float distance = 1.0f;       // Nesneler aras�ndaki mesafe
    public float speed = 1.0f;          // D�n�� h�z�
    public int numObjects = 10;         // Nesne say�s�

    private float currentAngle = 0.0f;  // Ba�lang�� a��s�

    void Start()
    {
        // Nesneleri olu�tur
        CreateObjects();
    }

    void Update()
    {
        // Nesneleri d�nd�r
        RotateObjects();

        // Nesne say�s� de�i�tirildi�inde
        if (numObjects < transform.childCount || numObjects > transform.childCount)
        {
            // Yeni nesneleri olu�tur
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
        // Nesneleri d�nd�r
        foreach (Transform child in transform)
        {
            child.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }
}
