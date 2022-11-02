using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecibeCharactersFight: RecibeGameObject
{
    public GameObject[] HealthBar;


    private void Start()
    {
        Instance = this;
        Inicialization();
        HealthBar = new GameObject[indexCounter];
    }

    void Update()
    {
        getComponentsOtherScene();

        if (HealthBar[0] == null)
        {
            GameObject healthBarTemp = Resources.Load(Global.healthBar) as GameObject;
        
            if (healthBarTemp != null)
            {
                for (int i = 0; i < indexCounter; i++)
                {
                    HealthBar[i] = Instantiate(healthBarTemp, SpawnerList[i].transform.position + new Vector3(0,2.4f, 0), Quaternion.identity);

                    HealthBar[i].GetComponent<HealthBar_Prefab>().MaxLife = SpawnerList[i].GetComponent<Character_cls>().Health;
                }


            }
            
        }

        //update Life
        if (HealthBar[0] != null && SpawnerList[0] != null)
        {
            for (int i = 0; i < HealthBar.Length; i++)
            {
                HealthBar[i].GetComponent<HealthBar_Prefab>().health = SpawnerList[i].GetComponent<Character_cls>().Health;
            }
        }


    }
}
