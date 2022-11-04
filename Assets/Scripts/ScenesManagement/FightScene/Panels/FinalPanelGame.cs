using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPanelGame : MonoBehaviour
{
    private GameObject _resultOnFight;
    private Character_cls _player;
    private Character_cls _enemy;
    private bool activePanel;

    private void Start()
    {
        activePanel = true;
    }

    private void Update()
    {
        GetPlayersOnScene();
        FightOutcome();
    }

    private void GetPlayersOnScene()
    {
        if (ManagerGameFigth.Instance.Manager.CharactersOnFight != null)
        {
            _player = ManagerGameFigth.Instance.Manager.CurrentCharacter.GetComponent<Character_cls>();
            _enemy = ManagerGameFigth.Instance.Manager.NextCharacter.GetComponent<Character_cls>();
        }
    }

    public void FightOutcome()
    {
        if (_player != null && _enemy != null)
            if (_player.Health <= 0 && activePanel)
                ActivePanel(Global.linkToPanelLose);
            else if (_enemy.Health <= 0 && activePanel)
                ActivePanel(Global.linkToPanelWin);
    }

    private void ActivePanel(string linkPanelSetActive)
    {
        _resultOnFight = Resources.Load(linkPanelSetActive) as GameObject;
        Instantiate(_resultOnFight);
        activePanel = false;
    }


}
