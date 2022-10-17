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

}
