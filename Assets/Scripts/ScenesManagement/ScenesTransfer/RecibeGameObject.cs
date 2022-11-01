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

    private Global global;
    
    private void Start()
    {
        global = new Global();
        Inicialization();
    }

    private void Update()
    {
        getComponentsOtherScene();

    }

    public void Inicialization()
    {
        _player = GameObject.Find(global.findPlayer);
        ObjectPrefab = GameObject.Find(global.playerPrefab);
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

                if (SpawnedObject.GetComponent<Character_cls>().ClassType != global.findEnemy)
                {
                    SpawnedObject.name = global.findPlayer;
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
            case var value when value == global.playerMageName:
                gm = Resources.Load(global.linkToMagus) as GameObject;
                break;
            case var value when value == global.playerWarriorName:
                gm = Resources.Load(global.linkToMiles) as GameObject;
                break;
            case var value when value == global.playerArcherName:
                gm = Resources.Load(global.linkToFlora) as GameObject;
                break;
        }

        return gm;
    }
}
