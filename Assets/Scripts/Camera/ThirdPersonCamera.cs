using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;

    // The minimum and maximum zoom distance
    public float minZoomDistance = 1.0f;
    public float maxZoomDistance = 10.0f;

    // The current zoom distance
    private float zoomDistance;

    // The speed at which the camera will zoom
    public float zoomSpeed = 5.0f;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        //orientation.forward = viewDir.normalized;
        transform.LookAt(playerObj);

        // Zoom in or out using the mouse wheel
        zoomDistance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomDistance = Mathf.Clamp(zoomDistance, minZoomDistance, maxZoomDistance);

        // rotate orientation
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            //rotate player
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
