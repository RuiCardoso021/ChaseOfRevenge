using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectTransfer : MonoBehaviour
{
    //public GameObject enemyCharacter = null;

    public static GameObject LoadedCharacter;
    private bool teste = false;
    private string nextScene = "TransferTestScene";

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && teste == false)
        {
            teste = true;
            LoadNextScene();
        }
    }

    IEnumerator LoadSceneWithGameObject(GameObject objectToSend)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(objectToSend, SceneManager.GetSceneByName(nextScene));
        SceneManager.UnloadSceneAsync(currentScene);
    }

    public void LoadNextScene()
    {
        GameObject test = new GameObject();
        test.name = "receivedObject";
        LoadedCharacter.transform.SetParent(test.transform);

        StartCoroutine(LoadSceneWithGameObject(test));
    }


}
