using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Chest : MonoBehaviour
{
    //public WeightedRandomList<Transform> cardTable;
    public List<GameObject> cardsInteraction = new List<GameObject>();
    [SerializeField] private GameObject chestPanel;
    [SerializeField] private GameObject _content;
    [SerializeField] private Texture2D _cursorTexture;
    public GameObject chest;
    InventoryManager inventoryManager;
    GameObject card;
    bool validate;


    void Start()
    {
        validate = true;
        card = Resources.Load(Global.cardPrefab) as GameObject;
    }

    void Update()
    {
        CloseChest();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ManagerChest manager = GameObject.Find("Chests").GetComponent<ManagerChest>();
            if (manager != null)
            {
                int count = 0;
                for (int i = 0; i < manager.cardsInteractionDeck.cards.Length; i++)
                {
                    if (count < 3 
                        && !SaveGameProgress.instance.CheckIfCardChestIsmy(manager.cardsInteractionDeck.cards[i].id)
                        )
                    {
                        GameObject cardTemp = null;
                        cardTemp = Instantiate(card, _content.transform);
                        cardTemp.AddComponent<CardsAnimationFight>();
                        cardTemp.GetComponent<Card_Prefab>().dataCard = manager.cardsInteractionDeck.cards[i];
                        if (cardTemp != null)
                        {
                            cardsInteraction.Add(cardTemp);
                            count++;
                        }
                    }
                }

                if (cardsInteraction.Count > 0)
                    OpenChest();
            }

        }
    }

    void OpenChest()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Vector2 hotSpot = new Vector2(_cursorTexture.width / 8, _cursorTexture.height / 8);
        Cursor.SetCursor(_cursorTexture, hotSpot, CursorMode.ForceSoftware);
        chestPanel.SetActive(true);
    }

    public void CloseChest()
    {
        if (cardsInteraction.Count > 0)
        {
            foreach (var item in cardsInteraction)
            {
                CardsAnimationFight cardAnim = item.GetComponent<CardsAnimationFight>();
                if (cardAnim != null)
                {
                    if (cardAnim.mouse_click && validate)
                    {
                        Character_Prefab player = GameObject.Find(Global.findPlayer).GetComponent<Character_Prefab>();
                        player.myDeck.AddCard(item.GetComponent<Card_Prefab>().dataCard);
                        SaveGameProgress.instance.SaveCardChest(item.GetComponent<Card_Prefab>().dataCard.id);
                        Cursor.visible = false;
                        chest.SetActive(false);
                        validate = false;
                    }

                }
            }
        }
    }

    public void AddCardToList()
    {
        inventoryManager.cards2play.Add(gameObject);
    }
}
