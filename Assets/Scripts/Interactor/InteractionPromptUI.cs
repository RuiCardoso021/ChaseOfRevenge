using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;
    public bool isDisplayed;

    private void Start() {
        isDisplayed = false;
        _uiPanel.SetActive(false);
    }

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
