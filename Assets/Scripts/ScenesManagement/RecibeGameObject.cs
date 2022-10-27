using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


public class RecibeGameObject : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public bool activeMovimentPlayer = false;
    public GameObject _player;
    public GameObject objectPrefab;
    public GameObject _spawnedObject;

    private void Start()
    {
        Inicialization();

    }

    private void Update()
    {
        getComponentsOtherScene();

    }

    public void Inicialization()
    {
        _player = GameObject.Find("Character_Player");
        objectPrefab = GameObject.Find("receivedObject");
        objectPrefab.SetActive(false);
    }

    public void getComponentsOtherScene()
    {
        if (_spawnedObject == null)
        {
            if (_player != null)
            {
                for (int i = 0; i < objectPrefab.transform.childCount; i++)
                {
                    GameObject child = objectPrefab.transform.GetChild(i).gameObject;

                    _spawnedObject = Instantiate(getCharacterPrefab(child), spawnPoint[i].transform.position, Quaternion.identity);
                    if (_spawnedObject.GetComponent<Character_cls>().ClassType != "Enemy")
                        _spawnedObject.name = "Character_Player";
                }

                if (objectPrefab != null) Destroy(objectPrefab, 3f);
            }
        }
    }

    private GameObject getCharacterPrefab(GameObject gm)
    {
        string classType = gm.GetComponent<Character_cls>().ClassType;

        switch (classType)
        {
            case "Sorceress":
                gm = Resources.Load("Character_Player/Magus Raven") as GameObject;
                gm.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                break;
            case "war":
                gm = Resources.Load("Character_Player/Miles Raven") as GameObject;
                gm.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                break;
            case "ARCH":
                gm = Resources.Load("Character_Player/Flora Raven") as GameObject;
                gm.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                break;
        }

        return gm;
    }
}
