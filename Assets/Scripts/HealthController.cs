using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    //Attach Scripts
    PlayerController playerController;
    GameManager gameManager;

    //Attack Time Components
    float nextAttackTime = 0f;
    float intervalTime = 2f;

    //Hit Effects
    MeshRenderer playerMesh;
    [SerializeField] Material[] materials;

    //Zombie Power
    [SerializeField]float zombiePower;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerMesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + intervalTime;
                playerController.currentHealth -= zombiePower;
                StartCoroutine(HitColor());
            }
        }
    }

    IEnumerator HitColor()
    {
        playerMesh.material = materials[1];
        yield return new WaitForSeconds(0.2f);
        playerMesh.material = materials[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DemonBullet"))
        {
            playerController.currentHealth -= gameManager.demonBulletPower;
            StartCoroutine(HitColor());
        }
    }

}
