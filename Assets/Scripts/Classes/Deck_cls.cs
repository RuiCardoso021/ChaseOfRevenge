using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck{
    public Card[] cards;
    public int TotalCards(){
        return cards.Length;
    }
}