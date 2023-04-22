using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Camera
    [SerializeField] Camera mainCamera;

    //Move
    public float speed;
    float horizontalInput;
    float verticalInput;

    //Fire
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePos;
    [SerializeField] float firePower;

    //Health
    [SerializeField] float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        PlayerMove();
        PlayerRotate();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void PlayerMove()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }

    void PlayerRotate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y - transform.position.y;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


        Vector3 direction = mousePosition - transform.position;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.transform.position, firePos.transform.rotation);
    }
}
