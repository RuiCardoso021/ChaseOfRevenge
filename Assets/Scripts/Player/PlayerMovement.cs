using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

enum MovementType
{
    RuningFast = 0,
    Running = 1,
    Walk = 2
}

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
    private float? runningTime;
    private float? runningStartTime;
    private float targetValue = 5f;

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
        SetMovementMode(MovementType.Walk);

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

    private void SetMovementMode(MovementType movementType)
    {
        switch (movementType)
        {
            case MovementType.RuningFast:
                RuningMaterial.SetFloat("_MotionBlurStrength", 0.8f);
                RuningMaterial.SetFloat("_BlurAmount", 0.8f);
                break;
            case MovementType.Running:
                RuningMaterial.SetFloat("_MotionBlurStrength", 0.8f);
                RuningMaterial.SetFloat("_BlurAmount", 0.6f);
                break;
            case MovementType.Walk:
                RuningMaterial.SetFloat("_MotionBlurStrength", 0f);
                RuningMaterial.SetFloat("_BlurAmount", 0f);
                break;
            default:
                break;
        }
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        SetMovementMode(MovementType.Walk);

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
        runningStartTime = null;
        runningTime = null;
        animator.SetInteger("Transition", 0);
    }

    private void Walk()
    {
        runningStartTime = null;
        runningTime = null;

        //diminuir a velocidade suavemente
        if (moveSpeed > walkSpeed) {
            moveSpeed = moveSpeed - 1;
        }
        else moveSpeed = walkSpeed;

        animator.SetInteger("Transition", 1);
    }
    private void Run()
    {
        if (runningStartTime == null)
        {
            runningStartTime = Time.time;
            runningTime = 0;
        }
        else if (runningStartTime != null && runningTime < targetValue)
        {
            SetMovementMode(MovementType.RuningFast);
            moveSpeed = runSpeed + 4;
            runningTime = Time.time - runningStartTime;
        }
        else if(runningStartTime != null && runningTime >= targetValue)
        {
            SetMovementMode(MovementType.Running);
            moveSpeed = runSpeed - 4;
        }

        animator.SetInteger("Transition",2);   
    }

    public void SetActivePlayerMoviment(bool value){
        activePlayer = value;
        if (value == false) _3dCameraObject.SetActive(false);
        else _3dCameraObject.SetActive(true);
    }
}
