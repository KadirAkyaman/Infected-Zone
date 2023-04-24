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
    public float firePower;

    //Attack Time Components
    float nextAttackTime = 0f;
    [SerializeField] float attackTime;

    //Health
    public float maxHealth;
    public float currentHealth;

    //XP
    public float playerXp;


    void Start()
    {
        currentHealth = maxHealth;
        playerXp = 0;
    }

    void Update()
    {
        PlayerMove();
        PlayerRotate();
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackTime;
                Fire();

            }
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
