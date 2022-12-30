using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerSpawner : MonoBehaviour
{
    private bool isSpawned = false;
    public GameObject bossSpawner;
    public GameObject Boss;
    public GameObject winPanel;

    void Start()
    {
        // Disable the win panel and boss enemy at the start of the game
        winPanel.SetActive(false);
    }

    private void Update()
    {
        // Check if the boss enemy has been destroyed
        if (isSpawned == true && Boss == null)
            // If the boss enemy has been destroyed, enable the win panel
            winPanel.SetActive(true);
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
