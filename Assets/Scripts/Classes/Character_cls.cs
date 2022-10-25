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
        //Deck newdeck = new Deck();
        myDeck = JsonUtility.FromJson<Deck>(jsonFile.text);
        //int index = 0;
        //
        //foreach(Card card in newdeck.cards)
        //{
        //    if (card.type == ClassType || card.type == "UN")
        //    {
        //        myDeck.cards[index] = card;
        //        index++;
        //    }
        //}
    }

}

