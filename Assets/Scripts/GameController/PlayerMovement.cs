using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource walkSound;

    public float speed = 4.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.0f;

    public Transform groundCheck;
    public float groundDistance = 0.0f;
    public LayerMask groundMask;
    private bool isGrounded;

    Vector3 velocity;

    private void Start()
    {
        walkSound.volume = 0.0f;
    }

    void Update()
    {
        Sound();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-jumpHeight * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Sound()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && isGrounded)
        {
            if(walkSound.volume <= 1)
            {
                walkSound.volume += Time.deltaTime;
            }
        }

        else
        {
            if(walkSound.volume > 0)
            {
                walkSound.volume -= Time.deltaTime;
            }
        }
    }
}
