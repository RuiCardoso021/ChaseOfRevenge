using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject thePlayer;

    public float groundDrag;
    public float playerHeight;
    public LayerMask Ground;
    public Material RuningMaterial;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private Animator animator;
    private bool isGrounded;
    private CharacterController controller;
    private float moveSpeed;

    [SerializeField] private GameObject _3dCameraObject;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private bool activePlayer;

    private void Start()
    {
        moveSpeed = walkSpeed;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        SetMovementMode(false);

        if (activePlayer){
            _3dCameraObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else {
            if (_3dCameraObject != null)
                _3dCameraObject.SetActive(false);
        }
    }

    void Update()
    {
        if (activePlayer) Move();
    }

    private void SetMovementMode(bool isRuning)
    {
        if (isRuning)
        {
            RuningMaterial.SetFloat("_MotionBlurStrength", 0.8f);
            RuningMaterial.SetFloat("_BlurAmount", 0.8f);
        }
        else
        {
            RuningMaterial.SetFloat("_MotionBlurStrength", 0);
            RuningMaterial.SetFloat("_BlurAmount", 0);
        }
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        SetMovementMode(false);

        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, Ground);
        
        if (isGrounded && velocity.y < 0)
        {
            if (velocity.y < 0) velocity.y = 0f;
        }

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift) && moveZ > 0) Walk();
        if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift) && moveZ > 0) Run();
        if (moveDirection == Vector3.zero) Idle();

        moveDirection *= moveSpeed;

        //if (moveDirection != Vector3.zero)
        //{
        //    if (!Input.GetKey(KeyCode.LeftShift))
        //        animator.SetInteger("Transition", 1);
        //    transform.forward = Vector3.Slerp(transform.forward, moveDirection.normalized, Time.deltaTime * moveSpeed*2);
        //}

        //velocity.y += gravity;

        if (moveZ > 0)
        {
            controller.Move(moveDirection * Time.deltaTime);
            controller.Move(velocity * Time.deltaTime);         
        }
    }

    private void Idle()
    {
        animator.SetInteger("Transition", 0);
    }

    private void Walk()
    {
        //diminuir a velocidade suavemente
        if (moveSpeed > walkSpeed) {
            moveSpeed = moveSpeed - 1;
        }
        else moveSpeed = walkSpeed;

        animator.SetInteger("Transition", 1);
    }
    private void Run()
    {
        SetMovementMode(true);
        //aumentar a velocidade suavemente
        if (moveSpeed == walkSpeed) {
            moveSpeed = moveSpeed + 1;
        }
        else moveSpeed = runSpeed;

        animator.SetInteger("Transition",2);   
    }

    public void SetActivePlayerMoviment(bool value){
        activePlayer = value;
        if (value == false) _3dCameraObject.SetActive(false);
        else _3dCameraObject.SetActive(true);
    }
}
