using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckEnemiesDead : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject winPanel;
    bool validate = false;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);

        for (int i = 0; i < transform.childCount; i++)
        {         
            GameObject child = transform.GetChild(i).gameObject;
            Enemy_Prefab enemyPrefab = child.GetComponent<Enemy_Prefab>();
            if (enemyPrefab != null)
            {
                if (SaveGameProgress.instance.CheckIfEnemieIsDead(enemyPrefab.id))
                {
                    DesativeEnemy(child);
                }
            }
        }
    }

    public void DesativeEnemy(GameObject child)
    {
        Destroy(child.GetComponent<EnemyMoviment_Prefab>());
        Destroy(child.GetComponent<EnemiesInterecter>());
        Destroy(child.GetComponent<CanvasIntercterEnemy_Prefab>());
        Destroy(child.GetComponent<CapsuleCollider>());
        child.GetComponent<Animator>().SetInteger("Transition", 4);
    }
    // Update is called once per frame
    void Update()
    {
        if (boss != null && !validate)
        {
            Enemy_Prefab enemyPrefab = boss.GetComponent<Enemy_Prefab>();
            if (enemyPrefab != null)
            {
                if (SaveGameProgress.instance.CheckIfEnemieIsDead(enemyPrefab.id))
                {
                    DesativeEnemy(boss);
                    winPanel.SetActive(true);
                    validate = true;
                }
            }
        }
    }
}
