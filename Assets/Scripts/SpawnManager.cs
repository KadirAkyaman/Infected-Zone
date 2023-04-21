using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))//Summon Zombie
        {
            Instantiate(enemyPrefabs[0], new Vector3(0, 0, 0), enemyPrefabs[0].transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.O))//Summon Demon
        {
            Instantiate(enemyPrefabs[1], new Vector3(0, 0, 0), enemyPrefabs[1].transform.rotation);
        }
    }

}
