﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyMoviment_Prefab : MonoBehaviour
{
    GameObject player;
    Vector3 moveDirect;
    CharacterController controller;
    Animator animator;
    Vector3 firstPosition;
    Vector3 velocity;
    CanvasIntercterEnemy_Prefab canvasinterct;
    bool backToPosition = true;

    [SerializeField] float speed = 2;
    [SerializeField] float radius = 5;

    private void Start()
    {
        firstPosition = transform.position;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        canvasinterct = GetComponent<CanvasIntercterEnemy_Prefab>();
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
                if (!backToPosition)
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

        if (Vector3.Distance(firstPosition, player.transform.position) < radius + 2f && backToPosition)
        {
            //detect player on range + 2f, apply rotation from player
            moveDirect = transform.position - player.transform.position;
        }
        if (Vector3.Distance(firstPosition, player.transform.position) < radius)
        {
            //if detect player on range, move to player
            moveDirect = player.transform.position - transform.position;
            canvasinterct.setAtiveCanvasLvl = true;
            backToPosition = false;

            velocity = moveDirect * speed;
            velocity.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), (speed * 2) * Time.deltaTime);
        }
        else
        {
            //move to first position
            moveDirect = firstPosition - transform.position;
            canvasinterct.setAtiveCanvasLvl = false;
            if (Vector3.Distance(firstPosition, transform.position) <= 0.6f)
                backToPosition = true;
            else backToPosition = false;

            velocity = moveDirect * speed;
            velocity.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), (speed * 2) * Time.deltaTime);
        }


        IEnumerator Dead()
        {
            animator.SetInteger("Transition", 4);
            yield return new WaitForSeconds(1.5f);
            GameObject _effect = Instantiate(Resources.Load(Global.linkToDeadEffect) as GameObject, 
                                             transform.position, 
                                             Quaternion.identity);
            Destroy(gameObject);
        }

    }
   
}
