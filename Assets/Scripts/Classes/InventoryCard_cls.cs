using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryCard_cls 
{
    public Card card;
    public bool isActive;

    public InventoryCard_cls(Card _card, bool _isActive)
    {
        card = _card;
        isActive = _isActive;
    }

    public InventoryCard_cls()
    {
        
    }

}
