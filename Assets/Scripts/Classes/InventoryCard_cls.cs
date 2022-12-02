using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

[System.Serializable]
public class InventoryCard_cls : MonoBehaviour, IPointerClickHandler
{
    public bool transferItemToInventory;

    private void Start()
    {
        transferItemToInventory = false;
    }

    // verificar no foreach se est� ativa a true e fazer um count que d� return de 15, senao nao deixo fechar
    // aviso que s� pode ter 15 cartas


    public void OnPointerClick(PointerEventData eventData)
    {
        transferItemToInventory = !transferItemToInventory;
    }

}

