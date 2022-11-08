using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    private const int TOTAL_CARDS_ON_HAND = 4;

    private GameObject GameObjectFather;
    private GameObject CardPrefab;
    public List<GameObject> CardsOnHand = new List<GameObject>();
    public Card CardChoose;

    public CardManager()
    {
        CardChoose = new Card();
        GameObjectFather = GameObject.Find(Global.cardContentFromGame);
        CardPrefab = Resources.Load(Global.cardPrefab) as GameObject;
    }

    public void InstanceCardsToPlay(Deck deck){

        //generate card list
        List<int> cardsToGive = new List<int>();
        int random;

        for (int i=0; i< TOTAL_CARDS_ON_HAND; i++)
        {
            //indice random
            do
            {
                random = Random.Range(0, deck.cards.Length);
            } while (cardsToGive.Contains(random));
            cardsToGive.Add(random);

            //generate card
            GameObject cardTemp = CardPrefab;
            cardTemp = Instantiate(CardPrefab, GameObjectFather.transform);
            cardTemp.GetComponent<Card_Prefab>().dataCard = deck.cards[random];
            cardTemp.GetComponent<Card_Prefab>().setDataCard(true);
            cardTemp.AddComponent<CardsAnimationFight>();
            CardsOnHand.Add(cardTemp);
        }
    }

    public void DestroyAllInstanceCards(){
        foreach (var item in CardsOnHand)
        {
            if (item.GetComponent<Card_Prefab>() != null)
                Destroy(item);            
        }
        CardsOnHand = new List<GameObject>();
    }

    public void DestroyThisCard()
    {
        List<GameObject> tempListCardsOnHand = new List<GameObject>();

        foreach (var item in CardsOnHand)
        {
            if (item.GetComponent<Card_Prefab>() != null)
            {
                if (CardChoose == item.GetComponent<Card_Prefab>().dataCard)
                {
                    tempListCardsOnHand.Add(item);
                }
            }
            
        }

        foreach (var item in tempListCardsOnHand)
        {
            Destroy(item);
            CardsOnHand.Remove(item);
        }

    }

    public void DestroyThisCardAndGetAnother(Deck deck)
    {
        GameObject tempGameObject = FindGameObjWithThisCard(CardChoose);

        if (tempGameObject != null)
        {
            DestroyThisCard();

            //indice random
            int random = Random.Range(0, deck.cards.Length);

            CardPrefab.GetComponent<Card_Prefab>().dataCard = deck.cards[random];
            CardPrefab.GetComponent<Card_Prefab>().setDataCard(true);
            CardPrefab.transform.localScale = tempGameObject.transform.localScale;
            CardsOnHand.Add(Instantiate(CardPrefab, tempGameObject.transform.position, Quaternion.identity, GameObjectFather.transform));
        }
        
    }

    private GameObject FindGameObjWithThisCard(Card card)
    {
        GameObject TempCard = new GameObject();
        foreach (var item in CardsOnHand)
        {
            if (item.GetComponent<Card_Prefab>().dataCard == card)
                TempCard = item;
        }

        return TempCard;
    }

    public void setManaAllCards(int mana)
    {
        foreach (var card in CardsOnHand)
        {
            card.GetComponent<Card_Prefab>().dataCard.mana = mana;
        }
    }

}
