using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GamePlayFightScene : MonoBehaviour
{

    private CardManager _cardsToPlay;
    private RoundTurn _turn;
    private Deck _deck;
    private int indexCharacters;
    private Character_cls player;
    private Character_cls enemy;
    private bool activeDestroyThisCard;

    //Start
    private void Start()
    {
        indexCharacters = 0;
        _turn = GetComponent<RoundTurn>();
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
            MechanicsCards();
        }
    }

    private void MechanicsCards()
    {
        if (_turn.myTurn)
        {
            if (player.PermissedByAttack == true)
                PlayerToPlay();
        }
        else
        {
            EnemiesToPlay();
            
        }



    }

    private void PlayerToPlay()
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
            //permissed attack all enemies on next round if not change on code player
            ManagerGameFight.Instance.Manager.SetNewValuesOnAllCharactersICanAttack(1, 2);

            _cardsToPlay.GetDataCardOnHandBeforeChange();

            if (player.Mana >= cardChose.mana)
            {
                activeDestroyThisCard = true;

                int countAbility = cardChose.ability.Length;
                for (int i = 0; i < countAbility; i++)
                {
                    Ability ability = cardChose.ability[i];

                    switch (ability.tag)
                    {
                        case var value when value == Global.damageCard:
                            IfDamage(ability);
                            break;
                        case var value when value == Global.healCard:
                            IfHealth(ability);
                            break;
                        case var value when value == Global.ccCard:
                            IfCC(ability);
                            break;
                        case var value when value == Global.ShuffleCard:
                            IfShuffle(ability);
                            break;
                        case var value when value == Global.ManaCard:
                            IfCardMana(ability);
                            break;
                        default:
                            Debug.Log("This Ability, don´t exist!");
                            break;
                    }
                }

                if (activeDestroyThisCard)
                    _cardsToPlay.DestroyThisCard();
                

                player.Mana -= cardChose.mana;

                ManagerGameFight.Instance.AddCardsOnHistoric(cardChose);
            }

            //clear cardChoose
            _cardsToPlay.CardChoose = new Card();

        }
    }

    private void EnemiesToPlay()
    {
        //player get full mana
        player.Mana = player.MaxMana;
        //permissed attack player if enemies not change that
        player.PermissedByAttack = true;


        foreach (GameObject item in ManagerGameFight.Instance.Manager.CharactersICanAttack)
        {
            if (item.GetComponent<Character_cls>().PermissedByAttack)
                player.Health -= Random.Range(1, 4);
        }

        if (_cardsToPlay.CardsOnHand.Count > 0)
        {
            _cardsToPlay.DestroyAllInstanceCards();
            _turn.NextTurn();
        }
    }

    //damage in character(s)
    private void IfDamage(Ability _ab)
    {
        if (_ab.type_effect == Global.cardAffectsOther) {  //if others

            if (_ab.effect_quantity == 0)
            {   //if all enemies
                ManagerGameFight.Instance.Manager.SetNewValuesOnAllCharactersICanAttack(-_ab.value, 1);

            }
            else if (_ab.effect_quantity == -1)
            {  //if a random
                ManagerGameFight.Instance.Manager.SetNewValuesOnRandomCharacter(-_ab.value, 1);

            }
            else if (_ab.effect_quantity == 1 && ManagerGameFight.Instance.Manager.NextCharacter != null)
            {
                ManagerGameFight.Instance.Manager.SetNewValuesOnCharacter(ManagerGameFight.Instance.Manager.NextCharacter, -_ab.value, 1);
            }

        } else if (_ab.type_effect == Global.cardAffectsPlayer) //if player to play
            player.Health -= _ab.value;
    }

    //heal mechanics
    private void IfHealth(Ability _ab)
    {
        if (_ab.type_effect == Global.cardAffectsPlayer)
        {
            if (_ab.effect_quantity == 1) //recive heal value
                player.Health += _ab.value;
            else if (_ab.effect_quantity == 0) //recive heal value per enemy
                player.Health += _ab.value * ManagerGameFight.Instance.Manager.CharactersICanAttack.Length;
            else if (_ab.effect_quantity == -1) //player to play recibe full hp
                player.Health = player.MaxHealth;

        }
        else if (_ab.type_effect == Global.cardAffectsOther)
        {
            if (_ab.effect_quantity == 0) //all enemies recibe heal
                ManagerGameFight.Instance.Manager.SetNewValuesOnAllCharactersICanAttack(_ab.value, 1);
            else if (_ab.effect_quantity == -1) //heal random enemy
                ManagerGameFight.Instance.Manager.SetNewValuesOnRandomCharacter(_ab.value, 1);
        }
    }

    //cc mechanics
    private void IfCC(Ability _ab)
    {
        if (_ab.type_effect == Global.cardAffectsPlayer)
            player.PermissedByAttack = !player.PermissedByAttack;
        else if (_ab.type_effect == Global.cardAffectsOther)
        {
            if (_ab.effect_quantity == 0) //all enemies dont attack
                ManagerGameFight.Instance.Manager.SetNewValuesOnAllCharactersICanAttack(_ab.value, 2);
            else if (_ab.effect_quantity == -1) //random enemy dont attack
                ManagerGameFight.Instance.Manager.SetNewValuesOnRandomCharacter(_ab.value, 2);
            else if (_ab.effect_quantity == 1) //enemy choose dont attack next round
                ManagerGameFight.Instance.Manager.SetNewValuesOnCharacter(ManagerGameFight.Instance.Manager.NextCharacter, _ab.value, 2);
        }
    }


    //shuffle mechanics
    private void IfShuffle(Ability _ab)
    {
        if (_ab.effect_quantity == 4) //discart all cards and get again 4 cards
        {
            _cardsToPlay.DestroyAllInstanceCards();
            generateCards();
            activeDestroyThisCard = false;
        }
        else if (_ab.effect_quantity == 1) //discart this card and get another
        {
            _cardsToPlay.DestroyThisCardAndGetAnother();
        }
    }

    //card mana mechanics
    private void IfCardMana(Ability _ab)
    {
        if (_ab.type_effect == Global.cardAffectsCard) 
            if (_ab.value == 0)
                _cardsToPlay.setManaAllCards(_ab.value); //next card dont cost mana
            else _cardsToPlay.subtractManaAllCards(_ab.value); //next card to play reduce mana
        else if (_ab.type_effect == Global.cardAffectsPlayer) //player get mana
            player.Mana += _ab.value;
        
    }

    //generate inicial cards
    private void generateCards()
    {
        Character_cls character_cls_player_to_game = RecibeGameObject.Instance.SpawnerList[indexCharacters].GetComponent<Character_cls>();
        //Variables Inicialization.
        if (character_cls_player_to_game.myDeck != null && character_cls_player_to_game.ClassType != Global.findEnemy)
        {
            _cardsToPlay.deckCardManager = new Card[character_cls_player_to_game.myDeck.cards.Length];
            _cardsToPlay.duplicateDeck = new Card[character_cls_player_to_game.myDeck.cards.Length];

            for (int i = 0; i < character_cls_player_to_game.myDeck.cards.Length; i++)
            {
                _cardsToPlay.deckCardManager[i] = new Card(character_cls_player_to_game.myDeck.cards[i]);
                _cardsToPlay.duplicateDeck[i] = new Card(character_cls_player_to_game.myDeck.cards[i]);
            }

            _cardsToPlay.InstanceCardsToPlay();
            
        }
    }
}


