using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerSpawner : MonoBehaviour
{
    public Enemy_Prefab Boss;
    public GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false);
    }

    private void Update()
    {
        // Check if the boss is dead
        if (Boss.enemyIsDead == true)
        {
            // If the boss enemy has been destroyed, enable the win panel
            StartCoroutine(ShowWinPanel());
        }
    }
    IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(2);
        winPanel.SetActive(true);
    }
}
