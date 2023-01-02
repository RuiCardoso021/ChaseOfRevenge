using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        card = Resources.Load(Global.cardPrefab) as GameObject;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ManagerChest manager = GameObject.Find("Chests").GetComponent<ManagerChest>();
            if (manager != null)
            {
                for (int i = 0; i < manager.cardsInteractionDeck.cards.Length; i++)
                {
                    if (i < 3)
                    {
                        GameObject cardTemp = null;
                        cardTemp = Instantiate(card, _content.transform);
                        cardTemp.AddComponent<CardsAnimationFight>();
                        cardTemp.GetComponent<Card_Prefab>().dataCard = manager.cardsInteractionDeck.cards[i];
                        if (cardTemp != null)
                            cardsInteraction.Add(cardTemp);
                    }
                }

                if (cardsInteraction.Count > 0)
                    OpenChest();
            }

        }
    }

    void OpenChest()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Vector2 hotSpot = new Vector2(_cursorTexture.width / 8, _cursorTexture.height / 8);
        Cursor.SetCursor(_cursorTexture, hotSpot, CursorMode.ForceSoftware);
        chestPanel.SetActive(true);
    }

    public void CloseChest()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        chestPanel.SetActive(false);
    }

    public void AddCardToList()
    {
        inventoryManager.cards2play.Add(gameObject);
    }
}
