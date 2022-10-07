using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject thePlayer;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;

    private Vector3 moveDirection;
    private CharacterController controller;
    private float moveSpeed;
    private float walkSpeed;
    private float runSpeed;
    private int speed = 150;
    private float jumpHeight = 3.9f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        //if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        //{
        //    isMoving = true;
        //    thePlayer.GetComponent<Animator>().SetBool("Idle", false);
        //    thePlayer.GetComponent<Animator>().SetBool("Walk", true);
        //    horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * jumpHeight;
        //    thePlayer.transform.Rotate(0, horizontalMove, 0);
        //    thePlayer.transform.Translate(0, 0, verticalMove);
        //}
        //else
        //{
        //    isMoving = false;
        //    thePlayer.GetComponent<Animator>().SetBool("Walk", false);
        //    thePlayer.GetComponent<Animator>().SetBool("Idle", true);
        //}
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        
        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            // Walk
            Walk();
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            // Run
            Run();
        }
        else if (moveDirection == Vector3.zero)
        {
            // Idle
            Idle();
        }
        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Idle()
    {

    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }
    private void Run()
    {
        moveSpeed = runSpeed;
    }
}
