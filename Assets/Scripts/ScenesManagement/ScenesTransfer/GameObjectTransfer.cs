using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectTransfer : MonoBehaviour
{
    public static GameObjectTransfer Instance;
    public List<GameObject> LoadedCharacter = new List<GameObject>();
    private bool premission;
    [SerializeField] private string _nextSceneName = "TransferTestScene";

    private void Start() {
        Instance = this;
        premission = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.V) && premission){
            LoadedCharacter.Add(GameObject.Find(Global.findPlayer));
            LoadNextScene();
            premission = false;
        }
    }

    private IEnumerator LoadSceneWithGameObject(GameObject objectToSend)
    {
        Scene currentScene = SceneManager.GetActiveScene();
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
        gameObjectToSend.name = Global.playerPrefab;
 
        foreach (GameObject character in LoadedCharacter)
            if(character != null)
            {
                character.transform.position = Vector3.zero;
                character.transform.SetParent(gameObjectToSend.transform);
            }

        
        
        StartCoroutine(LoadSceneWithGameObject(gameObjectToSend));
    }


}
