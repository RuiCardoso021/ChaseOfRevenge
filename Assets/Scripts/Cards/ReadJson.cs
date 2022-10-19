using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadJson : MonoBehaviour
{   
    [SerializeField] public TextMeshProUGUI _textMana;
    [SerializeField] public TextMeshProUGUI _textDescription;
    [SerializeField] public TextMeshProUGUI _textName;
    [SerializeField] public Image _image;

    public void setDataCard(string mana, string description, string name, string imageID){
        _textMana.text = mana;
        _textDescription.text = description;
        _textName.text = name;
        _image.sprite = Resources.Load<Sprite>("imagesCards/" + imageID);
    }
}


