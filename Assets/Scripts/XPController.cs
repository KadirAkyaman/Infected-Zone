using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPController : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 10;
    [SerializeField] float xpAmount;

    //Magnet
    [SerializeField] float magnetFieldSize;

    //PlayerController Attach
    PlayerController playerController;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();//Attach player
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 playerXpDistance = player.transform.position - transform.position;
        float distance = Mathf.Sqrt(Mathf.Pow(playerXpDistance.x, 2) + Mathf.Pow(playerXpDistance.z, 2));
        if (distance <= magnetFieldSize)
        {
            transform.LookAt(player);//player adlý objeye döndür
            transform.position += transform.forward * speed * Time.deltaTime;//Player adlý objeye doðru hareket et
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.playerXp += xpAmount;
            Destroy(gameObject);
        }
    }
}
