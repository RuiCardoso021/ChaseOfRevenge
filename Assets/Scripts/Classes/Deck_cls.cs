using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck {
    public Card[] cards;

    public Deck() { }

    public void GetInicialCards(string classType)
    {
        List<Card> inventoryCards = new List<Card>();

        foreach (Card card in cards)
        {
            if (card.type == classType || card.type == Global.universalCard)
            {
                inventoryCards.Add(card);
            }
        }
        cards = inventoryCards.ToArray();

    }

    //Save deck on PlayerPref
    public static void saveDeckPref(Deck deck, int id)
    {
        PlayerPrefsData pref = new PlayerPrefsData();

        pref.SaveInt("DeckLength_" + id.ToString(), deck.cards.Length);

        for (int i = 0; i < deck.cards.Length; i++)
        {
            Card card = deck.cards[i];
            int index = 0;
            string name = "card_" + i.ToString();
            pref.SaveInt(name + index.ToString(), card.id);
            index++;
            pref.SaveInt(name + index.ToString(), card.rarity);
            index++;
            pref.SaveInt(name + index.ToString(), card.number_effects);
            index++;
            pref.SaveInt(name + index.ToString(), card.mana);
            index++;
            pref.SaveString(name + index.ToString(), card.type);
            index++;
            pref.SaveString(name + index.ToString(), card.name);
            index++;
            pref.SaveString(name + index.ToString(), card.category);
            index++;
            pref.SaveString(name + index.ToString(), card.description);
            index++;
            pref.SaveString(name + index.ToString(), card.src);
            index++;

            for (int j = 0; j < card.ability.Length; j++)
            {
                name += index.ToString() + j.ToString();
                int subIndex = 0;
                pref.SaveInt(name + subIndex.ToString(), card.ability[i].effect_quantity);
                subIndex++;
                pref.SaveInt(name + subIndex.ToString(), card.ability[i].value);
                subIndex++;
                pref.SaveString(name + subIndex.ToString(), card.ability[i].tag);
                subIndex++;
                pref.SaveString(name + subIndex.ToString(), card.ability[i].type_effect);
            }

        }

    }

    //Return deck from PlayerPref
    public static Deck LoadDeckPref(int id)
    {
        PlayerPrefsData pref = new PlayerPrefsData();
        Deck deck = null;
        int lengthDeck = pref.LoadInt("DeckLength_" + id.ToString());

        if (lengthDeck > 0)
        {
            deck = new Deck();
            deck.cards = new Card[lengthDeck];

            for (int i = 0; i < lengthDeck; i++)
            {
                Card card = new Card();
                string name = "card_" + i.ToString();
                int index = 0;
                card.id = pref.LoadInt(name + index.ToString());
                index++;
                card.rarity = pref.LoadInt(name + index.ToString());
                index++;
                card.number_effects = pref.LoadInt(name + index.ToString());
                index++;
                card.mana = pref.LoadInt(name + index.ToString());
                index++;
                card.type = pref.LoadString(name + index.ToString());
                index++;
                card.name = pref.LoadString(name + index.ToString());
                index++;
                card.category = pref.LoadString(name + index.ToString());
                index++;
                card.description = pref.LoadString(name + index.ToString());
                index++;
                card.src = pref.LoadString(name + index.ToString());
                index++;

                card.ability = new Ability[card.number_effects];
                for (int j = 0; j < card.ability.Length; j++)
                {
                    Ability ab = new Ability();
                    name += index.ToString() + j.ToString();
                    int subIndex = 0;
                    ab.effect_quantity = pref.LoadInt(name + subIndex.ToString());
                    subIndex++;
                    ab.value = pref.LoadInt(name + subIndex.ToString());
                    subIndex++;
                    ab.tag = pref.LoadString(name + subIndex.ToString());
                    subIndex++;
                    ab.type_effect = pref.LoadString(name + subIndex.ToString());

                    card.ability[j] = ab;
                }

                deck.cards[i] = card;
            }
        }
        

        return deck;
    }
}