﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class SaveGameProgress : PlayerPrefsData
{
    public static SaveGameProgress instance;

    private void Awake()
    {
        instance = this;
    }

    public void SavePlayer()
    {
        GameObject Player = GameObject.Find(Global.findPlayer);
        if (Player != null)
        {
            Character_Prefab cp_player = Player.GetComponent<Character_Prefab>();
            if (cp_player != null)
            {
                SaveVector3(VarSaves.Position, Player.transform.position);
                SaveQuaternion(VarSaves.Rotation, Player.transform.rotation);
                SaveString(VarSaves.Class, cp_player.ClassType);
                SaveInt(VarSaves.Mana, cp_player.Mana);
                SaveFloat(VarSaves.Health, cp_player.Health);
            }

        }
    }

    public void LoadPlayer()
    {
        //GameObject player = null;
        GameObject SpawnPoint = GameObject.Find("Play");
        if (SpawnPoint != null)
        {
            Vector3 position = LoadVector3(VarSaves.Position);
            Quaternion rotation = LoadQuaternion(VarSaves.Rotation);
            if (position != Vector3.zero && rotation != new Quaternion(0f, 0f, 0f, 0f))
            {
                SpawnPoint.transform.position = position;
                SpawnPoint.transform.rotation = rotation;
            }

            //player = RecibeGameObject.Instance.getCharacterPlayerPrefab(LoadString(VarSaves.Class));
            //if (player != null)
            //{
            //    Character_Prefab cp_player = player.GetComponent<Character_Prefab>();
            //    cp_player.Mana = LoadInt(VarSaves.Mana);
            //    cp_player.Health = LoadFloat(VarSaves.Health);
            //}
        }
        sceneID = 0;
    }

    public void SavePermissionLoad(bool value)
    {
        SaveBool("PermissionLoad", value);
    }

    public bool GetPermissionLoad()
    {
        bool value = false;
        try
        {
            value = LoadBool("PermissionLoad");
        }
        catch
        {
            value = false;
        }

        return value;
        
    }

    public void SavePosAndRotPlayerIfClose()
    {
        sceneID = 1;
        LoadPlayer();
        sceneID = 0;
    }

    public void LoadPosAndRotPlayerIfClose(){
        LoadPlayer();
        sceneID = 0;
    }

    public void saveWins()
    {
        int wins = getWins();
        wins++;
        SaveInt(VarSaves.Wins, wins);
    }

    public int getWins()
    {
        int wins = 0;
        if (LoadInt(VarSaves.Wins) != 0) wins = LoadInt("wins");
        return wins;
    }

    public void SaveWinsIfClose()
    {
        int wins = getWins();
        sceneID = 1;
        SaveInt(VarSaves.Wins, wins);
        sceneID = 0;
    }

    public int getWinsIfClose()
    {
        sceneID = 1;
        int wins = 0;
        if (LoadInt(VarSaves.Wins) != 0) wins = LoadInt(VarSaves.Wins);
        sceneID = 0;
        return wins;
    }

    public void DeleteProgressGame()
    {
        DeleteVector3(VarSaves.Position);
        DeleteQuaternion(VarSaves.Rotation);
        DeleteBasicKey(VarSaves.Class);
        DeleteBasicKey(VarSaves.Mana);
        DeleteBasicKey(VarSaves.Health);
        DeleteBasicKey(VarSaves.Wins);
        DeleteArrayBasicArray(VarSaves.EnemiesLose);
        DeleteArrayBasicArray(VarSaves.CardsInventory);
    }

    public void SaveEnemiesLose(int id)
    {
        int[] getArrayIDSave = LoadIntArray(VarSaves.EnemiesLose);
        Array.Resize(ref getArrayIDSave, getArrayIDSave.Length + 1);
        getArrayIDSave[getArrayIDSave.Length - 1] = id;
        SaveIntArray(VarSaves.EnemiesLose, getArrayIDSave, getArrayIDSave.Length);
    }

    public bool CheckIfEnemieIsDead(int id)
    {
        int[] getArrayIDSave = LoadIntArray(VarSaves.EnemiesLose);
        bool checkIsDead = false;
        foreach (int value in getArrayIDSave)
        {
            if (value == id) checkIsDead = true;
        }

        return checkIsDead;
    }

    public void SaveCardChest(int id)
    {
        int[] getArrayIDSave = LoadIntArray(VarSaves.CardsInventory);
        Array.Resize(ref getArrayIDSave, getArrayIDSave.Length + 1);
        getArrayIDSave[getArrayIDSave.Length - 1] = id;
        SaveIntArray(VarSaves.CardsInventory, getArrayIDSave, getArrayIDSave.Length);
    }

    private int checkNextPositionToAddArray(int[] array)
    {
        int num = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0) return i;
        }
        return num;
    }

    public bool CheckIfCardChestIsmy(int id)
    {
        int[] getArrayIDSave = LoadIntArray(VarSaves.CardsInventory);
        bool checkIsDead = false;
        foreach (int value in getArrayIDSave)
        {
            if (value == id) checkIsDead = true;
        }

        return checkIsDead;
    }
}
