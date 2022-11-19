using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {

     public Dialog_cls[] InteractionPromptArray { get; }

     public GameObject GetInteractionGameObject { get;}

     public void ChangeScene(GameObject player);

     //public bool Interact(Interactor interactor);

     //public void InteractFunction(Interactor interactor);
}