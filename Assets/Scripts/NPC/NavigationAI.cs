using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAI : MonoBehaviour
{
    public GameObject Destination;
    NavMeshAgent npcAgent;
    public static bool canInteract;
    //public GameObject Player;
    Character_cls player;

    // Start is called before the first frame update
    void Start()
    {
        npcAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character_Player").GetComponent<Character_cls>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract == true)
        {
            npcAgent.SetDestination(player.transform.position);
        }
        else
        {
            npcAgent.SetDestination(Destination.transform.position);
        }
    }
}
