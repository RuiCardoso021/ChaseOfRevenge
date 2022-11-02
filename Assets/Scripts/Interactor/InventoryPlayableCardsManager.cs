using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class InventoryPlayableCardsManager : MonoBehaviour
{
    [SerializeField] private GameObject content;
    private Deck deck;
    public TextAsset jsonFile;

    public List<GameObject> cards = new List<GameObject>();
    public GameObject cardGameObject;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find(Global.findPlayer);
        deck = _player.GetComponent<Character_cls>().myDeck;

        getCardsToInventory();
    }

    private void Update()
    {

    }

    private void getCardsToInventory()
    {
        GameObject gmTemp;

        foreach (Card card in deck.cards.Take(15))
        {
            //generate card          
            gmTemp = Instantiate(cardGameObject, Vector3.zero, Quaternion.identity);
            gmTemp.GetComponent<Card_Prefab>().setDataCard(false);
            gmTemp.GetComponent<Card_Prefab>().dataCard = card;
            gmTemp.transform.parent = content.transform;

            cards.Add(gmTemp);
        }
    }
}
