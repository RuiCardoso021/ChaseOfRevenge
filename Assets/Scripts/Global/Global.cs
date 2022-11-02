using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Global 
{
    // 3 personagens 
    public static string playerMageName = "Magus Raven";
    public static string linkToMagus = "Character_Player/Magus Raven";
    public static string playerWarriorName = "Miles Raven";
    public static string linkToMiles = "Character_Player/Miles Raven";
    public static string playerArcherName = "Flora Raven";
    public static string linkToFlora = "Character_Player/Flora Raven";
           
    // tipos de carta de personagem
    public static string magePlayerType = "SORCE";
    public static string warriorPlayerType = "WAR";
    public static string archerPlayerType = "ARCH";
    public static string universalCard = "UN";
        
    // recetor do efeito da carta
    public static string cardAffectsPlayer = "Me";
    public static string cardAffectsOther = "Other";
    public static string cardAffectsCard = "Card";
        
    // find game objects
    public static string findPlayer = "Character_Player";
    public static string findEnemy = "Enemy";
    public static string playerPrefab = "receivedObject";
    public static string characterChosen = "CharacterSelected";
        
    // health bar
    public static string healthBar = "FightSceneComponents/HealthBar";
         
    // tipos de cartas
    public static string attackCard = "Attack";
    public static string damageCard = "Damage";
    public static string healCard = "Heal";
    public static string ccCard = "CC";
    public static string ShuffleCard = "Shuffle";
    public static string BuffCard = "Buff";

    // card objeto
    public static string cardOnHand = "CardOnHand";
    public static string cardPrefab = "Card/Canvas";
    public static string cardImage = "imagesCards/";
          
    // game play
    public static string gameplayObject = "GamePlay";
    public static string cardInventoryObject = "CardInventory";

    //panel lose/win da fight scene
    public static string linkToPanelLose = "PanelLoseCanvas";
    public static string linkToPanelWin = "PanelWinCanvas";
}
