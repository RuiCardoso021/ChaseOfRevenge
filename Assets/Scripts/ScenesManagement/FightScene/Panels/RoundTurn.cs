using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundTurn : MonoBehaviour
{
    [SerializeField] private GameObject button;
    public bool myTurn = false;
    public int Round = 1;

    private void Update() {
        if (myTurn){
            button.SetActive(true);
        }else button.SetActive(false);
    }

    public void NextTurn(){
        myTurn = !myTurn;
        if (myTurn)
        {
            ManagerGameFight.Instance.AddManagerOnHistoric(Round);
            Round++;
        }
    }

    public void RandomFirstPlayerToMove(){
        int random = Random.Range(0, 2);
        myTurn = false;
        if (random == 0) myTurn = true;
    }
}
