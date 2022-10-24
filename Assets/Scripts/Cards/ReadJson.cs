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
    public bool activeExpand;
    public bool premissionToSendData;

    public void setDataCard(string mana, string description, string name, string imageID){
        activeExpand = true;
        premissionToSendData = false;
        _textMana.text = mana;
        _textDescription.text = description;
        _textName.text = name;
        _image.sprite = Resources.Load<Sprite>("imagesCards/" + imageID);
    }

    public void setDataCardStatic(TextMeshProUGUI mana, TextMeshProUGUI description, TextMeshProUGUI name, Image imageID){
        activeExpand = false;
        premissionToSendData = false;
        _textMana = mana;
        _textDescription = description;
        _textName = name;
        _image = imageID;
    }

    private void OnMouseOver() {
        if (activeExpand){
            RectTransform rect = this.gameObject.GetComponent<RectTransform>();            
            rect.transform.localScale = new Vector3(0.12f, 0.12f, 0.1f);
            premissionToSendData = true;
        }
    }

    private void OnMouseExit() {
        if (activeExpand){
            RectTransform rect = this.gameObject.GetComponent<RectTransform>();            
            rect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            premissionToSendData = false;
        }
    }

    public void changeScale(Vector3 value){
        
        this.transform.localScale = value;
    }


}


