using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability{
    public string tag;
    public int value;
    public int effect_quantity;
    public string type_effect;

    public Ability() { }

    public Ability(string tag, int value, int effect_quantity, string type_effect)
    {
        this.tag = tag;
        this.value = value;
        this.effect_quantity = effect_quantity;
        this.type_effect = type_effect;
    }
}



