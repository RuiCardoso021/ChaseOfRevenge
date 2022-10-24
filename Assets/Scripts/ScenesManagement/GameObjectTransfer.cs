using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectTransfer : MonoBehaviour
{
    public static GameObjectTransfer Instance;
    public List<Character_cls> LoadedCharacter = new List<Character_cls>();
    private bool premission;
    [SerializeField] private string _nextSceneName = "TransferTestScene";


    private void Start() {
        Instance = this;
        premission = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && premission){
            GameObject test = GameObject.Find("Character_Player");
            LoadedCharacter.Add(new Character_cls (test));
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
        gameObjectToSend.transform.position = Vector3.zero;
        gameObjectToSend.name = "receivedObject";
 
        foreach (Character_cls character in LoadedCharacter)
            if(character.Obj != null)
                character.Obj.transform.SetParent(gameObjectToSend.transform);
        
        
        StartCoroutine(LoadSceneWithGameObject(gameObjectToSend));
    }


}
