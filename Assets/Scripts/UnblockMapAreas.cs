using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnblockMapAreas : MonoBehaviour
{
    public GameObject[] areasBlocker;
    //public GameObject panelWinGame;
    private int wins;
    
    void Start()
    {
        wins = BlockSave.instance.getWins();
    }

    private void Update()
    {
        UnblockArea();
    }

    public void UnblockArea()
    {

        foreach (GameObject item in areasBlocker)
        {
            if (item != null)
            {
                if (wins == item.GetComponent<ObjectiveDesblock>().objective)
                {
                    if (item.activeSelf)
                    {
                        item.SetActive(false);
                    }               
                }
            }
        }        
    }
}
