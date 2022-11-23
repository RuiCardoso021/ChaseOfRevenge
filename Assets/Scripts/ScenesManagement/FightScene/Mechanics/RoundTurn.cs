using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundTurn : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private TextMeshProUGUI roundText;
    public bool myTurn;
    public int Round = 1;

    private void Start()
    {
        myTurn = true;
    }

    private void Update() {

        if (roundText != null)
            roundText.text = Round.ToString();

        if (ManagerGameFight.Instance.PermissedExecute)
        {
            if (myTurn)
            {
                button.SetActive(true);
            }
            else button.SetActive(false);
        }
    }

    //chenge next turn
    public void NextTurn(){
        myTurn = !myTurn;
        if (myTurn)
        {
            ManagerGameFight.Instance.AddManagerOnHistoric(Round);
            Round++;
        }
    }

    //random player move
    public void RandomFirstPlayerToMove(){
        int random = Random.Range(0, 2);
        myTurn = false;
        if (random == 0) myTurn = true;
    }

    public void ExecuteIfTrue (bool validation)
    {
        if (validation)
        {

        }
    }
}
