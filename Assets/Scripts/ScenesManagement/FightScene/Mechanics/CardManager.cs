using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    private const int TOTAL_CARDS_ON_HAND = 4;

    private GameObject CardPrefab;
    public List<GameObject> CardsOnHand = new List<GameObject>();
    public List<GameObject> TempCardOffHand = new List<GameObject>();
    public Card CardChoose;
    public bool nextRoundAnyCardDontCostMana;

    private void Start()
    {
        nextRoundAnyCardDontCostMana = false;
        CardChoose = new Card();
        CardPrefab = Resources.Load(Global.cardPrefab) as GameObject;
    }

    private void Update()
    {
        if (CardsOnHand.Count > 0)
        {
            //animation mouseHover
            AddAnimation();

            //set mana 0 on all cards if "nextRoundAnyCardDontCostMana" is true
            setManaAllCards(0);
        }
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

            InstanceCard(deck.cards[random]);
        }
    }

    //generate card
    private void InstanceCard(Card card)
    {
        if (card != null)
        {
            GameObject GameObjectFather = GameObject.Find(Global.cardContentFromGame);
            GameObject cardTemp = CardPrefab;
            cardTemp = Instantiate(CardPrefab, GameObjectFather.transform);
            cardTemp.GetComponent<Card_Prefab>().dataCard = card;
            cardTemp.AddComponent<CardsAnimationFight>();
            CardsOnHand.Add(cardTemp);
        }

    }

    //Destroy all Cards
    public void DestroyAllInstanceCards(){
        foreach (var item in CardsOnHand)
        {
            if (item.GetComponent<Card_Prefab>() != null)
                Destroy(item);            
        }
        CardsOnHand = new List<GameObject>();
    }

    //Destroy CardChoose
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

    //Destroy CardChoose and get another
    public void DestroyThisCardAndGetAnother(Deck deck)
    {
        GameObject tempGameObject = FindGameObjWithThisCard(CardChoose);

        if (tempGameObject != null)
        {
            DestroyThisCard();

            //indice random
            int random = Random.Range(0, deck.cards.Length);

            InstanceCard(deck.cards[random]);
        }
        
    }

    //Return GameObject if existe inside list "CardOnHand"
    private GameObject FindGameObjWithThisCard(Card card)
    {
        GameObject TempCard = null;
        foreach (var item in CardsOnHand)
        {
            if (item.GetComponent<Card_Prefab>().dataCard == card)
                TempCard = item;
        }

        return TempCard;
    }

    //Set mana value on all cards
    private void setManaAllCards(int mana)
    {
        if (nextRoundAnyCardDontCostMana)
        {
            foreach (var card in CardsOnHand)
            {
                card.GetComponent<Card_Prefab>().dataCard.mana = mana;
            }
            nextRoundAnyCardDontCostMana = false;
        }    
    }

    //Apply event mouse over on cards
    public void AddAnimation()
    {
        foreach (var item in CardsOnHand)
        {
            if (item.GetComponent<CardsAnimationFight>() != null)
            {
                //set transformation card if houver
                if (item.GetComponent<CardsAnimationFight>().mouse_over)
                {
                    RectTransform rect = item.gameObject.GetComponent<RectTransform>();
                    rect.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                }
                else if (!item.GetComponent<CardsAnimationFight>().mouse_over)
                {
                    RectTransform rect = item.gameObject.GetComponent<RectTransform>();
                    rect.transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
            
        }
    }

    //set "dataCard" on "CardChoose" if click in this card
    public void getCardChoose()
    {
        foreach (var item in CardsOnHand)
        {
            if (item.GetComponent<CardsAnimationFight>() != null)
            {
                //set cardchose if click
                if (item.GetComponent<CardsAnimationFight>().mouse_click)
                {
                    CardChoose = item.GetComponent<Card_Prefab>().dataCard;
                    item.GetComponent<CardsAnimationFight>().mouse_click = false;
                }
            }

        }
    }

}
