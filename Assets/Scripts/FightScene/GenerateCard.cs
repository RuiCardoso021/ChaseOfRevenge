using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCard : MonoBehaviour
{
   public GameObject Card;
   private float numberCards = 4;
   private ReadJson dataCard;
   private Deck deck;
   public TextAsset jsonFile;
  
   void Start()
   {    
        //generate card list
        List<int> cardsToGive = new List<int>();
        int random;
        float x = -1.4f;

        deck = new Deck();
        deck = JsonUtility.FromJson<Deck>(jsonFile.text);

        for (int i=0; i<numberCards; i++)
        {
            //indice random

            random = Random.Range(0, deck.cards.Length);
            Debug.Log(random);
      
    
            cardsToGive.Add(random);
            
            //generate card
            Card.GetComponent<ReadJson>().setDataCard(deck.cards[random].mana.ToString(), deck.cards[random].description, deck.cards[random].name, deck.cards[random].src);
            Instantiate(Card, new Vector3(x,1,-7), Quaternion.identity);
            x+= 0.6f;
        }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
