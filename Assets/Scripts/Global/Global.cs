using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Global 
{
    // 3 personagens 
    public string playerMageName = "Magus Raven";
    public string linkToMagus = "Character_Player/Magus Raven";
    public string playerWarriorName = "Miles Raven";
    public string linkToMiles = "Character_Player/Miles Raven";
    public string playerArcherName = "Flora Raven";
    public string linkToFlora = "Character_Player/Flora Raven";

    // tipos de carta de personagem
    public string magePlayerType = "SORCE";
    public string warriorPlayerType = "WAR";
    public string archerPlayerType = "ARCH";
    public string neutralCard = "UN";

    // recetor do efeito da carta
    public string cardAffectsPlayer = "Me";
    public string cardAffectsOther = "Other";
    public string cardAffectsCard = "Card";

    // find game objects
    public string findPlayer = "Character_Player";
    public string findEnemy = "Enemy";
    public string playerPrefab = "receivedObject";
    public string characterChosen = "CharacterSelected";

    // health bar
    public string healthBar = "FightSceneComponents/HealthBar";

    // tipos de cartas
    public string attackCard = "Attack";
    public string damageCard = "Damage";
    public string healCard = "Heal";
    public string ccCard = "CC";

    // cartas objeto
    public string cardOnHand = "CardOnHand";
    public string cardPrefab = "Card/Canvas";
    public string cardImage = "imagesCards/";

    // gameplay
    public string gameplayObject = "GamePlay";
    public string cardInventoryObject = "CardInventory";
}
