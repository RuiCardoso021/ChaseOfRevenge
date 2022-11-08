using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonSkeleton : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private string _prompt;
    [SerializeField] private Dialog_cls[] _promptArray;

    public Dialog_cls[] InteractionPromptArray => _promptArray;
    public string InteractionPrompt => _prompt;
    public GameObject InteractionGameObject => _enemy;

    public GameObject GetObject => _enemy;

    

    public void ChangeScene(GameObject player){
        // create the prefab in your scene
        TransferGameObject.Instance.LoadedCharacter.Add(_enemy);

    }

    private void OnMouseDown()
    {
        _enemy = this.gameObject;
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

