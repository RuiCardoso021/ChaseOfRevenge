using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPanelGame : MonoBehaviour
{
    private GameObject _resultOnFight;
    [SerializeField] private GameObject InterfacePanel;
    [SerializeField] private GameObject PanelWin;
    [SerializeField] private GameObject PanelLose;
    private Character_Prefab _player;
    private Enemy_Prefab _enemy;
    private bool activePanel;

    private void Start()
    {
        PanelLose.SetActive(false);
        PanelWin.SetActive(false);
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
            ActivePanel(PanelLose);
        else if (ManagerGameFight.Instance.Manager.EnemiesIsDead() && activePanel)
        {
            ActivePanel(PanelWin);
            BlockSave.instance.saveWins();
            //UnblockMapAreas.Instance.FightWinCount();
            //UnblockMapAreas.Instance.UnblockArea();
        }
    }

    private void ActivePanel(GameObject panel)
    {
        if (panel != null)
        {
            activePanel = false;
            _resultOnFight = panel;
            _resultOnFight.SetActive(true);
            InterfacePanel.SetActive(false);
            ManagerGameFight.Instance.PermissedExecute = false;
        }
    }


}
