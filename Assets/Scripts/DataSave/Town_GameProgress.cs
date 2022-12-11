using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Town_GameProgress : PlayerPrefsData
{
    public static Town_GameProgress instance;
    public GameObject Player;
    public GameObject SpawnPoint;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Player == null) Player = GameObject.Find(Global.findPlayer);
    }

    public void SavePosAndRotPlayer()
    {
        if (Player != null)
        {
            SaveVector3("PlayerPosition", Player.transform.position);
            SaveQuaternion("PlayerRotation", Player.transform.rotation);
        }
    }

    public void LoadPosAndRotPlayer()
    {
        Vector3 position;
        Quaternion rotation;
        if (SpawnPoint != null)
        {
            position = LoadVector3("PlayerPosition");
            rotation = LoadQuaternion("PlayerRotation");
            if (position != Vector3.zero && rotation != new Quaternion(0f,0f,0f,0f))
            {
                SpawnPoint.transform.position = position;
                SpawnPoint.transform.rotation = rotation;
            }
        }
    }

    
}
