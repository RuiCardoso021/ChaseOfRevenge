using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    private const int TOTAL_CARDS_ON_HAND = 4;

    private bool returnDeck;
    private GameObject CardPrefab;
    private List<int> cardsToGive = new List<int>();
    
    public Card[] deckCardManager;
    public Card[] duplicateDeck;
    public List<GameObject> CardsOnHand = new List<GameObject>();
    public List<Card> TempCardOffHand = new List<Card>();
    public bool nextCardDontCostMana;
    public bool getCards;


    public Card CardChoose;


    private void Start()
    {
        getCards = true;
        nextCardDontCostMana = false;
        returnDeck = false;
        CardChoose = new Card();
        CardPrefab = Resources.Load(Global.cardPrefab) as GameObject;
    }

    private void Update()
    {
        if (ManagerGameFight.Instance.PermissedExecute)
        {
            if (CardsOnHand.Count > 0)
            {
                AddAnimation();

            }
        }

    }



    private int GetIndexRandom()
    {
        int random;
        do
        {
            random = Random.Range(0, deckCardManager.Length);
        } while (cardsToGive.Contains(random));
        cardsToGive.Add(random);

        return random;
    }

    public void InstanceCardsToPlay(){
        if (deckCardManager != null)
        {
            cardsToGive = new List<int>();
            for (int i = 0; i < TOTAL_CARDS_ON_HAND; i++)
            {
                //indice random
                InstanceCard(deckCardManager[GetIndexRandom()]);
            }
        }
    }

    //generate card
    private void InstanceCard(Card card)
    {
        if (card != null)
        {
            GameObject GameObjectFather = GameObject.Find(Global.cardContentFromGame);
            if (GameObjectFather != null)
            {
                GameObject cardTemp = CardPrefab;
                cardTemp = Instantiate(CardPrefab, GameObjectFather.transform);
                cardTemp.GetComponent<Card_Prefab>().dataCard = card;
                cardTemp.AddComponent<CardsAnimationFight>();
                CardsOnHand.Add(cardTemp);
            }   
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
    public void DestroyThisCardAndGetAnother()
    {
        GameObject tempGameObject = FindGameObjWithThisCard(CardChoose);

        if (tempGameObject != null)
        {
            int random = GetIndexRandom();
            
            DestroyThisCard();

            InstanceCard(deckCardManager[random]);
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

    //Set mana value on all cards last chosed
    public void setManaAllCards(int mana)
    {
        foreach (var card in CardsOnHand)
        {
            if (card.GetComponent<Card_Prefab>().dataCard != CardChoose)
                card.GetComponent<Card_Prefab>().dataCard.mana = mana;
        }

        returnDeck = true;   
    }

    //subtract Mana on cards until other card was play
    public void subtractManaAllCards(int mana)
    {
        foreach (var card in CardsOnHand)
        {
            if (card.GetComponent<Card_Prefab>().dataCard != CardChoose)
                card.GetComponent<Card_Prefab>().dataCard.mana -= mana;
        }

        returnDeck = true;
    }

    //Get a inicial Deck
    public void GetDataCardOnHandBeforeChange()
    {
        if (returnDeck)
        {
            foreach (var item in CardsOnHand)
            {
                if (item.GetComponent<Card_Prefab>().dataCard != CardChoose)
                {
                    for (int i = 0; i < deckCardManager.Length; i++)
                    {
                        if (item.GetComponent<Card_Prefab>().dataCard.id == deckCardManager[i].id)
                            item.GetComponent<Card_Prefab>().dataCard.mana = duplicateDeck[i].mana;
                    }
                }
                
            }
            returnDeck = false;
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
