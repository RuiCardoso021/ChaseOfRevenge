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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    // verificar no foreach se está ativa a true e fazer um count que dá return de 15, senao nao deixo fechar
    // aviso que só pode ter 15 cartas

    private void Update()
    {
        if (GameObject.Find("InventoryCanvas") != null)
        {
            inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ExpandCard();
            inventoryManager.cardPrefabExpand.SetActive(true);
        }
    }

    public void SelectCard()
    {
        if (inventoryManager != null)
        {
            inventoryManager.ChangeCardsInInventory(this.gameObject);
            //Card_Prefab card = GetComponent<Card_Prefab>();
            //this.gameObject.SetActive(true);
            //inventoryManager.allCards.Add(this.gameObject);
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
        }
    }
}

