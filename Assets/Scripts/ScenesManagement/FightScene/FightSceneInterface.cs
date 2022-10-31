using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FightSceneInterface : MonoBehaviour
{
    [SerializeField] private GameObject button;
    public bool myTurn = false;

    private void Update() {
        //if (myTurn){
        //    button.SetActive(true);
        //}else button.SetActive(false);
    }

    public void NextTurn(){
        Debug.Log(!myTurn);
        myTurn = !myTurn;

    }

    public void RandomFirstPlayerToMove(){
        int random = Random.Range(0, 2);
        myTurn = false;
        if (random == 0) myTurn = true;
    }
}
