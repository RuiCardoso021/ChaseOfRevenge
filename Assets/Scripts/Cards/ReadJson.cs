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
    [SerializeField] public Image _image;
 

    void Start()
    {
        deck = new Deck();
        deck = JsonUtility.FromJson<Deck>(jsonFile.text);

        foreach (Card card in deck.cards)
        {
            Debug.Log("\n id: " + card.id
            + "\n name: " + card.name 
            + "\n number_effects: " + card.number_effects 
            + "\n text: " + card.description 
            + "\n mana: " + card.mana 
            + "\n type: " + card.type
            + "\n src: " + card.src);

            _textMana.text = card.mana.ToString();
            _textDescription.text = card.description;
            _image.sprite = Resources.Load<Sprite>("imagesCards/" + card.src);

            foreach (Ability ab in card.ability)
            {
                Debug.Log("\n type: " + ab.tag
                + "\n value: " + ab.value
                + "\n effect_quantity: " + ab.effect_quantity
                + "\n type_effect: " + ab.type_effect);
            }
           //foreach (Ability item in abilityList)
           //{
           //    Debug.Log(item.type_effect);
           //}

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


