using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject contentCards2Play;
    [SerializeField] private GameObject contentInventory;
    public Deck deck;
    public TextAsset jsonFile;

    public List<GameObject> cards2play = new List<GameObject>();
    //public Deck cardsOnInventory = new Deck();
    public GameObject cardGameObject;
    public GameObject Player;

    private void Start()
    {
        deck = Player.GetComponent<Character_Prefab>().myDeck;
        //cardsOnInventory.cards = new Card[200];
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FirstInventory();
    }

    private void Update()
    {
        Inventory inventory = GetComponent<Inventory>();
        if(inventory != null && inventory.isOpen)
            ChangeCardsInInventory();
    }

    // primeira lista com as cartas todas
    public void FirstInventory()
    {
        GameObject gmTemp;

        foreach (Card card in deck.cards)
        {
            if (card != null)
            {
                gmTemp = Instantiate(cardGameObject, Vector3.zero, Quaternion.identity);
                gmTemp.AddComponent<InventoryCard_cls>();
                gmTemp.GetComponent<Card_Prefab>().dataCard = card;
                gmTemp.transform.parent = contentCards2Play.transform;

                cards2play.Add(gmTemp);
            }
        }
    }

    // escolha das cartas para levar para a fight
    public void ChangeCardsInInventory()
    {
        foreach (GameObject go in cards2play)
        {
            if (go != null)
            {
                if (go.GetComponent<InventoryCard_cls>().transferItemToInventory)
                    go.transform.parent = contentInventory.transform;
                
                else
                    go.transform.parent = contentCards2Play.transform;     
            }
        }
    }



    public void saveDeck()
    {
        CardPref.instance.saveDeckPref(deck, 1);
    }

    public void getDeckAgain()
    {
        deck = CardPref.instance.LoadDeckPref(1);
    }
}
