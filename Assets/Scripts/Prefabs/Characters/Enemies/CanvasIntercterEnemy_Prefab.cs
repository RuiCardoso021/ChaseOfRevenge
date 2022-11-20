using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasIntercterEnemy_Prefab : MonoBehaviour
{
    private Camera _mainCam;
    private GameObject GameObjectCanvas;
    [SerializeField] private Vector3 _possitionFixed = Vector3.zero;
    public bool setAtiveCanvasLvl = false;

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
        GameObjectCanvas = Instantiate(Resources.Load(Global.linkToCanvasInteractEnemy) as GameObject, Vector3.zero, Quaternion.identity, this.GameObject().transform);
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
            float height = 0;
            if (GetComponent<CapsuleCollider>() != null)
                height = GetComponent<CapsuleCollider>().height;
            Vector3 position = _possitionFixed + new Vector3(0f, height, 0f);
            GameObjectCanvas.transform.localPosition = position;
            if (_mainCam != null)
            {
                var rotation = _mainCam.transform.rotation;
                GameObjectCanvas.transform.LookAt(GameObjectCanvas.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
            }
        }
    }
}
