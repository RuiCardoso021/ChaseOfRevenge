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
    private int index;
    [SerializeField] private GameObject rewardCanvas;

    private IInteractable _interactable;

    private void Start()
    {
        index = 0;
    }

    private void Update() {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactionMask);

        if (_numFound > 0 ){
            
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null){

                //if(!_interactionPromptUI.isDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Input.GetKeyDown(KeyCode.E)){

                    TransferGameObject.Instance.LoadedCharacter.Add(_player);
                    GameObject tempEnemy = _interactable.GetInteractionGameObject;
                    tempEnemy.name = Global.findEnemy;
                    TransferGameObject.Instance.LoadedCharacter.Add(tempEnemy);
                    //TransferGameObject.Instance.LoadedCharacter.Add(tempEnemy);
                    TransferGameObject.Instance.LoadNextScene();
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {          
                    if (_interactable.GetInteractionGameObject != null)
                    {
                        if (index < _interactable.InteractionPromptArray.Length)
                        {
                            if (_interactable.InteractionPromptArray[index].CanSpeak == "Player")
                            {
                                _interactionPromptUI.SetUp(".:" + _player.GetComponent<Character_Prefab>().Name + ":. \n\n " +  _interactable.InteractionPromptArray[index].Dialog);
                            }
                            else
                            {
                                
                                _interactionPromptUI.SetUp(".:" + _interactable.GetInteractionGameObject.GetComponent<Enemy_Prefab>().Name + ":. \n\n " + _interactable.InteractionPromptArray[index].Dialog);
                            }
                            
                            index++;
                        }
                        else if (index == _interactable.InteractionPromptArray.Length)
                        {
                            if (_interactionPromptUI.isDisplayed) _interactionPromptUI.Close();
                        }
                    }
                    
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (_interactable.GetInteractionGameObject != null)
                    {
                        rewardCanvas.SetActive(true);
                    }
                    else
                    {
                        rewardCanvas.SetActive(false);
                    }

                }
            }

        }else{
            index = 0;
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.isDisplayed) _interactionPromptUI.Close();
            
        }
    }
}
