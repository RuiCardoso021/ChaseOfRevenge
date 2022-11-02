using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GamePlayFight : MonoBehaviour
{

    private FightSceneInterface _turn;
    private Deck _deck;
    public GenerateCard _cardsToPlay ;
    private bool validate;
    private int totalCharactersOnFight;
    private int indexCharacters;
    private Character_cls player;
    private Character_cls enemy;
    private int manaRound;
    private FinalPanelGame uiFinalPanel;

    public void Start()
    {
        uiFinalPanel = GetComponent<FinalPanelGame>();
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
            uiFinalPanel.FightOutcome();
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
                                }else if(ability.effect_quantity == 1)
                                {
                                    _cardsToPlay.DestroyThisCardAndGetAnother(player.myDeck);
                                }
                                break;
                            default:
                                Debug.Log("This Ability, don´t exist!");
                                break;
                        }
                    }

                    if (activeDestroyThisCard) _cardsToPlay.DestroyThisCard();

                    player.Mana -= cardChose.mana;
                }

                
                _cardsToPlay.CardChoose = new Card();

                if (player.Mana == 0) _turn.NextTurn();
            }

        }
        else
        {
            player.Mana = 4;

            player.Health -= Random.Range(1, 7);
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


