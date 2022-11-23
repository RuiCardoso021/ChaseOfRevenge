using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferGameObject : MonoBehaviour
{
    public static TransferGameObject Instance;
    public List<GameObject> LoadedCharacter = new List<GameObject>();
    [SerializeField] private string _nextSceneName = "TransferTestScene";

    private string _lastScene;

    private void Start() {
        Instance = this;
    }

    private IEnumerator LoadSceneWithGameObject(GameObject objectToSend)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        //objectToSend.AddComponent<GameObject>();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextSceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(objectToSend, SceneManager.GetSceneByName(_nextSceneName));
        SceneManager.UnloadSceneAsync(currentScene);
    }

    public void LoadNextScene()
    {
        GameObject gameObjectToSend = new GameObject();
        gameObjectToSend.name = Global.recivedObjects;


        SendDataFromOtherScene();

        foreach (GameObject character in LoadedCharacter)
        {
            if (character != null)
                character.transform.SetParent(gameObjectToSend.transform);
        }
            
            

        StartCoroutine(LoadSceneWithGameObject(gameObjectToSend));
    }

    public void BackToScene()
    {
        if (DataTransferScene.Instance != null)
        {
            _nextSceneName = DataTransferScene.Instance.LastSceneName;
            LoadNextScene();
        }
    }

    public void ReloadScene()
    {
        //GameObject gameObjectToSend = new GameObject();
        //gameObjectToSend.name = Global.recivedObjects;
        //_nextSceneName = SceneManager.GetActiveScene().name;
        //
        //for (int i = 0; i < RecibeGameObject.Instance.SpawnerList.Length; i++)
        //{
        //    GameObject child = RecibeGameObject.Instance.ObjectPrefab.transform.GetChild(i).gameObject;
        //    LoadedCharacter.Add(child);
        //}
        //
        //foreach (GameObject character in LoadedCharacter)
        //    if (character != null)
        //    {
        //        character.transform.position = Vector3.zero;
        //        character.transform.SetParent(gameObjectToSend.transform);
        //    }

        SceneManager.LoadScene(DataTransferScene.Instance.CurrentSceneName);

        //StartCoroutine(LoadSceneWithGameObject(gameObjectToSend));
    }

    private void SendDataFromOtherScene()
    {
        GameObject GameObjectDataTransfer = new GameObject();
        GameObjectDataTransfer.name = Global.dataTransfer;
        GameObjectDataTransfer.AddComponent<DataTransferScene>();
        DataTransferScene dataTransferScene = GameObjectDataTransfer.GetComponent<DataTransferScene>();
        dataTransferScene.LastSceneName = SceneManager.GetActiveScene().name;
        dataTransferScene.CurrentSceneName = _nextSceneName;

        LoadedCharacter.Add(GameObjectDataTransfer);
    }
}
