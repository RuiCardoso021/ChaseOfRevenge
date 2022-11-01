using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject content;
    private Deck deck;
    public TextAsset jsonFile;

    public List<GameObject> allCards = new List<GameObject>();
    public List<InventoryCard_cls> cards2play = new List<InventoryCard_cls>();
    public GameObject cardGameObject;
    public InventoryCard_cls cardChosen;

    private GameObject _player;

    private Global global;

    private void Start()
    {
        global = new Global();
        _player = GameObject.Find(global.findPlayer);
        deck = _player.GetComponent<Character_cls>().myDeck;

        FirstInventory();       
        getCardsToInventory();
    }

    private void Update()
    {
        
    }

    private void getCardsToInventory()
    {
        GameObject gmTemp;

        foreach(InventoryCard_cls card in cards2play)
        {
            //generate card
            gmTemp = Instantiate(cardGameObject, Vector3.zero, Quaternion.identity);
            gmTemp.GetComponent<Card_Prefab>().dataCard = card.card;
            gmTemp.GetComponent<Card_Prefab>().setDataCard(false);
            gmTemp.transform.parent = content.transform;

            allCards.Add(gmTemp);
        }
    }

    private void FirstInventory()
    {
        foreach (Card card in deck.cards)
        {
            InventoryCard_cls tempCard = new InventoryCard_cls(card, true);

            cards2play.Add(tempCard);
        }
    }

    private bool CheckIfActive()
    {
        bool permission = false;
        int count = 0;

        foreach (InventoryCard_cls card in cards2play)
        {
            if (card.isActive)
                count++;
        }

        if (count == 15)
            permission = true;

        return permission;
    }
}
