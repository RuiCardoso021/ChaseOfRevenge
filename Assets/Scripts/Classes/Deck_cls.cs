using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck {
    public Card[] cards;

    public Deck() { }

    public void GetInicialCards(string classType)
    {
        List<Card> inventoryCards = new List<Card>();

        foreach (Card card in cards)
        {
            if (card.type == classType || card.type == Global.universalCard)
            {
                inventoryCards.Add(card);
            }
        }
        cards = inventoryCards.ToArray();

    }

    public void AddCard(Card data)
    {
        Array.Resize(ref cards, cards.Length + 1);
        cards[cards.Length - 1] = new Card(data);
    }

    
}