using UnityEngine;

public class Chest : MonoBehaviour
{
    //public WeightedRandomList<Transform> cardTable;
    [SerializeField] private GameObject chestPanel;
    public GameObject chest;
    InventoryManager inventoryManager;

    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        chestPanel.SetActive(true);
    }

    public void CloseChest()
    {
        chestPanel.SetActive(false);
    }

    public void AddCardToList()
    {
        inventoryManager.cards2play.Add(gameObject);
    }
}
