using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


public class RecebeGameObject : MonoBehaviour
{
    public GameObject[] spawnPoint;
    [SerializeField] private bool activeMovimentPlayer = false;
    private GameObject _player;
    private GameObject objectPrefab;
    private GameObject _spawnedObject;

    private void Start()
    {
        _player = GameObject.Find("Character_Player");
        objectPrefab = GameObject.Find("receivedObject");
        objectPrefab.SetActive(false);

    }

    private void Update()
    {
        if (_spawnedObject == null)
        {
            if (_player != null)
            {
                for (int i = 0; i < objectPrefab.transform.childCount; i++)
                {
                    GameObject child = objectPrefab.transform.GetChild(i).gameObject;
                    
                    _spawnedObject = Instantiate(getCharacterPrefab(child), spawnPoint[i].transform.position, Quaternion.identity);
                    if(_spawnedObject.GetComponent<Character_cls>().ClassType != "Enemy")
                        _spawnedObject.name = "Character_Player";
                }

                if (objectPrefab != null) Destroy(objectPrefab, 3f);
            }
        }

    }

    public GameObject getCharacterPrefab(GameObject gm)
    {
        string classType = gm.GetComponent<Character_cls>().ClassType;

        switch (classType)
        {
            case "Sorceress":
                gm = Resources.Load("Prefabs/Magus Raven") as GameObject;
                gm.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                break;
            case "war":
                gm = Resources.Load("Prefabs/Miles Raven") as GameObject;
                gm.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                break;
            case "ARCH":
                gm = Resources.Load("Prefabs/Flora Raven") as GameObject;
                gm.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                break;


        }

        return gm;
    }
}
