using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform player;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //--------------------Peeking Around Corners-----------------------\\ 

        if (Input.GetKey(KeyCode.Q))
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 25f);
            transform.localPosition = new Vector3(-1f, 1.58f, 0f);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.localPosition = new Vector3(0f, 1.58f, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, -25f);
            transform.localPosition = new Vector3(1f, 1.58f, 0f);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.localPosition = new Vector3(0f, 1.58f, 0f);
        }
        player.Rotate(Vector3.up * mouseX);
    }
}
