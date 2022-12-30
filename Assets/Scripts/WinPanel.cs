using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    GameObject winPanel;
    GameObject finalPanel;

    public void MainMenuButton()
    {
        // Load the main menu scene when the "Main Menu" button is clicked
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        // Quit the game when the "Quit" button is clicked
        Application.Quit();
    }

    public void GoToFinalPanel()
    {
        winPanel.SetActive(false);
        finalPanel.SetActive(true);
    }
}
