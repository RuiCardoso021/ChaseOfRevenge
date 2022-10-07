using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject thePlayer;
    public Rigidbody rb;

    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    private Vector3 moveDirection;
    private Vector3 velocity;

    Animator animator;

    private CharacterController controller;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    public float playerHeight;
    public LayerMask Ground;
    bool isGrounded;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponentInChildren<Animator>();
        readyToJump = true;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, Ground);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);

            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
                animator.SetBool("Idle", false);
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true); 
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
                animator.SetBool("Idle", true);
            }

            moveDirection *= moveSpeed;

            // when to jump
            if (Input.GetKey(KeyCode.Space) && readyToJump && isGrounded)
            {
                readyToJump = false;

                Jump();
                animator.Play("Jump");

                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        //velocity.y = gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
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

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
