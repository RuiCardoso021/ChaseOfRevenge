using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSave : PlayerPrefsData
{
    public static PlayerSave instance;
    public GameObject Player;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Player == null) Player = GameObject.Find(Global.findPlayer);
        //LoadPosAndRotPlayer();
    }

    public void SavePosAndRotPlayer()
    {
        if (Player != null)
        {
            SaveVector3("PlayerPosition", Player.transform.localPosition);
            SaveQuaternion("PlayerRotation", Player.transform.localRotation);
        }
    }

    public void LoadPosAndRotPlayer()
    {
        Vector3 position;
        Quaternion rotation;
        if (Player != null)
        {
            position = LoadVector3("PlayerPosition");
            rotation = LoadQuaternion("PlayerRotation");
            if (position != null && rotation != null)
            {
                Player.transform.localPosition = position;
                Player.transform.localRotation = rotation;
            }
        }
    }

    
}
