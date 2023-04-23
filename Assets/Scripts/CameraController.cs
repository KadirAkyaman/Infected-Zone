using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    GameObject player;
    [SerializeField] float zoomSpeed;
    float maxZoom = 15;
    float minZoom = 20;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        if (offset.y>=10&&offset.y<=25)
        {
            float scroll = -Input.GetAxis("Mouse ScrollWheel");
            offset += Vector3.up * zoomSpeed * scroll;
        }

        if (offset.y<maxZoom)
        {
            offset.y = maxZoom;
        }
        else if (offset.y>minZoom)
        {
            offset.y = minZoom;
        }
    }
}
