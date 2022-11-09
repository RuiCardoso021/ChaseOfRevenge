using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
        foreach (GameObject gameObject in CharactersOnFight)
        {
            if (IsFriend(gameObject.GetComponent<Character_cls>()) && firstFriend)
            {
                CurrentCharacter = gameObject;
                firstFriend = false;
            }
            else if (IsEnemy(gameObject.GetComponent<Character_cls>()) && firstEnemy)
            {
                NextCharacter = gameObject;
                firstEnemy = false;
            }

            if (IsEnemy(gameObject.GetComponent<Character_cls>())){
                gameObject.AddComponent<Enemy_Config_FightScene_Prefab>();
            }
        }

        CharactersICanAttack = new GameObject[countEnemys()];
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

}
