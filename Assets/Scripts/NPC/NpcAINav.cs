using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAINav : MonoBehaviour
{
    GameObject player;
    Vector3 moveDirect;
    CharacterController controller;
    Animator animator;
    Vector3 firstPosition;
    Vector3 velocity;
    bool backToPosition = true;
    bool colision = false;

    [SerializeField] float speed = 2;
    [SerializeField] float radius = 5;

    private void Start()
    {
        firstPosition = transform.position;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null)
            player = GameObject.Find(Global.findPlayer);

        if (player != null)
        {
            CheckRadius();

            if (controller != null)
            {
                if (!backToPosition && !colision)
                {
                    animator.SetInteger("Transition", 1);
                    controller.Move(velocity * Time.deltaTime);
                }
                else animator.SetInteger("Transition", 0);

            }
            player = null;
        }
    }

    private void CheckRadius()
    {
        if (Vector3.Distance(firstPosition, player.transform.position) < radius)
        {
            //if detect player on range, move to player
            moveDirect = player.transform.position - transform.position;
            backToPosition = false;

            velocity = moveDirect * speed;
            velocity.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), (speed * 2) * Time.deltaTime);
        }
        else
        {
            //move to first position
            moveDirect = firstPosition - transform.position;
            if (Vector3.Distance(firstPosition, transform.position) <= 0.6f)
                backToPosition = true;
            else backToPosition = false;

            velocity = moveDirect * speed;
            velocity.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), (speed * 2) * Time.deltaTime);
        }
    }
}
