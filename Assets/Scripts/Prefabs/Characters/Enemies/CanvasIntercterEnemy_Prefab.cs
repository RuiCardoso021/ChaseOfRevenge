using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasIntercterEnemy_Prefab : MonoBehaviour
{
    private Camera _mainCam;
    private GameObject GameObjectCanvas;
    [SerializeField] private float height;
    [SerializeField] private GameObject gmFather;
    public bool setAtiveCanvasLvl = false;

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
        GameObjectCanvas = Instantiate(Resources.Load(Global.linkToCanvasInteractEnemy) as GameObject, gmFather.transform);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        setPositionAboveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObjectCanvas != null)
            GameObjectCanvas.SetActive(setAtiveCanvasLvl);
    }

    private void setPositionAboveCharacter()
    {
        if (GameObjectCanvas != null)
        {
            GameObjectCanvas.transform.localPosition = new Vector3(height, 0f, 0f);
            if (_mainCam != null)
            {
                var rotation = _mainCam.transform.rotation;
                GameObjectCanvas.transform.LookAt(GameObjectCanvas.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
            }
        }
    }
}
