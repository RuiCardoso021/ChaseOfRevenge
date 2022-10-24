using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character_cls
{
    public GameObject Obj;
    public string Name;
    public int Mana;
    public string ClassType;
    public float Health;
    public Deck Cards;

    public Character_cls(GameObject _obj, string _name, int _mana, string _classType, float _health, Deck deck){
        Obj = _obj;
        Obj.transform.position = Vector3.zero;

        Name = _name;
        Mana = _mana;
        ClassType = _classType;
        Health = _health;
        Cards = deck;
    }

    public Character_cls(GameObject _obj){
        this.Obj = _obj;
        Obj.transform.position = new Vector3(0,2f,0);
    }

}

