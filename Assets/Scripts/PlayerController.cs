using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;

    //Player Power
    public float playerPower;

    //Camera
    [SerializeField] Camera mainCamera;

    //Move
    public float speed;
    float horizontalInput;
    float verticalInput;

    //Fire
    public GameObject bulletPrefab;
    [SerializeField] Transform firePos;
    public float firePower;

    //Attack Time Components
    float nextAttackTime = 0f;
    public float attackTime;

    //Health
    public float maxHealth;
    public float currentHealth;

    //XP
    public float playerXp;

    //Fire Effect
    [SerializeField] ParticleSystem fireEffect;

    //BUFFS
    GeminiShot geminiShot;
    DoubleBarrel doubleBarrel;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        playerXp = 0;

        //BUFFS
        geminiShot = GameObject.Find("Buff Manager").GetComponent<GeminiShot>();
        doubleBarrel = GameObject.Find("Buff Manager").GetComponent<DoubleBarrel>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }

    void Update()
    {
        fireEffect.transform.position = firePos.transform.position;
        playerRb.velocity = new Vector3(0, 0, 0);
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackTime;
                for (int i = 0; i < geminiShot.bulletCount; i++)//                                  GEMINI SHOT
                {
                    Invoke("Fire", i * geminiShot.bulletDelay);
                }
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

    public void Fire()
    {
        fireEffect.Play();
        //                                                                                          DOUBLE BARREL
        if (doubleBarrel.bulletCount < 1)
        {
            return;
        }
        else if (doubleBarrel.bulletCount == 1)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePos.transform.position, firePos.transform.rotation);
        }
        else
        {
            float totalBulletDistance = (doubleBarrel.bulletCount - 1) * doubleBarrel.bulletDistance;
            Vector3 firstBulletOffset = -firePos.transform.right * totalBulletDistance / 2;

            for (int i = 0; i < doubleBarrel.bulletCount; i++)
            {
                Vector3 offset = firstBulletOffset + i * doubleBarrel.bulletDistance * firePos.transform.right;
                GameObject bullet = Instantiate(bulletPrefab, firePos.transform.position + offset, firePos.transform.rotation);
            }
        }
    }
}
