using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card_Prefab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMana;
    [SerializeField] private TextMeshProUGUI _textDescription;
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private Image _image;
    public Card dataCard;

    //InventoryCard_cls _inventoryCard;

    private void Update()
    {
        if(dataCard != null)
        {
            _textMana.text = dataCard.mana.ToString();
            _textDescription.text = dataCard.description;
            _textName.text = dataCard.name;
            _image.sprite = Resources.Load<Sprite>(Global.cardImage + dataCard.src);
        }
    }
}


