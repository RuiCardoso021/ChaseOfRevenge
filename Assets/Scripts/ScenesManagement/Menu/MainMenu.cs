
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public void PlayGame() {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
