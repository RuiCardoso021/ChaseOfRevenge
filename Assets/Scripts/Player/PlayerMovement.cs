using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject thePlayer;
    public Rigidbody rb;
    public bool activePlayer;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float coolDownJumpTime;
    public bool isIdleCooldown;
    public float playerHeight;
    public LayerMask Ground;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private Animator animator;
    private bool isGrounded;
    private CharacterController controller;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    private void Start()
    {
        
        if (activePlayer){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            controller = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            animator = GetComponentInChildren<Animator>();
            isIdleCooldown = false;
        }
    }

    void Update()
    {
        if (activePlayer) Move();
    }

    private void Move()
    {
        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, Ground);
        
        if (isGrounded )
        {
            if (velocity.y < 0) velocity.y = -2f;
                
            float moveZ = Input.GetAxis("Vertical");

            moveDirection = new Vector3(0, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);

            //animations transitions
            /*if (Input.GetKeyDown(KeyCode.Space)){
                Jump();
            } 
            else*/
            //if (!isIdleCooldown){
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) Walk();
            if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) Run();
            if (moveDirection == Vector3.zero && Input.GetKey(KeyCode.LeftShift)) Run();
            if (moveDirection == Vector3.zero) Idle();
                moveDirection *= moveSpeed;
            //}  
        }

        controller.Move(moveDirection * Time.deltaTime);

        //velocity.y = gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        //animator.SetInteger("Transition",1);
        animator.SetBool("Idle", true);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
    }

    private void Walk()
    {
        //diminuir a velocidade suavemente
        if (moveSpeed > walkSpeed) {
            Debug.Log(Time.deltaTime);
            moveSpeed = moveSpeed - 1;
        }
        else moveSpeed = walkSpeed;

        //animator.SetInteger("Transition",2);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Walk", true);
    }
    private void Run()
    {
        //aumentar a velocidade suavemente
        if (moveSpeed == walkSpeed) {
            moveSpeed = moveSpeed + 1;
        }
        else moveSpeed = runSpeed;

        //animator.SetInteger("Transition",3);
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);
    }

    public void SetActivePlayerMoviment(bool value){
        activePlayer = value;
    }

    /*private void Jump()
    {
        moveSpeed = 0;

        // reset y velocity
        animator.SetInteger("Transition",4);

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        isIdleCooldown = true;
        Invoke(nameof(CoolDownAnimation), coolDownJumpTime);
    }

    private void CoolDownAnimation(){
        isIdleCooldown = false;
    }*/
  
}
