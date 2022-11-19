using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHealthBar : MonoBehaviour
{
    public GameObject[] HealthBar;
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
        if (ManagerGameFight.Instance.Manager.CharactersOnFight != null && validate)
        {
            HealthBar = new GameObject[ManagerGameFight.Instance.Manager.CharactersOnFight.Length];
            EnemyStatusDashBoard = new GameObject[ManagerGameFight.Instance.Manager.CharactersOnFight.Length];
            GameObject enemyStatusTemp = Resources.Load(Global.linkToEnemyStatus) as GameObject;
            GameObject healthBarTemp = Resources.Load(Global.healthBar) as GameObject;

            if (healthBarTemp != null)
            {
                for (int i = 0; i < HealthBar.Length; i++)
                {
                    //Enemy status dashboard
                    if (ManagerGameFight.Instance.Manager.CharactersOnFight[i] != null)
                    {
                        if(ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().ClassType == Global.findEnemy)
                        {
                            EnemyStatusDashBoard[i] = Instantiate(enemyStatusTemp, _content.transform);
                            EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().MaxLife = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Health;
                            EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().Name = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Name;

                        }
                    
                        //healthBar on player
                        HealthBar[i] = Instantiate(healthBarTemp, ManagerGameFight.Instance.Manager.CharactersOnFight[i].transform.position + new Vector3(0, 2.4f, 0), Quaternion.identity);
                        HealthBar[i].GetComponent<HealthBar_Prefab>().MaxLife = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Health;
                    }
                    
                }
            }

            validate = false;
        }
    }

    private void UpdateHealth()
    {
        if (!validate)
        {
            for (int i = 0; i < HealthBar.Length; i++)
            {
                if (ManagerGameFight.Instance.Manager.CharactersOnFight[i] != null)
                {
                    if (ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().ClassType == Global.findEnemy)
                    {
                        EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().health = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Health;
                        EnemyStatusDashBoard[i].GetComponent<EnemyStatus_Prefab>().Name = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Name;
                    }

                    HealthBar[i].GetComponent<HealthBar_Prefab>().health = ManagerGameFight.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Health;
                } 
            }
        }
    }
}
