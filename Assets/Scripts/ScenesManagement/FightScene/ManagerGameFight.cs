﻿using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.EventSystems.EventTrigger;

public class ManagerGameFight : MonoBehaviour
{

    public static ManagerGameFight Instance;
    private const int TOTAL_HISTORIC = 100;
    private const float DELAY_TO_PLAY_GAME = 0.6f;
    //private bool validation;

    public ManagerGameFight_cls Manager;
    public HistoricGameFight_cls[] HistoricGame;
    public int IndexHistoric;
    [SerializeField] private Texture2D _cursorTexture;

    public bool PermissedExecute;

    private void Start()
    {
        Instance = this;
        //validation = false;
        Manager = new ManagerGameFight_cls();
        PermissedExecute = false;
        HistoricGame = new HistoricGameFight_cls[TOTAL_HISTORIC];
        IndexHistoric = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Vector2 hotSpot = new Vector2(_cursorTexture.width / 4, _cursorTexture.height / 4);
        Cursor.SetCursor(_cursorTexture, hotSpot, CursorMode.ForceSoftware);
        Invoke("Inicialization", DELAY_TO_PLAY_GAME);
    }

    private void Update()
    {       
        //this permisse is active after method Invoke
        if (PermissedExecute)
        {
            updateSelectionCharacter();
            //Debug.Log("Management: " + Manager.CurrentCharacter.GetComponent<Character_cls>().Health);
        }
    }

    //update checkSelectionOnPrefab
    private void updateSelectionCharacter()
    {
        if (Manager.CharactersOnFight != null)
        {
            Manager.changeCharacters();

            foreach (GameObject gm in Manager.CharactersOnFight)
            {  
                if (gm != null)
                {
                    Enemy_Config_FightScene_Prefab enemy_config = gm.GetComponent<Enemy_Config_FightScene_Prefab>();
                    if (enemy_config != null)
                    {
                        if (gm == Manager.NextCharacter) enemy_config.CircleSelection.setActive = true;
                        else enemy_config.CircleSelection.setActive = false;
                    }
                }   
            }
        }
    
    }

    private void Inicialization()
    {
        Manager.CharactersOnFight = RecibeGameObject.Instance.SpawnerList;
        Manager.SelectionCharacters();
        PermissedExecute = true;
        //Time.timeScale = 0f;
    }

    public void AddCardsOnHistoric(Card card)
    {
        HistoricGame[IndexHistoric] = ValidateHistoric(HistoricGame[IndexHistoric]);

        if (card != null)
            HistoricGame[IndexHistoric].ListCards.Add(card);

    }

    public void AddManagerOnHistoric(int round){

        HistoricGame[IndexHistoric] = ValidateHistoric(HistoricGame[IndexHistoric]);

        HistoricGame[IndexHistoric].ManagerGameFigth = Manager;
        HistoricGame[IndexHistoric].round = round;
        IndexHistoric++;
    }

    private HistoricGameFight_cls ValidateHistoric(HistoricGameFight_cls historic)
    {
        if (historic == null) historic = new HistoricGameFight_cls();

        return historic;
    }

}