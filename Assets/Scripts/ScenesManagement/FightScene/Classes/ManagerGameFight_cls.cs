using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using Random = UnityEngine.Random;

public class ManagerGameFight_cls {

    public GameObject[] CharactersOnFight;
    public GameObject CurrentCharacter;
    public GameObject NextCharacter;
    public GameObject[] CharactersICanAttack;
    public GameObject[] CharactersSelection;

    public void changeCharacters()
    {

        if (NextCharacter.GetComponent<Enemy_Prefab>() != null && NextCharacter.GetComponent<CircleSelection_Prefab>())
        {
            if (NextCharacter.GetComponent<Enemy_Prefab>().enemyIsDead)
            {
                NextCharacter.GetComponent<CircleSelection_Prefab>().setActive = false;
                NextCharacter = CharactersOnFight[GetNextIndexCharactersOnFight(NextCharacter)];
                NextCharacter.GetComponent<CircleSelection_Prefab>().setActive = true;
            }
        }
    }

    //return next index if existe gameobject to send
    private int GetNextIndexCharactersOnFight(GameObject gameObject)
    {
        int index = GetIndexCharactersOnFight(gameObject);
        int nextIndex = index;
        
        do
        {
            nextIndex++;
            if (nextIndex >= CharactersOnFight.Length) nextIndex = 1;
        } while (CharactersOnFight[nextIndex] == null);


        for (int i = 1; i < CharactersOnFight.Length; i++)
        {
            if (CharactersOnFight[i] != null)
                if (i == nextIndex) return i;
        }


        return -1;
    }

    //return index if existe gameobject to send
    private int GetIndexCharactersOnFight(GameObject gameObject)
    {
        for (int i = 0; i < CharactersOnFight.Length; i++)
        {
            if (CharactersOnFight[i] != null)
                if (CharactersOnFight[i] == gameObject) return i;
        }
            

        return -1;   
    }

    //set default characters values
    public void SelectionCharacters()
    {
        bool firstFriend = true;
        bool firstEnemy = true;
        int i = 0;
        CharactersICanAttack = new GameObject[countEnemys()];
        CharactersSelection = new GameObject[countEnemys()];

        foreach (GameObject gameObject in CharactersOnFight)
        {
            if (gameObject != null)
            {
                //get first friend
                if (gameObject.GetComponent<Character_Prefab>() != null && firstFriend)
                {
                    CurrentCharacter = gameObject;
                    firstFriend = false;
                }
                //get first enemy
                else if (gameObject.GetComponent<Enemy_Prefab>() != null && firstEnemy)
                {
                    NextCharacter = gameObject;
                    firstEnemy = false;
                }

                //search all enemies
                if (gameObject.GetComponent<Enemy_Prefab>() != null)
                {
                    CharactersICanAttack[i] = gameObject;
                    i++;

                    gameObject.AddComponent<Enemy_Config_FightScene_Prefab>();
                }
            }  
        }

    }

    //return a total number of enemys existe
    private int countEnemys()
    {
        int count = 0;
        foreach (GameObject gameObject in CharactersOnFight)
            if (gameObject != null)
                if (gameObject.GetComponent<Enemy_Prefab>() != null)
                    count++;

        return count;
    }

    /*----------------change values on gameobject---------------------*/
    //gm - gameobject do you need change
    //intValue - value to set on data
    //selection - Whant data you can change (1 - Health / 2 - PermissedByAttack / 3 - Attack power)
    public void SetNewValuesOnCharacter(GameObject gm, int value, int selection)
    {
        if (gm != null)
        {
            Enemy_Prefab character = CharactersOnFight[GetIndexCharactersOnFight(gm)].GetComponent<Enemy_Prefab>();

            if (character != null)
            {
                if (selection == 1) character.setValueHealth(value);
                else if (selection == 2)
                {
                    bool validation = false;
                    if (value != 0) validation = true;
                    character.PermissedByAttack = validation;
                }
                else if (selection == 3)
                    CharactersOnFight[GetIndexCharactersOnFight(gm)].GetComponent<Enemy_Prefab>().SubtractRangeAttack(value);
            }          
        }
    }

    /*----------------change values on characters i can attack---------------------*/
    //intValue - value to set on data
    //selection - Whant data you can change (1 - Health / 2 - PermissedByAttack / 3 - Attack power)
    public void SetNewValuesOnAllCharactersICanAttack(int value, int selection)
    {

        foreach (GameObject item in CharactersICanAttack)
        {
            Enemy_Prefab character = CharactersOnFight[GetIndexCharactersOnFight(item)].GetComponent<Enemy_Prefab>();

            if (character != null && !character.enemyIsDead)
            {
                if (selection == 1)
                {
                    character.setValueHealth(value);
                }
                else if (selection == 2)
                {
                    bool validation = false;
                    if (value != 0) validation = true;
                    character.PermissedByAttack = validation;
                }
                else if (selection == 3)
                    CharactersOnFight[GetIndexCharactersOnFight(item)].GetComponent<Enemy_Prefab>().SubtractRangeAttack(value); 
            }
        }
    }

    /*----------------change values on random characters---------------------*/
    //intValue - value to set on data
    //selection - Whant data you can change (1 - Health / 2 - PermissedByAttack / 3 - Attack power)
    public void SetNewValuesOnRandomCharacter(int value, int selection)
    {
        int random;
        do {
            random = Random.Range(0, CharactersICanAttack.Length);
        } while (CharactersICanAttack[random].GetComponent<Enemy_Prefab>().enemyIsDead);

        SetNewValuesOnCharacter(CharactersICanAttack[random], value, selection);
    }

    //return true if player dead
    public bool PlayerIsDead()
    {
        return (CurrentCharacter.GetComponent<Character_Prefab>().Health <= 0);
    }

    //return true if all enemies dead
    public bool EnemiesIsDead()
    {
        int enemiesDead = 0;
        foreach (var item in CharactersICanAttack)
        {
            if(item != null)
            {
                if (item.GetComponent<Enemy_Prefab>().enemyIsDead) enemiesDead++;
            }
        }

        return (countEnemys() == enemiesDead);
    }
}
