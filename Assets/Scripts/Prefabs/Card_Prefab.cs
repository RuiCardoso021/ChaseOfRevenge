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

    private void Update()
    {
        if(dataCard != null)
        {
            validationMana();
            _textMana.text = dataCard.mana.ToString();
            _textDescription.text = dataCard.description;
            _textName.text = dataCard.name;
            _image.sprite = Resources.Load<Sprite>(Global.cardImage + dataCard.src);
        }
    }

    //nao permite ir a baixo de 0
    private void validationMana()
    {
        if (dataCard.mana < 0)
            dataCard.mana = 0;
    }
}


