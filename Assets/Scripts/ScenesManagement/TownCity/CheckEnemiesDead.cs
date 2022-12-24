using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckEnemiesDead : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
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
        
    }
}
