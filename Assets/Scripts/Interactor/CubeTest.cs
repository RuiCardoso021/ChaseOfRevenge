using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeTest : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public GameObject Player => _player;
    public GameObject Enemy => _enemy;

    public void ChangeScene(){
        SceneManager.LoadScene(2);
        
    }

    //public bool Interact(Interactor interactor){
//
    //    var Inventory = interactor.GetComponent<Inventory>();
//
    //    if(Inventory == null) return false;
//
    //    if(Inventory.Haskey) {
    //        //SceneManager.LoadScene(2);
    //        
    //        Debug.Log("Olá Manel");
    //        return true;
    //    }
    //    
    //    Debug.Log("Adeus Manel");
    //   return false;
    //}

      
}

