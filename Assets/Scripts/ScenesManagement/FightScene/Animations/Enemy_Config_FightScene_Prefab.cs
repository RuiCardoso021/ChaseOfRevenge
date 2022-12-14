using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_Config_FightScene_Prefab : MonoBehaviour
{
    // Start is called before the first frame update
    private ManagerGameFight ManagerGameFight;
    public CircleSelection_Prefab CircleSelection;

    void Start()
    {
        ManagerGameFight = GameObject.Find("GamePlay").GetComponent<ManagerGameFight>();
        CircleSelection = GetComponent<CircleSelection_Prefab>();
    }

    private void OnMouseDown()
    {
        if (Time.timeScale != 0)
        {
            if (ManagerGameFight.Manager != null && !GetComponent<Enemy_Prefab>().enemyIsDead)
            {
                CircleSelection.setActive = true;
                ManagerGameFight.Manager.NextCharacter = this.gameObject;
            }
        }
        
    }
   

}
