using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HistoricGameFight_cls
{
    public ManagerGameFigth_cls ManagerGameFigth;
    public List<Card> ListCards;
    public int round;

    public HistoricGameFight_cls()
    {
        ManagerGameFigth = new ManagerGameFigth_cls();
        ListCards = new List<Card>();
    }

    
}
