using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Save_BlockSave : PlayerPrefsData
{
    public static Save_BlockSave instance;

    private void Start()
    {
        instance = this;
    }

    public void saveWins()
    {
        int wins = getWins();
        wins++;
        SaveInt("wins", wins);
    }

    public int getWins()
    {
        int wins = 0;
        if (LoadInt("wins") != 0) wins = LoadInt("wins");
        return wins;
    }

    public void SaveWinsIfClose()
    {
        int wins = getWins();
        sceneID = 1;
        SaveInt("wins", wins);
        sceneID = 0;
    }

    public int getWinsIfClose()
    {
        sceneID = 1;
        int wins = 0;
        if (LoadInt("wins") != 0) wins = LoadInt("wins");
        sceneID = 0;
        return wins;
    }
}