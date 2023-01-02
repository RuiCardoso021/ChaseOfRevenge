using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _GO_Settings;
    [SerializeField] GameObject[] _panelsLeft;
    [SerializeField] private Texture2D _cursorTexture;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnableOrDesableSettings();
        }

        if (_GO_Settings.activeSelf)
        {
            Cursor.visible = true;
            Vector2 hotSpot = new Vector2(_cursorTexture.width / 8, _cursorTexture.height / 8);
            Cursor.SetCursor(_cursorTexture, hotSpot, CursorMode.ForceSoftware);
        }
        else
        {
            //Cursor.visible = false;
        }
    }

    public void EnableOrDesableSettings()
    {
        if (_GO_Settings != null)
        {
            if (_GO_Settings.activeSelf)
            {
                EnableOrDesablePanels(_GO_Settings);
                _GO_Settings.SetActive(false);
            } 
            else _GO_Settings.SetActive(true);
        }
    }

    public void EnableOrDesablePanels(GameObject panel)
    {
        if (_GO_Settings != null)
        {
            foreach (GameObject item in _panelsLeft)
            {
                if (item == panel) item.SetActive(true);
                else item.SetActive(false);
            }
            //_panelVolume.SetActive(false);
        }
    }

}
