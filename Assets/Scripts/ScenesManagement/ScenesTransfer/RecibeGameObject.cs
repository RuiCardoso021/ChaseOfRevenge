using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using Unity.VisualScripting;

public class RecibeGameObject : MonoBehaviour
{
    private const int MAX_CHARACTERS_SPAWN = 4;

    public static RecibeGameObject Instance;
    private GameObject _player;
    public GameObject[] spawnPoint;
    public bool activeMovimentPlayer = false;
    [HideInInspector] public GameObject[] SpawnerList;
    [HideInInspector] public GameObject ObjectPrefab;
    [HideInInspector] public GameObject SpawnedObject;
    [HideInInspector] public int spawnEnemiesCount = 2;

    
    private void Start()
    {
        Instance = this;
        Inicialization();
    }

    private void Update()
    {
        getComponentsOtherScene();

    }

    public void Inicialization()
    {
        _player = GameObject.Find(Global.findPlayer);
        ObjectPrefab = GameObject.Find(Global.recivedObjects);
        SpawnerList = new GameObject[MAX_CHARACTERS_SPAWN];
        ObjectPrefab.SetActive(false);
    }

    public void getComponentsOtherScene()
    {
        if (SpawnedObject == null && _player != null)
        {
            for (int i = 0; i < ObjectPrefab.transform.childCount; i++)
            {
                GameObject child = ObjectPrefab.transform.GetChild(i).gameObject;

                if (child.name == Global.dataTransfer) { 
                    GameObject Data = Instantiate(child); 
                    Data.name = Global.dataTransfer; 
                }
                else if (IsFriend(child.GetComponent<Character_cls>()))
                {
                    SpawnedObject = Instantiate(getCharacterPrefab(child), spawnPoint[i].transform.position, Quaternion.identity);
                    SpawnedObject.name = Global.findPlayer;
                    SpawnedObject.GetComponent<PlayerMovement>().SetActivePlayerMoviment(activeMovimentPlayer);
                    SpawnedObject.GetComponent<Character_cls>().myDeck = _player.GetComponent<Character_cls>().myDeck;
                    SpawnerList[i] = SpawnedObject;
                }
                else
                {
                    EnemyConfig_Prefab enemyConfig = child.GetComponent<EnemyConfig_Prefab>();
                    if (enemyConfig != null)
                    {
                        foreach (GameObject item in enemyConfig.Teammates)
                        {
                            if (item != null)
                            {
                                SpawnedObject = Instantiate(getCharacterPrefab(child), spawnPoint[i].transform.position, Quaternion.identity);
                                SpawnerList[i] = SpawnedObject;
                                i++;
                            }
                                    
                        }
                    }
                }

            }

            if (ObjectPrefab != null) Destroy(ObjectPrefab, 3f);
        }
    }

    //return true if was a friend
    private bool IsFriend(Character_cls character)
    {
        return (character.ClassType == Global.archerPlayerType
            || character.ClassType == Global.warriorPlayerType
            || character.ClassType == Global.magePlayerType
            );
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
            case var value when value == Global.DungeonSkeleton:
                gm = Resources.Load(Global.linkToDungeonSkeleton) as GameObject;
                break;
        }

        return gm;
    }



}
