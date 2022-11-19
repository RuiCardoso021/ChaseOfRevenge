using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasIntercterEnemy_Prefab : MonoBehaviour
{
    private Camera _mainCam;
    private GameObject GameObjectCanvas;
    [SerializeField] private float heightPosition = 3f;
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
        if (GameObjectCanvas != null)
        {
            GameObjectCanvas.transform.localPosition = new Vector3(0f, heightPosition, 0f);
            if (_mainCam != null)
            {
                var rotation = _mainCam.transform.rotation;
                GameObjectCanvas.transform.LookAt(GameObjectCanvas.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObjectCanvas != null)
            GameObjectCanvas.SetActive(setAtiveCanvasLvl);
    }
}
