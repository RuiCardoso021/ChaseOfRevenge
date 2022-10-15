
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
