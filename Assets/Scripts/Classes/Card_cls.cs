using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public int id;
    public string type;
    public string name;
    public int number_effects;
    public Ability[] ability;
    public string description;
    public int mana;
    public string src;

    public Card() {
        
    }

    public Card(Card card)
    {
        this.id = card.id;
        this.type = card.type;
        this.name = card.name;
        this.number_effects = card.number_effects;
        this.ability = new Ability[card.ability.Length];
        for (int i = 0; i < card.ability.Length; i++)
        {
            this.ability[i] = new Ability(card.ability[i].tag, card.ability[i].value, card.ability[i].effect_quantity, card.ability[i].type_effect);
        }
        this.description = card.description;
        this.mana = card.mana;
        this.src = card.src;
    }

    public bool IsEmpty()
    {
        bool value = false;
        if (type == null || name == null
            || ability == null || description == null || src == null) value = true;

        return value;
    }
}

