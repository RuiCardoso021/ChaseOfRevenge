using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using Unity.VisualScripting;

public class RecibeGameObject : MonoBehaviour
{
    private GameObject _player;
    public GameObject[] spawnPoint;
    public bool activeMovimentPlayer = false;
    [HideInInspector] public GameObject[] SpawnerList;
    [HideInInspector] public GameObject ObjectPrefab;
    [HideInInspector] public GameObject SpawnedObject;
    [HideInInspector] public int indexCounter;
    
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
        ObjectPrefab = GameObject.Find("receivedObject");
        indexCounter = ObjectPrefab.transform.childCount;
        SpawnerList = new GameObject[indexCounter];
        ObjectPrefab.SetActive(false);
    }

    public void getComponentsOtherScene()
    {
        if (SpawnedObject == null && _player != null)
        {
            for (int i = 0; i < indexCounter; i++)
            {
                GameObject child = ObjectPrefab.transform.GetChild(i).gameObject;

                SpawnedObject = Instantiate(getCharacterPrefab(child), spawnPoint[i].transform.position, Quaternion.identity);

                if (SpawnedObject.GetComponent<Character_cls>().ClassType != "Enemy")
                {
                    SpawnedObject.name = "Character_Player";
                    SpawnedObject.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                    SpawnedObject.GetComponent<Character_cls>().myDeck = _player.GetComponent<Character_cls>().myDeck;
                }

                SpawnerList[i] = SpawnedObject;

            }

            if (ObjectPrefab != null) Destroy(ObjectPrefab, 3f);
        }
    }

    private GameObject getCharacterPrefab(GameObject gm)
    {
        string classType = gm.GetComponent<Character_cls>().Name;

        switch (classType)
        {
            case "Magus Raven":
                gm = Resources.Load("Character_Player/Magus Raven") as GameObject;
                break;
            case "Miles Raven":
                gm = Resources.Load("Character_Player/Miles Raven") as GameObject;
                break;
            case "Flora Raven":
                gm = Resources.Load("Character_Player/Flora Raven") as GameObject;
                break;
        }

        return gm;
    }
}
