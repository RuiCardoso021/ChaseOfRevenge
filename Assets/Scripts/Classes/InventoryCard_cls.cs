using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class InventoryCard_cls : MonoBehaviour, IPointerClickHandler
{
    public bool isActive;
    InventoryManager inventoryManager;

    private void Start()
    {
        
    }

    // verificar no foreach se est� ativa a true e fazer um count que d� return de 15, senao nao deixo fechar
    // aviso que s� pode ter 15 cartas

    private void Update()
    {
        if (inventoryManager == null)
        {
            inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventoryManager != null)
        {
            inventoryManager.ChangeCardsInInventory(this.gameObject);
        }
    }

}

