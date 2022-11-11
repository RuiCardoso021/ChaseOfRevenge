﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ManagerGameFight_cls {

    public GameObject[] CharactersOnFight;
    public GameObject CurrentCharacter;
    public GameObject NextCharacter;
    public GameObject[] CharactersICanAttack;


    public void changeCharacters()
    {
        CurrentCharacter = NextCharacter;
        NextCharacter = CharactersOnFight[ValidationNextIndex(GetIndexCharactersOnFight(CurrentCharacter)+1)];
    }

    //
    private int ValidationNextIndex(int index)
    {
        if (index > CharactersOnFight.Length)
            index = 0;

        return index;
    }

    private int GetIndexCharactersOnFight(GameObject gameObject)
    {

        for (int i = 0; i < CharactersOnFight.Length; i++)
            if (CharactersOnFight[i] == gameObject) return i;

        return -1;
        
    }

    //set default characters values
    public void SelectionCharacters()
    {
        bool firstFriend = true;
        bool firstEnemy = true;
        int i = 0;
        CharactersICanAttack = new GameObject[countEnemys()];

        foreach (GameObject gameObject in CharactersOnFight)
        {
            //get first friend
            if (IsFriend(gameObject.GetComponent<Character_cls>()) && firstFriend)
            {
                CurrentCharacter = gameObject;
                firstFriend = false;
            }
            //get first enemy
            else if (IsEnemy(gameObject.GetComponent<Character_cls>()) && firstEnemy)
            {


                NextCharacter = gameObject;
                firstEnemy = false;
            }

            //search all enemies
            if (IsEnemy(gameObject.GetComponent<Character_cls>())){
                CharactersICanAttack[i] = gameObject;
                i++;

                gameObject.AddComponent<Enemy_Config_FightScene_Prefab>();
            }
        }

        CharactersICanAttack[0] = NextCharacter;

    }

    //return a total number of enemys existe
    private int countEnemys()
    {
        int count = 0;
        foreach (GameObject gameObject in CharactersOnFight)
            if (IsEnemy(gameObject.GetComponent<Character_cls>()))
                count++;
        return count;
    }


    //return true if was a friend
    public bool IsFriend(Character_cls character)
    {
        return (character.ClassType == Global.archerPlayerType
            || character.ClassType == Global.warriorPlayerType
            || character.ClassType == Global.magePlayerType
            );
    }

    //return true if was enemy
    private bool IsEnemy(Character_cls character)
    {
        return (character.ClassType == Global.findEnemy);
    }

    /*----------------change values on gameobject---------------------*/
    //gm - gameobject do you need change
    //intValue - value to set on data
    //selection - Whant data you can change (0 - Mana / 1 - Health / 3 - Deck)
    public void SetNewValuesOnCharacter(GameObject gm, int value, int selection)
    {
        if (gm != null)
        {
            Character_cls character = CharactersOnFight[GetIndexCharactersOnFight(gm)].GetComponent<Character_cls>();

            if (character != null)
            {
                if (selection == 0) character.Mana += value;
                else if (selection == 1) character.Health += value;
            }          
        }
    }

    /*----------------change values on characters i can attack---------------------*/
    //intValue - value to set on data
    //selection - Whant data you can change (0 - Mana / 1 - Health)
    public void SetNewValuesOnAllCharactersICanAttack(int value, int selection)
    {
        foreach (GameObject item in CharactersICanAttack)
        {
            Character_cls character = item.GetComponent<Character_cls>();

            if (character != null)
            {
                if (selection == 0) character.Mana += value;
                else if (selection == 1) character.Health += value;
            }
        }  
    }

    /*----------------change values on random characters---------------------*/
    //intValue - value to set on data
    //selection - Whant data you can change (0 - Mana / 1 - Health)
    public void SetNewValuesOnRandomCharacter(int value, int selection)
    {
        int random = Random.Range(0, CharactersICanAttack.Length+1);

        SetNewValuesOnCharacter(CharactersICanAttack[random], value, selection);
    }

}
