using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactionMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    [SerializeField] private GameObject _player;
    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    private Global global = new Global();

    private void Update() {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactionMask);

        if (_numFound > 0 ){
            
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null){

                if(!_interactionPromptUI.isDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Input.GetKeyDown(KeyCode.E)){
                    GameObjectTransfer.Instance.LoadedCharacter.Add(_player);
                    GameObject tempEnemy = _interactable.InteractionGameObject;
                    tempEnemy.name = global.findEnemy;
                    GameObjectTransfer.Instance.LoadedCharacter.Add(tempEnemy);
                    GameObjectTransfer.Instance.LoadNextScene();
                }
            }

        }else{
                if (_interactable != null) _interactable = null;
                if (_interactionPromptUI.isDisplayed) _interactionPromptUI.Close();
            
        }
    }
}
