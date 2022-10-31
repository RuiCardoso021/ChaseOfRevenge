using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenerateCard : MonoBehaviour
{
    private const int TOTAL_CARDS_ON_HAND = 4;

    private GameObject GameObjectFather;
    private GameObject CardPrefab;
    public List<GameObject> CardsOnHand = new List<GameObject>();
    public Card CardChoose;

    public GenerateCard()
    {
        CardChoose = new Card();
        GameObjectFather = GameObject.Find("CardOnHand");
        CardPrefab = Resources.Load("Card/Card") as GameObject;
    }

    public void InstanceCardsToPlay(Deck deck){

        //generate card list
        List<int> cardsToGive = new List<int>();
        int random;
        float x = -2.4f;

        for (int i=0; i< TOTAL_CARDS_ON_HAND; i++)
        {
            //indice random
            do
            {
                random = Random.Range(0, deck.cards.Length);
            } while (cardsToGive.Contains(random));
            cardsToGive.Add(random);

            //generate card
            CardPrefab.GetComponent<Card_Prefab>().dataCard = deck.cards[random];
            CardPrefab.GetComponent<Card_Prefab>().setDataCard(true);
            CardsOnHand.Add(Instantiate(CardPrefab, new Vector3(x, 1, -7), Quaternion.identity, GameObjectFather.transform));
            
            x+= 0.6f;
        }
    }

    private void DestroyAllInstanceCards(){
        foreach (var item in CardsOnHand)
        {
            Destroy(item);            
        }
    }



}
