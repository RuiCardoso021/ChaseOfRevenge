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
    public GameObject cardGameObject;

    private GameObject _player;
    InventoryManager inventoryManager;
    public GameObject cardPrefabExpand;

    private void Start()
    {
        _player = GameObject.Find(Global.findPlayer);
        deck = _player.GetComponent<Character_cls>().myDeck;
        cardPrefabExpand = GameObject.Find("ShowCardInventory");
        cardPrefabExpand.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        FirstInventory();
    }

    // primeira lista com as cartas todas
    private void FirstInventory()
    {
        GameObject gmTemp;

        foreach (Card card in deck.cards)
        {
            gmTemp = Instantiate(cardGameObject, Vector3.zero, Quaternion.identity);
            gmTemp.transform.localScale = new Vector3(1f, 1f, 1f);
            gmTemp.GetComponent<Card_Prefab>().dataCard = card;
            gmTemp.GetComponent<Card_Prefab>().setDataCard(false);
            gmTemp.transform.parent = contentCards2Play.transform;
            gmTemp.GetComponent<InventoryCard_cls>().isActive = true;

            cards2play.Add(gmTemp);
        }
    }

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
}
