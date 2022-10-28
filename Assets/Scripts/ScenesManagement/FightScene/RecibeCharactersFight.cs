using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecibeCharactersFight: RecibeGameObject
{
    public GameObject[] HealthBar;
    private void Start()
    {
        Inicialization();
        HealthBar = new GameObject[indexCounter];
    }

    // Update is called once per frame
    void Update()
    {
        getComponentsOtherScene();

        if (HealthBar[0] == null)
        {
            GameObject healBarTemp = Resources.Load("FightSceneComponents/HealthBar") as GameObject;
        
            if (healBarTemp != null)
            {
                for (int i = 0; i < indexCounter; i++)
                {
                    HealthBar[i] = Instantiate(healBarTemp, SpawnerList[i].transform.position + new Vector3(0,2.4f, 0), Quaternion.identity);

                    HealthBar[i].GetComponent<HealthBar_Prefab>().MaxLife = SpawnerList[i].GetComponent<Character_cls>().Health;
                }
            }
            
        }
        
    }
}
