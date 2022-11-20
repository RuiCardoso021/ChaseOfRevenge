using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPanelGame : MonoBehaviour
{
    private GameObject _resultOnFight;
    private Character_Prefab _player;
    private Enemy_Prefab _enemy;
    private bool activePanel;

    private void Start()
    {
        activePanel = true;
    }

    private void Update()
    {
        if (ManagerGameFight.Instance.PermissedExecute)
            FightOutcome();
    }

    public void FightOutcome()
    {   
        if (ManagerGameFight.Instance.Manager.PlayerIsDead() && activePanel)
            ActivePanel(Global.linkToPanelLose);
        else if (ManagerGameFight.Instance.Manager.EnemiesIsDead() && activePanel)
            ActivePanel(Global.linkToPanelWin);
    }

    private void ActivePanel(string linkPanelSetActive)
    {
        _resultOnFight = Resources.Load(linkPanelSetActive) as GameObject;
        Instantiate(_resultOnFight);
        activePanel = false;
    }


}
