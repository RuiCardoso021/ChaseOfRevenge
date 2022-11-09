using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GamePlayFightScene : MonoBehaviour
{

    private RoundTurn _turn;
    private Deck _deck;
    public CardManager _cardsToPlay ;
    private bool validate;
    //private int totalCharactersOnFight;
    private int indexCharacters;
    public Character_cls player;
    public Character_cls enemy;
    private int manaRound;

    private void Start()
    {
        indexCharacters = 0;
        validate = true;
        _turn = GetComponent<RoundTurn>();
        _turn.myTurn = true;
        _cardsToPlay = GetComponent<CardManager>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        //Execute affter existe spown 
        if (ManagerGameFight.Instance.Manager.CharactersOnFight != null)
        {
            player = ManagerGameFight.Instance.Manager.CurrentCharacter.GetComponent<Character_cls>();
            enemy = ManagerGameFight.Instance.Manager.NextCharacter.GetComponent<Character_cls>();

            //codigo rodado enquanto não existir um ecrã de vitoria ou derrota
            manaRound = 4;

            roudnd();
        }
    }

    public void roudnd()
    {
        if (_turn.myTurn)
        {
            //gera as cartas se nao existirem
            if (_cardsToPlay.CardsOnHand.Count == 0)
                generateCards();

            //atribui valores da carta que é clicada
            Card cardChose = new Card();
            _cardsToPlay.getCardChoose();
            cardChose = _cardsToPlay.CardChoose;
                
            //valida se a carta escolhida esta vazia
            if (!cardChose.IsEmpty())
            {
                if (player.Mana >= cardChose.mana)
                {
                    bool activeDestroyThisCard = true;
                    int countAbility = cardChose.ability.Length;
                    for (int i = 0; i < countAbility; i++)
                    {
                        Ability ability = cardChose.ability[i];

                        switch (ability.tag)
                        {
                            case var value when value == Global.damageCard:
                                Debug.Log("Damage");
                                if (ability.type_effect == Global.cardAffectsOther)
                                    enemy.Health -= ability.value;
                                else if (ability.type_effect == Global.cardAffectsPlayer)
                                    player.Health -= ability.value;
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
                            case var value when value == Global.ShuffleCard:
                                Debug.Log("Shuffle: " + ability);
                                if (ability.effect_quantity == 4)
                                {
                                    _cardsToPlay.DestroyAllInstanceCards();
                                    generateCards();
                                    activeDestroyThisCard = false;
                                }
                                else if (ability.effect_quantity == 1)
                                {
                                    _cardsToPlay.DestroyThisCardAndGetAnother(player.myDeck);
                                }
                                break;
                            case var value when value == Global.Card_ManaCard:
                                _cardsToPlay.nextRoundAnyCardDontCostMana = true;
                                break;
                            default:
                                Debug.Log("This Ability, don´t exist!");
                                break;
                        }
                    }

                    if (activeDestroyThisCard) _cardsToPlay.DestroyThisCard();

                    player.Mana -= cardChose.mana;

                    ManagerGameFight.Instance.AddCardsOnHistoric(cardChose);
                }


                //clear cardChoose
                _cardsToPlay.CardChoose = new Card();

                if (player.Mana == 0) _turn.NextTurn();
            }

        }
        else
        {

            if (_cardsToPlay.CardsOnHand.Count > 0)
            {
                _cardsToPlay.DestroyAllInstanceCards();
                _turn.NextTurn();
            }

            player.Mana = 4;
            player.Health -= Random.Range(1, 7);
        }
        
    }

    private void generateCards()
    {
        Character_cls character_cls_player_to_game = RecibeGameObject.Instance.SpawnerList[indexCharacters].GetComponent<Character_cls>();
        //Variables Inicialization.
        if (character_cls_player_to_game.myDeck != null && character_cls_player_to_game.ClassType != Global.findEnemy)
        {
            
            _deck = character_cls_player_to_game.myDeck;

                
            _cardsToPlay.InstanceCardsToPlay(_deck);

            
        }
    }
}


