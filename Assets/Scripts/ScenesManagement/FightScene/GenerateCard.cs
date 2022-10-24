using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenerateCard : MonoBehaviour
{
    private FightSceneInterface _turn;
    public GameObject gmCard;
    public GameObject Card;
    public List<GameObject> cards = new List<GameObject>();
    private int numberCardsOnHand = 4;
    private Deck deck;
    public TextAsset jsonFile;
    
    void Start()
    {    
        _turn = this.GetComponent<FightSceneInterface>();
        _turn.RandomFirstPlayerToMove();
        deck = new Deck();
        deck = JsonUtility.FromJson<Deck>(jsonFile.text);

        getCardsToPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getCardsToPlay(){
        //generate card list
        List<int> cardsToGive = new List<int>();
        int random;
        float x = -2.4f;

        for (int i=0; i<numberCardsOnHand; i++)
        {
            //indice random
            do
            {
                random = Random.Range(0, deck.cards.Length);
            } while (cardsToGive.Contains(random));
            cardsToGive.Add(random);
            
            //generate card
            Card.GetComponent<ReadJson>().setDataCard(deck.cards[random].mana.ToString(), deck.cards[random].description, deck.cards[random].name, deck.cards[random].src);
            cards.Add(Instantiate(Card, new Vector3(x,1,-7), Quaternion.identity, gmCard.transform));
            x+= 0.6f;
        }
    }

    private void DestroyAllInstanceCards(){
        foreach (var item in cards)
        {
            Object.Destroy(item);            
        }
    }



}
