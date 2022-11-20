using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAINav : MonoBehaviour
{
    public GameObject Destination;
    NavMeshAgent npcAgent;
    public static bool canInteract;
    //public GameObject Player;
    Character_Prefab player;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        npcAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character_Player").GetComponent<Character_Prefab>();
    }

    // Update is called once per frame
    void Update()
    {
        npcAgent.SetDestination(Destination.transform.position);
            
        animator.SetBool("Walk", true);
        animator.SetBool("Idle", false);
    }
}
