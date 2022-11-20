using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class HistoricGameFight_cls
{
    public ManagerGameFight_cls ManagerGameFigth;
    public Character_Prefab Character;
    public List<Card> ListCards;
    public int round;

    public HistoricGameFight_cls()
    {
        ManagerGameFigth = new ManagerGameFight_cls();
        Character = new Character_Prefab();
        ListCards = new List<Card>();
    }

    
}
