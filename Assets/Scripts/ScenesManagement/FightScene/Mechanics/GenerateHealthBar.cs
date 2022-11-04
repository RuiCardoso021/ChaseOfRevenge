using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHealthBar : MonoBehaviour
{
    public GameObject[] HealthBar;
    private bool validate;

    private void Start()
    {
        validate = true;
    }

    public void Update()
    {
        //getComponentsOtherScene();

        if (ManagerGameFigth.Instance.Manager.CharactersOnFight != null && validate)
        {
            HealthBar = new GameObject[ManagerGameFigth.Instance.Manager.CharactersOnFight.Length];
            GameObject healthBarTemp = Resources.Load(Global.healthBar) as GameObject;
        
            if (healthBarTemp != null)
            {
                for (int i = 0; i < HealthBar.Length; i++)
                {
                    HealthBar[i] = Instantiate(healthBarTemp, ManagerGameFigth.Instance.Manager.CharactersOnFight[i].transform.position + new Vector3(0,2.4f, 0), Quaternion.identity);

                    HealthBar[i].GetComponent<HealthBar_Prefab>().MaxLife = ManagerGameFigth.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Health;
                }
            }

            validate = false;
        }

        //update Life
        if (!validate)
        {
            for (int i = 0; i < HealthBar.Length; i++)
            {
                HealthBar[i].GetComponent<HealthBar_Prefab>().health = ManagerGameFigth.Instance.Manager.CharactersOnFight[i].GetComponent<Character_cls>().Health;
            }
        }


    }
}
