using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject contentCards2Play;
    [SerializeField] private GameObject contentInventory;
    [SerializeField] private TextMeshProUGUI count_ContentCards2Play;
    [SerializeField] private TextMeshProUGUI count_ContentInventory;
    public Deck deck;
    public TextAsset jsonFile;

    public List<GameObject> cards2play = new List<GameObject>();
    //public Deck cardsOnInventory = new Deck();
    public GameObject cardGameObject;
    public GameObject Player;

    private void Start()
    {

        Inicialize();

    }

    public void Inicialize()
    {
        deck = Player.GetComponent<Character_Prefab>().myDeck;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FirstInventory();
    }

    private void Update()
    {
 
        //ChangeCardsInInventory();

        setDataCount();
        
    }

    public void checkIfChangeInventory()
    {
        if (deck != GameObject.Find(Global.findPlayer).GetComponent<Character_Prefab>().myDeck)
        {
            foreach (var item in cards2play)
            {
                Destroy(item);
            }

            Inicialize();
        }
    }

    public void setDataCount()
    {
        if (cards2play.Count > 0 && count_ContentCards2Play != null)
        {
            count_ContentCards2Play.text = cards2play.Count.ToString();
            //count_ContentInventory.text = CountCards(contentInventory).ToString();
        }


    }

    //0 - cardsToPlay && 1 - Inventory
    //public int CountCards(GameObject content)
    //{
    //    int count = 0;
    //    if (cards2play != null)
    //    {
    //        foreach (GameObject go in cards2play)
    //        {
    //            if (go != null)
    //            {
    //                if (go.transform.parent == content.transform)
    //                    count++;
    //            }
    //        }
    //    }
    //   
    //    return count;
    //}

    // primeira lista com as cartas todas
    public void FirstInventory()
    {
        GameObject gmTemp;

        foreach (Card card in deck.cards)
        {
            if (card != null)
            {
                gmTemp = Instantiate(cardGameObject, Vector3.zero, Quaternion.identity);
                //gmTemp.AddComponent<InventoryCard_cls>();
                gmTemp.GetComponent<Card_Prefab>().dataCard = card;
                gmTemp.transform.parent = contentCards2Play.transform;

                cards2play.Add(gmTemp);

            }
        }
    }


    // escolha das cartas para levar para a fight
    //public void ChangeCardsInInventory()
    //{
    //
    //    if (cards2play != null)
    //    {
    //        foreach (GameObject go in cards2play)
    //        {
    //            if (go != null)
    //            {
    //                if (go.GetComponent<InventoryCard_cls>().transferItemToInventory)
    //                    go.transform.parent = contentInventory.transform;
    //
    //                else
    //                    go.transform.parent = contentCards2Play.transform;
    //            }
    //        }
    //    }
    //  
    //}

    public void saveDeck()
    {
        CardPref.instance.saveDeckPref(deck, 1);
    }

    public void getDeckAgain()
    {
        deck = CardPref.instance.LoadDeckPref(1);
    }
}
