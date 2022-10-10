using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class CubeTest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor){

        var Inventory = interactor.GetComponent<Inventory>();

        if(Inventory == null) return false;

        if(Inventory.Haskey) {
            //SceneManager.LoadScene(2);
            Debug.Log("Olá Manel");
            return true;
        }
        
        Debug.Log("Adeus Manel");
       return false;
    }
}

