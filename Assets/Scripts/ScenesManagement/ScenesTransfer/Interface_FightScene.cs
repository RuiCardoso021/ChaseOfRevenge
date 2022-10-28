using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface_FightScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;

    private void Start()
    {
    }

    private void LateUpdate()
    {
        if (_mainCam != null)
        {
            var rotation = _mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }

    }
}
