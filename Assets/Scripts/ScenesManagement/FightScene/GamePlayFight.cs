using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePlayFight : MonoBehaviour
{
    private FightSceneInterface _turn;
    private Deck _deck;
    private GenerateCard _cardsToPlay ;
    private bool validate;

    void Start()
    {
        validate = true;
        _turn = GetComponent<FightSceneInterface>();
        _turn.RandomFirstPlayerToMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (RecibeCharactersFight.Instance.SpawnerList[0].GetComponent<Character_cls>().myDeck != null && validate)
        {
            _deck = RecibeCharactersFight.Instance.SpawnerList[0].GetComponent<Character_cls>().myDeck;

            _cardsToPlay = new GenerateCard();
            _cardsToPlay.InstanceCardsToPlay(_deck);

            validate = false;
        }

        if (_turn.myTurn)
        {
            
        }
    }

  

}
