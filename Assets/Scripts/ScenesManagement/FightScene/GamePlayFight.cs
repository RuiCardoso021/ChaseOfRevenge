using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class GamePlayFight : MonoBehaviour
{

    private Global Global;
    private FightSceneInterface _turn;
    private Deck _deck;
    public GenerateCard _cardsToPlay ;
    private bool validate;
    private int totalCharactersOnFight;
    private int indexCharacters;
    private Character_cls player;
    private Character_cls enemy;
    private int manaRound;

    public void Start()
    {
        Global = new Global();
        indexCharacters = 0;
        validate = false;
        _turn = GetComponent<FightSceneInterface>();
        _turn.myTurn = true;
        _cardsToPlay = new GenerateCard();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //primeira entrada, quando o numero de objetos criados é igual ao numero de objetos pointer
        if (RecibeCharactersFight.Instance.SpawnerList.Length > 0) { 
            enemy = RecibeCharactersFight.Instance.SpawnerList[1].GetComponent<Character_cls>();
            player = RecibeCharactersFight.Instance.SpawnerList[0].GetComponent<Character_cls>();
            manaRound = 4;
        }

        if (_turn.myTurn)
        {
            //gera as cartas se nao existirem
            if (_cardsToPlay.CardsOnHand.Count == 0)
                generateCards();
            
            //atribui valores da carta que é clicada
            Card cardChose = new Card();
            cardChose = _cardsToPlay.CardChoose;
            
            //valida se a carta escolhida esta vazia
            if (!cardChose.IsEmpty())
            {
                if (player.Mana >= cardChose.mana)
                {
                    int countAbility = cardChose.ability.Length;
                    for (int i = 0; i < countAbility; i++)
                    {
                        Ability ability = cardChose.ability[i];

                        switch (ability.tag)
                        {
                            case var value when value == Global.attackCard:
                                Debug.Log("Attack");
                                enemy.Health -= ability.value;
                                break;
                            case var value when value == Global.damageCard:
                                player.Health -= ability.value;
                                Debug.Log("Damage");
                                break;
                            case var value when value == Global.healCard:
                                if (ability.type_effect == Global.cardAffectsPlayer)
                                {
                                    player.Health += ability.value;
                                }
                                else if (ability.type_effect == Global.cardAffectsOther)
                                {
                                    enemy.Health += ability.value;
                                }
                                Debug.Log("health");
                                break;
                            case var value when value == Global.ccCard:
                                Debug.Log("CC: " + ability);
                                break;
                            default:
                                Debug.Log("This Ability, don´t exist!");
                                break;
                        }
                    }
                    _cardsToPlay.DestoyThisCard();
                    player.Mana -= cardChose.mana;
                }

                
                _cardsToPlay.CardChoose = new Card();
            }

        }
        else
        {
            player.Mana = 4;
            if (_cardsToPlay.CardsOnHand.Count > 0)
            {
                _cardsToPlay.DestroyAllInstanceCards();
                _turn.myTurn = !_turn.myTurn;
            }
        }
        
    }

    private void generateCards()
    {
        Character_cls character_cls_player_to_game = RecibeCharactersFight.Instance.SpawnerList[indexCharacters].GetComponent<Character_cls>();
        //Variables Inicialization.
        if (character_cls_player_to_game.myDeck != null && character_cls_player_to_game.ClassType != Global.findEnemy)
        {
            _deck = character_cls_player_to_game.myDeck;

                
            _cardsToPlay.InstanceCardsToPlay(_deck);

            validate = true;
            
        }
    }

}


