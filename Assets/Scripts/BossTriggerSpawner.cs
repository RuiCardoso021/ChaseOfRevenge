using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerSpawner : MonoBehaviour
{
    private bool isSpawned = false;
    public GameObject bossSpawner;
    public GameObject Boss;

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
