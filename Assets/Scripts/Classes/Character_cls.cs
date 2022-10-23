using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character_cls
{
    public GameObject obj;
    public Vector3 Position;
    public int id;
    public string name;
    public int mana;
    public string class_type;
    public float health;
    public Deck cards;

    public Character_cls(GameObject _obj, Vector3 _pos){
        this.obj = _obj;
        this.Position = _pos;
    }

}

