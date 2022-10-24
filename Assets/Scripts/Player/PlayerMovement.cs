using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject thePlayer;


    public Rigidbody rb;
    public float groundDrag;
    public float playerHeight;
    public LayerMask Ground;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private Animator animator;
    private bool isGrounded;
    private CharacterController controller;

    [SerializeField] private GameObject _3dCameraObject;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private bool activePlayer;

    private void Start()
    {    
        if (activePlayer){
            _3dCameraObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            controller = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            animator = GetComponentInChildren<Animator>();
        }else {
            if (_3dCameraObject != null)
                _3dCameraObject.SetActive(false);
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

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) Walk();
        if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) Run();
        if (moveDirection == Vector3.zero) Idle();
            moveDirection *= moveSpeed;
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
        if (value == false) _3dCameraObject.SetActive(false);
    }
}
