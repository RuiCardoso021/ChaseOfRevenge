using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockMapAreas : MonoBehaviour
{
    public static UnblockMapAreas Instance;
    public GameObject areaBlocker1;
    public GameObject areaBlocker2;
    public GameObject areaBlocker3;
    //public GameObject panelWinGame;
    public GameObject bossSpawner;
    public GameObject Boss;

    [SerializeField] private int firstObjective;
    [SerializeField] private int secondObjective;
    [SerializeField] private int thirdObjective;
    private int wins = 0;
    private bool isSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(areaBlocker1);
            Destroy(areaBlocker2);
            Destroy(areaBlocker3);
            Debug.Log("destroy");
            return;
        }

        Instance = this;
        DontDestroyOnLoad(areaBlocker1);
        DontDestroyOnLoad(areaBlocker2);
        DontDestroyOnLoad(areaBlocker3);
    }

    public void FightWinCount()
    {
        if (wins <= thirdObjective)
        {
            wins++;

            UnblockArea();
        }
    }

    public void UnblockArea()
    {
        if (wins == firstObjective)
        {
            if (areaBlocker1 != null)
            {
                areaBlocker1.SetActive(false);
            }               
        }
        else if (wins == secondObjective)
        {
            if (areaBlocker2 != null)
            {
                areaBlocker2.SetActive(false);
            }
        }          
        else if (wins == thirdObjective)
        {
            if (areaBlocker3 != null)
            {
                areaBlocker3.SetActive(false);
            }
        }          
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
        if (!isSpawned)
            EnemyBossSpawner();
    }

    private void EnemyBossSpawner()
    {
        Instantiate(Boss, bossSpawner.transform.position, bossSpawner.transform.rotation);
        isSpawned = true;
    }
}
