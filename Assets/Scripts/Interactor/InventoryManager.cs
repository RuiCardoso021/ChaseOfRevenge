using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject contentCards2Play;
    [SerializeField] private GameObject contentAllCards;
    private Deck deck;
    public TextAsset jsonFile;

    public List<GameObject> cards2play = new List<GameObject>();
    public Deck cardsOnInventory = new Deck();
    public GameObject cardGameObject;
    public GameObject Player;

    private void Start()
    {
        deck = Player.GetComponent<Character_Prefab>().myDeck;
        cardsOnInventory.cards = new Card[200];
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FirstInventory();
    }

    // primeira lista com as cartas todas
    public void FirstInventory()
    {
        GameObject gmTemp;

        foreach (Card card in deck.cards)
        {
            gmTemp = Instantiate(cardGameObject, Vector3.zero, Quaternion.identity);
            gmTemp.AddComponent<InventoryCard_cls>();
            gmTemp.GetComponent<Card_Prefab>().dataCard = card;
            gmTemp.transform.parent = contentCards2Play.transform;
            gmTemp.GetComponent<InventoryCard_cls>().isActive = true;

            cards2play.Add(gmTemp);
        }
    }

    // escolha das cartas para levar para a fight
    public void ChangeCardsInInventory(GameObject card)
    {
        foreach (GameObject go in cards2play)
        {
            bool validationGo = go.GetComponent<InventoryCard_cls>().isActive;

            if (card == go)
            {
                if (validationGo)
                {
                    go.transform.parent = contentAllCards.transform;
                }
                else
                {
                    go.transform.parent = contentCards2Play.transform;
                }
                go.GetComponent<InventoryCard_cls>().isActive = !go.GetComponent<InventoryCard_cls>().isActive;
            }
        }
    }

    public void saveDeck()
    {
        Deck.saveDeckPref(deck, 1);
    }

    public void getDeckAgain()
    {
        deck = Deck.LoadDeckPref(1);
    }
}
