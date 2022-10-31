using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePlayFight : MonoBehaviour
{
    private FightSceneInterface _turn;
    private Deck _deck;
    public GenerateCard _cardsToPlay ;
    private bool validate;
    private int totalCharactersOnFight;
    private int indexCharacters;

    void Start()
    {
        indexCharacters = 0;
        validate = true;
        _turn = GetComponent<FightSceneInterface>();
        _turn.RandomFirstPlayerToMove();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Character_cls character_cls_player_to_game = RecibeCharactersFight.Instance.SpawnerList[indexCharacters].GetComponent<Character_cls>();
        //Variables Inicialization.
        if (character_cls_player_to_game.myDeck != null && validate)
        {
            if(character_cls_player_to_game.ClassType != "Enemy")
            {
                _deck = character_cls_player_to_game.myDeck;

                _cardsToPlay = new GenerateCard();
                _cardsToPlay.InstanceCardsToPlay(_deck);

                if (!_cardsToPlay.CardChoose.IsEmpty())
                {
                    Card cardChose = new Card();
                    cardChose = _cardsToPlay.CardChoose;
                    for (int i = 0; i < cardChose.ability.Length; i++)
                    {
                        if (cardChose.ability[i].tag == "Attack")
                        {
                            Debug.Log("Ataquei com: " + cardChose.ability[i].value);
                        }
                    }
                }

                validate = false;
            }

        }

        if (!validate) { 
            if (_turn.myTurn)
            {

            }
        }
    }

}
