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

    //InventoryCard_cls _inventoryCard;

    public void setDataCard(bool _activeExpand)
    {
        activeClick = false;
        activeExpand = _activeExpand;
        _textMana.text = dataCard.mana.ToString();
        _textDescription.text = dataCard.description;
        _textName.text = dataCard.name;
        _image.sprite = Resources.Load<Sprite>(Global.cardImage + dataCard.src);
    }

    public void setDataCardStatic(TextMeshProUGUI mana, TextMeshProUGUI description, TextMeshProUGUI name, Image imageID)
    {
        _textMana = mana;
        _textDescription = description;
        _textName = name;
        _image = imageID;
    }

    //private void OnMouseOver()
    //{
    //    if (activeExpand)
    //    {
    //        RectTransform rect = this.gameObject.GetComponent<RectTransform>();
    //        rect.transform.localScale = new Vector3(1f,1f,1f);
    //    }
    //}
    //
    //private void OnMouseExit()
    //{
    //    if (activeExpand)
    //    {
    //        RectTransform rect = this.gameObject.GetComponent<RectTransform>();
    //        rect.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
    //    }
    //}

    //private void OnMouseDown()
    //{
    //    if (GameObject.Find(Global.gameplayObject).GetComponent<GamePlayFightScene>()._cardsToPlay.CardChoose != null)
    //    {
    //        GameObject.Find(Global.gameplayObject).GetComponent<GamePlayFightScene>()._cardsToPlay.CardChoose = dataCard;
    //    }
    //    else if (GameObject.Find(Global.cardInventoryObject).GetComponent<InventoryManager>().cards2play != null)
    //    {
    //        //InventoryCard_cls inventoryCard = GameObject.Find("CardInventory").GetComponent<InventoryManager>().cards2play;
    //
    //        foreach (GameObject inventoryCard in
    //            GameObject.Find(Global.cardInventoryObject).GetComponent<InventoryManager>().cards2play)
    //        {
    //            if (inventoryCard.GetComponent<Card_Prefab>().dataCard == dataCard)
    //            {
    //                inventoryCard.GetComponent<InventoryCard_cls>().isActive = !inventoryCard.GetComponent<InventoryCard_cls>().isActive;
    //                Debug.Log(inventoryCard.GetComponent<InventoryCard_cls>().isActive);
    //            }
    //        }
    //    }
    //    activeClick = true;
    //}
}


