using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlockSave : PlayerPrefsData
{
    public static BlockSave instance;

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
}