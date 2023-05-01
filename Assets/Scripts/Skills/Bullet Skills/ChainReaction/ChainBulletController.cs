using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainBulletController : MonoBehaviour
{
    //Game Manager Attach
    GameManager gameManager;

    //Object Selector
    [SerializeField] float radius;
    Rigidbody hitRb;

    //Bullet
    Rigidbody bulletRb;
    public int bounceLimit = 2;//Maksimum seki�


    public GameObject[] enemy;
    public int enemyCount = 0;






    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        bulletRb = GetComponent<Rigidbody>();

        bulletRb.AddForce(transform.forward * gameManager.fireSpeed);
    }

    private void Update()
    {
        //gameObject.transform.position = new Vector3(transform.position.x, 0.328f, transform.position.z);                  
        if (bounceLimit <= 0)
        {
            Destroy(gameObject);
        }

        if (hitRb != null)
        {
            transform.LookAt(enemy[enemyCount].gameObject.transform);//player adl� objeye d�nd�r
            transform.position += transform.forward * gameManager.bulletPower * Time.deltaTime;//Player adl� objeye do�ru hareket et
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("Demon"))
        {
            Debug.Log(enemyCount + "" + bounceLimit);
            enemy[enemyCount] = collision.gameObject;
            enemyCount++;

            ObjectSelector();

        }

        if (collision.gameObject.CompareTag("DemonBullet"))
        {
            if (gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void ObjectSelector()
    {
        bounceLimit--;                                                                              //Bounce Limiti azalt
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        Collider closestCollider = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {

            bool isEnemy = false;
            foreach (GameObject element in enemy)
            {
                if (element == collider.gameObject)
                {
                    isEnemy = true;
                    break;
                }
            }

            if (!(collider.CompareTag("Zombie") || collider.CompareTag("Demon")) || isEnemy)
            {
                continue;
            }

            EnemyController enemyController;
            enemyController = collider.gameObject.GetComponent<EnemyController>();
            if (enemyController.isDead)//                                               E�er �l�yse gitmesin
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCollider = collider;
            }
        }

        if (closestCollider != null && bounceLimit > 0)
        {
            hitRb = closestCollider.GetComponent<Rigidbody>();
            enemy[enemyCount] = hitRb.gameObject;
        }
        else
        {
            Destroy(gameObject);//NULL ISE YOK ET
        }



    }
}
