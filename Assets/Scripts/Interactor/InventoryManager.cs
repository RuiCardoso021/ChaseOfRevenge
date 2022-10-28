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

    public List<GameObject> cards = new List<GameObject>();
    public GameObject cardGameObject;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Character_Player");
        deck = _player.GetComponent<Character_cls>().myDeck;

        getCardsToInventory();
    }

    private void Update()
    {
        
    }

    private void getCardsToInventory()
    {
        GameObject gmTemp;

        foreach(Card card in deck.cards)
        {
            //generate card
            cardGameObject.GetComponent<Card_Prefab>().setDataCard(card.mana.ToString(), card.description, card.name, card.src);
            gmTemp = Instantiate(cardGameObject, Vector3.zero, Quaternion.identity);
            gmTemp.transform.parent = content.transform;

            cards.Add(gmTemp);
        }
    }
}
