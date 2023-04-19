using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        transform.position = player.transform.position+offset;
    }
}
