using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPanelGame : MonoBehaviour
{
    private GameObject _panelWin;
    private GameObject _panelLose;
    private Character_cls _player;
    private Character_cls _enemy;

    private void Start()
    {
        _panelWin = GameObject.Find(Global.linkToPanelWin);
        _panelLose = GameObject.Find(Global.linkToPanelLose);
        _panelLose.SetActive(false);
        _panelWin.SetActive(false);
    }

    private void Update()
    {

        if (RecibeCharactersFight.Instance.SpawnerList[1] != null)
        {
            _player = RecibeCharactersFight.Instance.SpawnerList[0].GetComponent<Character_cls>();
            _enemy = RecibeCharactersFight.Instance.SpawnerList[1].GetComponent<Character_cls>();
        }
    }

    public void FightOutcome()
    {
        if (_player != null && _enemy != null)
        {
            // painel de vitoria/derrota
            if (_player.Health <= 0)
            {
                // reset fight ou voltar ao mapa
                LoseFight();

            }
            else if (_enemy.Health <= 0)
            {
                // aparecer painel de vitoria
                WinFight();
            }
        }

    }

    private void LoseFight()
    {
        _panelLose.SetActive(true);
    }

    public void RestartFight()
    {
        bool gameHasEnded = false;
        float restartDelay = 1f;

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver!");
            Invoke("RestartFightScene", restartDelay);
        }
    }

    public void RestartFightScene()
    {
        GameObjectTransfer.Instance.ReloadScene();
    }

    private void WinFight()
    {
        _panelWin.SetActive(true);
    }

    public void BackToSceneAfterWin()
    {
        SceneManager.LoadScene("FinalMap");
        _enemy.gameObject.SetActive(false);
    }
}
