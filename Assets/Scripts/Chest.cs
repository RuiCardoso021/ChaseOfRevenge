using UnityEngine;

public class Chest : MonoBehaviour
{
    //public WeightedRandomList<Transform> cardTable;
    [SerializeField] private GameObject chestPanel;
    public GameObject chest;

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
}
