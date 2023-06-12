using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnblockMapAreas : MonoBehaviour
{
    public GameObject[] areasBlocker;
    //public GameObject panelWinGame;
    public int wins;

    void Start()
    {
        wins = SaveGameProgress.instance.getWins();
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
                if (wins >= item.GetComponent<ObjectiveDesblock>().objective)
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
