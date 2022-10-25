using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecebeGameObject : MonoBehaviour
{
    public GameObject spawnPoint;
    [SerializeField] private bool activeMovimentPlayer = false;
    private GameObject objectPrefab;
    private GameObject _spawnedObject;

    private void Start()
    {
        objectPrefab = GameObject.Find("receivedObject");
        GameObject player = GameObject.Find("Character_Player");
        player.GetComponent<PlayerMovement>().SetActivePlayerMoviment(!activeMovimentPlayer);
        player.transform.position = Vector3.zero;
        player.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
        //objectPrefab.SetActive(false);
        //Destroy(GameObject.Find("receivedObject"));



    }

    private void Update()
    {
        //if (_spawnedObject == null)
        //{   
        //    _spawnedObject = Instantiate(objectPrefab, spawnPoint.transform.position, Quaternion.identity);
        //    _spawnedObject.SetActive(true);
        //
        //    GameObject player = GameObject.Find("Character_Player");
        //    player.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
        //    player.transform.position = Vector3.zero;
        //}
    }
}
