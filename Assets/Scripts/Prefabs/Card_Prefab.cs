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

    public bool activeExpand;
    public bool activeClick;
    public Card dataCard;

    public void setDataCard(bool _activeExpand)
    {
        activeClick = false;
        activeExpand = _activeExpand;
        _textMana.text = dataCard.mana.ToString();
        _textDescription.text = dataCard.description;
        _textName.text = dataCard.name;
        _image.sprite = Resources.Load<Sprite>("imagesCards/" + dataCard.src);
    }

    public void setDataCardStatic(TextMeshProUGUI mana, TextMeshProUGUI description, TextMeshProUGUI name, Image imageID){
        _textMana = mana;
        _textDescription = description;
        _textName = name;
        _image = imageID;
    }

    private void OnMouseOver()
    {
        if (activeExpand)
        {
            RectTransform rect = this.gameObject.GetComponent<RectTransform>();
            rect.transform.localScale = new Vector3(0.12f, 0.12f, 0.1f);
        }
    }

    private void OnMouseExit()
    {
        if (activeExpand)
        {
            RectTransform rect = this.gameObject.GetComponent<RectTransform>();
            rect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void OnMouseDown()
    {
        if (GameObject.Find("GamePlay").GetComponent<GamePlayFight>()._cardsToPlay.CardChoose != null)
        {
            GameObject.Find("GamePlay").GetComponent<GamePlayFight>()._cardsToPlay.CardChoose = dataCard;
        } 
        activeClick = true;
    }


}


