using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadJson : MonoBehaviour
{
    public TextAsset jsonFile;
    
    [SerializeField] public TextMeshProUGUI _textMana;
    [SerializeField] public TextMeshProUGUI _textDescription;
 
    void Start()
    {
        Cards playersInJson = JsonUtility.FromJson<Cards>(jsonFile.text);
 
        foreach (Card card in playersInJson.cartas)
        {
            Debug.Log("ID: " + card.id
                     + "\nname: " + card.name
                     + "\ntipo: " + card.tipo
                     + "\ndano: " + card.value
                     + "\ntext: " + card.text
                     + "\nmana: " + card.mana);

                     _textMana.text = card.mana.ToString();
                     _textDescription.text = card.text;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class Card{
    public int id;
    public string name;
    public string tipo;
    public int value;
    public string text;
    public int mana;
}

[System.Serializable]
public class Cards{
    public Card[] cartas;
}