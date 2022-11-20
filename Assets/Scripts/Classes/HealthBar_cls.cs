using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthBar_cls
{
    public GameObject GOHealthBar;
    public bool Validation;
    public string NameScene;

    public HealthBar_cls(string _nameScene)
    {
        GOHealthBar = null;
        NameScene = _nameScene;
        Validation = isFightScene();
    }

    private bool isFightScene() { return NameScene == Global.FightScene; }
}
