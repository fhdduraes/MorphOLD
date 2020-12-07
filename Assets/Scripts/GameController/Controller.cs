using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    GameObject cameraFirst;
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    public GameObject gameController;

    float xRotation = 0.0f;
    float yRotation = 0.0f;

    public float speed = 4.0f;
    public float rotationSpeed = 10.0f;
    public float jumpForce = 5.0f;
    private float timer;

    public AudioSource stepSound;

    void Start()
    {
        transform.tag = "Player";
        gameController.transform.localPosition = new Vector3(0, 0, 0);
        cameraFirst = GetComponentInChildren(typeof(Camera)).transform.gameObject;
        cameraFirst.transform.localPosition = new Vector3(0, 0.4f, 0);
        cameraFirst.transform.localRotation = Quaternion.identity;
        controller = GetComponent<CharacterController>();

        timer = 0;
        stepSound.pitch = 1.0f;
        stepSound.PlayDelayed(1.0f);
        stepSound.volume = 0.0f;
    }

    void Update()
    {
        Cursor.visible = false;

        Vector3 directionFront = new Vector3(cameraFirst.transform.forward.x, 0, cameraFirst.transform.forward.z);
        Vector3 directionSide = new Vector3(cameraFirst.transform.right.x, 0, cameraFirst.transform.right.z);
        directionFront.Normalize();
        directionSide.Normalize();

        directionFront = directionFront * Input.GetAxis("Vertical");
        directionSide = directionSide * Input.GetAxis("Horizontal");

        Vector3 finalDirection = directionFront + directionSide;

        if(finalDirection.sqrMagnitude > 1)
        {
            finalDirection.Normalize();
        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(finalDirection.x, 0, finalDirection.z);
            moveDirection *= speed;

            

            if(moveDirection != Vector3.zero)
            {
                timer += Time.deltaTime;

                if(stepSound.volume < 1)
                {
                    stepSound.volume += Time.deltaTime/2;
                }

                if (stepSound.pitch <= 2.0f)
                {
                    stepSound.pitch += Input.GetAxis("Vertical")*Time.deltaTime;
                    stepSound.pitch += Input.GetAxis("Horizontal")*Time.deltaTime;
                }

                if (timer >= 0.4f)
                {
                    stepSound.UnPause();
                    timer = 0.0f;
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (stepSound.pitch > 1.0f)
                {
                    stepSound.pitch -= Time.deltaTime * 4;
                }
                
                if(stepSound.volume > 0.0f)
                {
                    stepSound.volume -= Time.deltaTime * 4;
                }

                if (timer >= 0.6f)
                {
                    stepSound.Pause();
                    timer = 0.0f;
                }
            }

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        

        moveDirection.y -= 18.0f * Time.deltaTime; 
        controller.Move(moveDirection * Time.deltaTime);

        FirstPersonCamera();
    }

    void FirstPersonCamera()
    {
        xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;

        xRotation = ClampAngleCam (xRotation,-360, 360);
        yRotation = ClampAngleCam (yRotation, -80, 80);

        Quaternion xQuaternion = Quaternion.AngleAxis(xRotation, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(yRotation, -Vector3.right);
        Quaternion finalRotation = Quaternion.identity * xQuaternion * yQuaternion;

        cameraFirst.transform.localRotation = Quaternion.Lerp(cameraFirst.transform.localRotation, finalRotation, Time.deltaTime * 10.0f);
    }

    float ClampAngleCam(float angle, float min, float max)
    {
        if(angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp (angle, min, max);
    }
}
