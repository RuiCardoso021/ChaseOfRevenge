using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {

     public string InteractionPrompt{get;}

    public Dialog_cls[] InteractionPromptArray { get; }

     public GameObject InteractionGameObject{get;}

     public GameObject GetObject { get; }

     public void ChangeScene(GameObject player);

     //public bool Interact(Interactor interactor);

     //public void InteractFunction(Interactor interactor);
}