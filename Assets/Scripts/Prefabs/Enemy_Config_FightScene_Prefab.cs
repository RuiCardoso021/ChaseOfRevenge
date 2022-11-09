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
    public GameObject GameObjectSelection;
    public bool checkSelection;

    void Start()
    {
        GameObjectSelection = GameObject.Find("CircleSelection");
        checkSelection = false;
        GameObjectSelection.SetActive(false);
        ManagerGameFight = GameObject.Find("GamePlay").GetComponent<ManagerGameFight>();

    }

    private void Update()
    {
        GameObjectSelection.SetActive(checkSelection);
    }

    private void OnMouseDown()
    {
        if (ManagerGameFight.Manager != null)
        {
            checkSelection = true;
            ManagerGameFight.Manager.NextCharacter = this.gameObject;
        }
    }
   

}
