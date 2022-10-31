using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

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

                validate = false;
            }

        }

        if (!validate) { 
            if (_turn.myTurn)
            {
                Card cardChose = new Card();
                cardChose = _cardsToPlay.CardChoose;
                    
                if (!cardChose.IsEmpty())
                {
                    int countAbility = cardChose.ability.Length;
                    for (int i = 0; i < countAbility; i++)
                    {
                        Ability ability = cardChose.ability[i];

                        switch (ability.tag)
                        {
                            case "Attack":
                                Debug.Log("Attack: " + ability);
                                Character_cls enemy = RecibeCharactersFight.Instance.SpawnerList[1].GetComponent<Character_cls>();
                                enemy.Health -= ability.value;
                                break;
                            case "Damage":
                                Debug.Log("Damage: " + ability);
                                break;
                            case "healc":
                                Debug.Log("heal: " + ability);
                                break;
                            case "CC":
                                Debug.Log("CC: " + ability);
                                break;
                            default:
                                Debug.Log("This Ability, don´t exist!");
                                break;
                        }
                            
                    }
                }
                _cardsToPlay.CardChoose = new Card();
                
            }
        }
    }

}
