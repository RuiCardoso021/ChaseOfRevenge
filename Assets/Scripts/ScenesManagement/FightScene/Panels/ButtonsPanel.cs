using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsPanel : MonoBehaviour
{
    [SerializeField] GameObject panelConfirmRestart;
    [SerializeField] GameObject panelCancelSurrender;

    public void EnableOrDesablePanelRastart()
    {
        if (panelConfirmRestart != null && panelCancelSurrender != null && !panelCancelSurrender.activeSelf)
        {
            if (panelConfirmRestart.activeSelf) panelConfirmRestart.SetActive(false);
            else panelConfirmRestart.SetActive(true);

            GamePause();
        }
    }

    public void EnableOrDesablePanelSurrender()
    {
        if (panelCancelSurrender != null && panelConfirmRestart != null && !panelConfirmRestart.activeSelf)
        {
            if (panelCancelSurrender.activeSelf) panelCancelSurrender.SetActive(false);
            else panelCancelSurrender.SetActive(true);

            GamePause();
        }

    }

    private void GamePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }

}

