using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    Enemy_Prefab enemy;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.Health <= 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Dead", true);
        }
    }
}
