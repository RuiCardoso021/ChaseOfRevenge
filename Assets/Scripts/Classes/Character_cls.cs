using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Character_cls : MonoBehaviour
{

    [SerializeField] private TextAsset jsonFile;
    private int _maxMana;

    public float MaxHealth;
    public string Name;
    public int Mana;
    public string ClassType;
    public float Health;
    public Sprite ImageProfile;
    public Deck myDeck;

    private void Start()
    {
        myDeck = new Deck();
        Deck deck = new Deck();     
        deck = JsonUtility.FromJson<Deck>(jsonFile.text);
        List<Card> inventoryCards = new List<Card>();
        MaxHealth = Health;
        _maxMana = Mana;

        foreach (Card card in deck.cards)
        {
            if (card.type == ClassType || card.type == Global.universalCard)
            {
                inventoryCards.Add(card);
            }
        }
        myDeck.cards = inventoryCards.ToArray();
    }


    private void Update()
    {
        HealthValidation();
        ManaValidation();
    }

    private void HealthValidation()
    {
        if (Health < 0) Health = 0;
        if (Health > MaxHealth) Health = MaxHealth;
    }

    private void ManaValidation()
    {
        if (Mana < 0) Mana = 0;
    }

}

