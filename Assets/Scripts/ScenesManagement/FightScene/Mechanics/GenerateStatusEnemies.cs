using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStatusEnemies : MonoBehaviour
{
    public GameObject[] EnemyStatusDashBoard;
    private GameObject _content;
    private bool validate;

    private void Start()
    {
        validate = true;
        _content = GameObject.Find("Content_EnemyStatus");
    }

    public void Update()
    {
        //Inicialization vars and instancies;
        Inicialization();


        //update Life
        UpdateHealth();




    }

    private void Inicialization()
    {
        //if (ManagerGameFight.Instance.PermissedExecute && validate)
        //{
        //    EnemyStatusDashBoard = new GameObject[ManagerGameFight.Instance.Manager.CharactersOnFight.Length];
        //    GameObject enemyStatusTemp = Resources.Load(Global.linkToEnemyStatus) as GameObject;
        //
        //    if (enemyStatusTemp != null && ManagerGameFight.Instance.Manager.CharactersICanAttack != null)
        //    {
        //        for (int i = 0; i < ManagerGameFight.Instance.Manager.CharactersICanAttack.Length; i++)
        //        {
        //            //Enemy status dashboard
        //            if(ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Enemy_Prefab>() != null)
        //            {
        //                EnemyStatusDashBoard[i] = Instantiate(enemyStatusTemp, _content.transform);
        //                EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().MaxLife = ManagerGameFight.Instance.Manager.CharactersICanAttack[i].GetComponent<Enemy_Prefab>().Health;
        //                EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().Name = ManagerGameFight.Instance.Manager.CharactersICanAttack[i].GetComponent<Enemy_Prefab>().Name;
        //
        //            }    
        //        }
        //        validate = false;
        //    }
        //
        //    
        //}
    }

    private void UpdateHealth()
    {
        //if (!validate)
        //{
        //    for (int i = 0; i < ManagerGameFight.Instance.Manager.CharactersICanAttack.Length; i++)
        //    {
        //        if (ManagerGameFight.Instance.Manager.CharactersOnFight[i] != null)
        //        {
        //            if (ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Enemy_Prefab>() != null)
        //            {
        //                EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().health = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Enemy_Prefab>().Health;
        //                EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().Name = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Enemy_Prefab>().Name;
        //            }
        //        } 
        //    }
        //}
    }
}
