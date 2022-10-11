using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadJson : MonoBehaviour
{
    public TextAsset jsonFile;
    [SerializeField] private CardsList listCard;
    
    //[SerializeField] public TextMeshProUGUI _textMana;
    //[SerializeField] public TextMeshProUGUI _textDescription;
 

    void Start()
    {
        listCard = new CardsList();
        listCard = JsonUtility.FromJson<CardsList>(jsonFile.text);

        foreach (Card card in listCard.cards)
        {
            Debug.Log("\n id: " + card.id
            + "\n name: " + card.name 
            + "\n number_effects: " + card.number_effects 
            + "\n text: " + card.description 
            + "\n mana: " + card.mana 
            + "\n type: " + card.type);

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


