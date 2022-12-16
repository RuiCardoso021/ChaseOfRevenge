using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TransferGameObject : MonoBehaviour
{
    public static TransferGameObject Instance;
    public List<GameObject> LoadedCharacter = new List<GameObject>();
    [SerializeField] private string _nextSceneName = "TransferTestScene";
    [SerializeField] private GameObject loaderUI;
    [SerializeField] private Slider progressSlider;

    private string _lastScene;

    private void Start() {
        Instance = this;
    }

    private IEnumerator LoadSceneWithGameObject(GameObject objectToSend)
    {
        progressSlider.value = 0;
        loaderUI.SetActive(true);
        Scene currentScene = SceneManager.GetActiveScene();
        //objectToSend.AddComponent<GameObject>();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextSceneName, LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;
        float progress = 0f;

        while (!asyncLoad.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncLoad.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncLoad.allowSceneActivation = true;
            }
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
        Time.timeScale = 1;
        LoadedCharacter.Add(GameObject.Find(Global.findPlayer));
        LoadNextScene();
        Destroy(RecibeGameObject.Instance.ObjectPrefab);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        RecibeGameObject.Instance.ObjectPrefab.SetActive(true);
        DontDestroyOnLoad(RecibeGameObject.Instance.ObjectPrefab);
        SceneManager.LoadScene(DataTransferScene.Instance.CurrentSceneName);
    }

    public void ReloadTownScene()
    {   
        //PRECISO PASSAR A CLASSE E DAR INSTANCIA EM VEZ DE FAZER FINDPLAYER
        //add Player;
        LoadedCharacter.Add(GameObject.Find(Global.findPlayer));
        
        //createGameObject
        GameObject gameObjectToSend = new GameObject();
        gameObjectToSend.name = Global.recivedObjects;


        SendDataFromOtherScene();

        foreach (GameObject character in LoadedCharacter)
        {
            if (character != null)
                character.transform.SetParent(gameObjectToSend.transform);
        }
        SendDataFromOtherScene();
        DontDestroyOnLoad(gameObjectToSend);
        SceneManager.LoadScene("TownCity");
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
