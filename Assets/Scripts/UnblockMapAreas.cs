using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnblockMapAreas : MonoBehaviour
{
    //public static UnblockMapAreas Instance;
    public GameObject[] areasBlocker;
    //public GameObject areaBlocker2;
    //public GameObject areaBlocker3;
    //public GameObject panelWinGame;
    //public GameObject bossSpawner;
    //public GameObject Boss;
    //[SerializeField] private int secondObjective;
    //[SerializeField] private int thirdObjective;
    private int wins;
    //private bool isSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (Instance != null)
        //{
        //    Destroy(this);
        //    //Destroy(areaBlocker2);
        //    //Destroy(areaBlocker3);
        //    Debug.Log("destroy");
        //    return;
        //}
        //Instance = this;
        wins = BlockSave.instance.getWins();
        //DontDestroyOnLoad(areaBlocker2);
        //DontDestroyOnLoad(areaBlocker3);
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
        //if (wins == firstObjective)
        //{
            //if (areaBlocker1 != null)
            //{
            //    areaBlocker1.SetActive(false);
            //}               
        //}
        //else if (wins == secondObjective)
        //{
        //    if (areaBlocker2 != null)
        //    {
        //        areaBlocker2.SetActive(false);
        //    }
        //}          
        //else if (wins == thirdObjective)
        //{
        //    if (areaBlocker3 != null)
        //    {
        //        areaBlocker3.SetActive(false);
        //    }
        //}          
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bossManager();
        }
    }

    //fazer um trigger collider ao entrar na porta do castelo spawnar o boss
    public void bossManager()
    {
        //if (!isSpawned)
        //    EnemyBossSpawner();
    }

    private void EnemyBossSpawner()
    {
        //Instantiate(Boss, bossSpawner.transform.position, bossSpawner.transform.rotation);
        //isSpawned = true;
    }
}
