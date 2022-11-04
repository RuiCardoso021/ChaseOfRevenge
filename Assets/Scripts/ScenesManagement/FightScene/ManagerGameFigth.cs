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

public class ManagerGameFigth : MonoBehaviour
{
    public static ManagerGameFigth Instance;
    public ManagerGameFigth_cls Manager;
    public HistoricGameFight_cls[] HistoricGame;
    public int IndexHistoric;

    private bool _validation;
    private GameObject LoadingPanel;

    private void Start()
    {
        LoadingPanel = Resources.Load(Global.linkToPanelLoading) as GameObject;
        Instantiate(LoadingPanel);
        Instance = this;
        Manager = new ManagerGameFigth_cls();
        _validation = true;
        HistoricGame = new HistoricGameFight_cls[100];
        IndexHistoric = 0;
        Invoke("Inicialization", 3.5f);
    }

    private void Update()
    {
        //this permisse is active after method Invoke
        if (!_validation)
        {
            Debug.Log("Management: " + Manager.CurrentCharacter.GetComponent<Character_cls>().Health);
        }
    }

    public void changeCharacters()
    {

    }

    private void Inicialization()
    {
        Manager.CharactersOnFight = RecibeGameObject.Instance.SpawnerList;
        Manager.SelectionCharacters();
        _validation = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        LoadingPanel.SetActive(false);
    }



}