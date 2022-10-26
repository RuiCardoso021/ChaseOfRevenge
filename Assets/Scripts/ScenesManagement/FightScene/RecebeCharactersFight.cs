using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecebeCharactersFight : MonoBehaviour
{
    public GameObject spawnPointPlayer;
    public GameObject spawnPointEnemy;
    private bool activeMovimentPlayer = false;
    private GameObject objectPrefab;
    private GameObject _spawnedObject;

    private void Start()
    {
        objectPrefab = GameObject.Find("receivedObject");
        GameObject player = GameObject.Find("Character_Player");
        player.GetComponent<PlayerMovement>().SetActivePlayerMoviment(!activeMovimentPlayer);
        player.transform.position = Vector3.zero;
        player.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
        GameObject enemy = GameObject.Find("Enemy");
        enemy.transform.position = spawnPointEnemy.transform.position;
        //objectPrefab.SetActive(false);
        //Destroy(GameObject.Find("receivedObject"));



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
