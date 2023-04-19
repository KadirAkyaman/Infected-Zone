using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Camera
    [SerializeField] Camera mainCamera;

    //Move
    [SerializeField] float speed;
    float horizontalInput;
    float verticalInput;

    //Rotate

    void Update()
    {
        PlayerMove();
        PlayerRotate();
    }

    void PlayerMove()
    {
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }

    void PlayerRotate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y - transform.position.y;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Karakterin yönünü belirle
        Vector3 direction = mousePosition - transform.position;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
