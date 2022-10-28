using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class Character_cls : MonoBehaviour
{
    public string Name;
    public int Mana;
    public string ClassType;
    public float Health;
    public Deck myDeck;

    [SerializeField]private TextAsset jsonFile;

    private void Start()
    {
        myDeck = new Deck();
        Deck deck = new Deck();     
        deck = JsonUtility.FromJson<Deck>(jsonFile.text);
        List<Card> inventoryCards = new List<Card>();

        foreach (Card card in deck.cards)
        {
            if (card.type == ClassType || card.type == "UN")
            {
                inventoryCards.Add(card);
            }
        }
        myDeck.cards = inventoryCards.ToArray();
    }

}

