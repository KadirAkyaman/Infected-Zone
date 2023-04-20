using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    //Player Controller Script
    PlayerController playerController;

    //Attack Time Components
    float nextAttackTime = 0f;
    float intervalTime = 2f;

    //Hit Effects
    MeshRenderer playerMesh;
    [SerializeField] Material[] materials;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerMesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + intervalTime;
                playerController.currentHealth -= 10;
                StartCoroutine(HitColor());
                Debug.Log(playerController.currentHealth);
            }
        }
    }

    IEnumerator HitColor()
    {
        playerMesh.material = materials[1];
        yield return new WaitForSeconds(0.3f);
        playerMesh.material = materials[0];
    }
}
