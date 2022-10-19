using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenerateCard : MonoBehaviour
{
   public GameObject Card;
   private List<GameObject> cards = new List<GameObject>();
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
            do
            {
                random = Random.Range(0, deck.cards.Length);
            } while (cardsToGive.Contains(random));
            cardsToGive.Add(random);
            
            //generate card
            Card.GetComponent<ReadJson>().setDataCard(deck.cards[random].mana.ToString(), deck.cards[random].description, deck.cards[random].name, deck.cards[random].src);
            cards.Add(Instantiate(Card, new Vector3(x,1,-7), Quaternion.identity));
            x+= 0.6f;
        }
   }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            this.transform.localScale = new Vector3 (0.2f,0.2f,0.2f);
        }
        else
        {
            this.transform.localScale = new Vector3 (0.1f,0.1f,0.1f);
        }
    }
}
