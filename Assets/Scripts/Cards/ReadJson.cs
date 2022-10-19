using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadJson : MonoBehaviour
{
    public TextAsset jsonFile;
    [SerializeField] private Deck deck;
    
    [SerializeField] public TextMeshProUGUI _textMana;
    [SerializeField] public TextMeshProUGUI _textDescription;
    [SerializeField] public TextMeshProUGUI _textName;
    [SerializeField] public Image _image;
    

    void Start()
    {
        deck = new Deck();
        deck = JsonUtility.FromJson<Deck>(jsonFile.text);


        int random = Random.Range(0, deck.cards.Length);
        _textMana.text = deck.cards[random].mana.ToString();
        _textDescription.text = deck.cards[random].description;
        _textName.text = deck.cards[random].name;
        _image.sprite = Resources.Load<Sprite>("imagesCards/" + deck.cards[random].src);
        

        //for (int i = 0; i < deck.cards.Length; i++)
        //{
        //     Debug.Log("\n id: " + deck.cards[i].id
        //    + "\n name: " + deck.cards[i].name 
        //    + "\n number_effects: " + deck.cards[i].number_effects 
        //    + "\n text: " + deck.cards[i].description 
        //    + "\n mana: " + deck.cards[i].mana 
        //    + "\n type: " + deck.cards[i].type
        //    + "\n src: " + deck.cards[i].src);
//
        //    foreach (Ability ab in deck.cards[i].ability)
        //    {
        //        Debug.Log("\n type: " + ab.tag
        //        + "\n value: " + ab.value
        //        + "\n effect_quantity: " + ab.effect_quantity
        //        + "\n type_effect: " + ab.type_effect);
        //    }
        //}
      


        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


