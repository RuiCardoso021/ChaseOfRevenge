using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject finalPanel;

    public void MainMenuButton()
    {
        // Load the main menu scene when the "Main Menu" button is clicked
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitButton()
    {
        // Quit the game when the "Quit" button is clicked
        Application.Quit();
    }

    public void GoToFinalPanel()
    {
        if (finalPanel != null)
            finalPanel.SetActive(true);
    }
}
