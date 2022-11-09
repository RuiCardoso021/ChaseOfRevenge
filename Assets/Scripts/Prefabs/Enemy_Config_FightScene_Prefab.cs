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

    void Start()
    {
        ManagerGameFight = GameObject.Find("GamePlay").GetComponent<ManagerGameFight>();
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (ManagerGameFight.Manager != null)
        {
            ManagerGameFight.Manager.NextCharacter = this.gameObject;
            Debug.Log("MANEL");
        }
        Debug.Log("OLA MUNDO");
    }
   

}
