using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryCard_cls : MonoBehaviour
{
    public bool isActive;
    InventoryManager inventoryManager;

    public InventoryCard_cls(bool _isActive)
    {
        isActive = _isActive;
    }

    public InventoryCard_cls()
    {

    }

    private void Start()
    {
        
    }

    // verificar no foreach se está ativa a true e fazer um count que dá return de 15, senao nao deixo fechar
    // aviso que só pode ter 15 cartas

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        if (GameObject.Find("InventoryCanvas") != null)
        {
            inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ExpandCard();
        } 
    }

    public void SelectCard()
    {
        if (inventoryManager != null)
        {
            inventoryManager.ChangeCardsInInventory(this.gameObject);
        }
    }

    public void RemoveCard()
    {
        if (inventoryManager != null)
        {
            inventoryManager.ChangeCardsInInventory(this.gameObject);
        }
    }

    public void ExpandCard()
    {
        if (inventoryManager != null)
        {
            inventoryManager.cardPrefabExpand.GetComponent<Card_Prefab>().dataCard = GetComponent<Card_Prefab>().dataCard;
            inventoryManager.cardPrefabExpand.SetActive(true);
        }
    }
}

