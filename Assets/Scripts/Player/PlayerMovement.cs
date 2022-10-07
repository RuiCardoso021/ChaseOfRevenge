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

    private int speed = 150;
    private float jumpHeight = 3.9f;

    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            thePlayer.GetComponent<Animator>().SetBool("Idle", false);
            thePlayer.GetComponent<Animator>().SetBool("Walk", true);
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * jumpHeight;
            thePlayer.transform.Rotate(0, horizontalMove, 0);
            thePlayer.transform.Translate(0, 0, verticalMove);
        }
        else
        {
            isMoving = false;
            thePlayer.GetComponent<Animator>().SetBool("Walk", false);
            thePlayer.GetComponent<Animator>().SetBool("Idle", true);
        }
    }
}
