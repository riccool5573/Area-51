using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Light flashlight;

    private bool isGrounded;
    public bool isWalking = false;
    public bool isRunning = false;
    public bool noInput = true;

    private int health;
    private int maxHealth = 100;

    Vector3 velocity;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 18f;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            speed = 5f;
        }
        else
        {
            speed = 10f;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
        TakeDamage();
    }

    void TakeDamage()
    {
        if (Input.GetMouseButtonDown(0))
        {
            health -= 10;
            Debug.Log(health);
        }
        if(health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}