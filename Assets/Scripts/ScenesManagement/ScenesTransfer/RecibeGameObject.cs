using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using Unity.VisualScripting;

public class RecibeGameObject : MonoBehaviour
{
    public static RecibeCharactersFight Instance;
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
        _player = GameObject.Find(Global.findPlayer);
        ObjectPrefab = GameObject.Find(Global.playerPrefab);
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

                if (SpawnedObject.GetComponent<Character_cls>().ClassType != Global.findEnemy)
                {
                    SpawnedObject.name = Global.findPlayer;
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
            case var value when value == Global.playerMageName:
                gm = Resources.Load(Global.linkToMagus) as GameObject;
                break;
            case var value when value == Global.playerWarriorName:
                gm = Resources.Load(Global.linkToMiles) as GameObject;
                break;
            case var value when value == Global.playerArcherName:
                gm = Resources.Load(Global.linkToFlora) as GameObject;
                break;
        }

        return gm;
    }
}
