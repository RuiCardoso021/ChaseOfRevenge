using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    private void Start() {
        if (_mainCam != null) _mainCam = Camera.main;  
        _uiPanel.SetActive(false);
    }

    private void LateUpdate() {
        if (_mainCam != null){
            var rotation = _mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }

    }

    public bool isDisplayed = false;

    public void SetUp(string promptText){
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close(){
        _uiPanel.SetActive(false);
        isDisplayed = false;
    }
}
