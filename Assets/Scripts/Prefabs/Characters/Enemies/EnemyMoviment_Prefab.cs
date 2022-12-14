using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMoviment_Prefab : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
    }

    private void Update()
    {
        if (player == null)
            player = GameObject.Find(Global.findPlayer);

        if (player != null)
        {
            transform.LookAt(player.transform);
        }

    }
   
}
