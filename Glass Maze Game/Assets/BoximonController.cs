using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoximonController : MonoBehaviour
{
        public CharacterController controller;

    public float speed = 10f;
    // float rotSpeed = 80f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;

    // checking if grounded
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;

    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //if (anim.GetBool("Idle") = true)
        //{
        //    Debug.Log("Idle.");
        //}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveVector = (transform.right * x) + (transform.forward * z);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && moveVector.y < 0)
        {
            moveVector.y = -2f;
            //Debug.Log("Grounded.");
        }

        controller.Move(moveVector * speed * Time.deltaTime);

        if (moveVector.x != 0 || moveVector.z != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            //Debug.Log("Moving.");
        }

        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            //Debug.Log("Stopped.");
        }

        // jumping movement
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            moveVector.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetTrigger("Jump");
            Debug.Log("Jumping!");

        }

        moveVector.y += gravity * Time.deltaTime;

        controller.Move(moveVector * Time.deltaTime);
    }
}

