using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager_Prefab : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _characterPrefab;
    public GameObject _healthbarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string _nameScene = SceneManager.GetActiveScene().name;
        if (_nameScene == "FightScene")
        {
            if (this.gameObject.activeSelf == false)
                this.gameObject.SetActive(true);

            UpdateRotation();
        }
        else
        {
            if (this.gameObject.activeSelf == true)
                this.gameObject.SetActive(false);
        }
    }

    private void UpdateRotation()
    {
        if (_mainCam == null)
            _mainCam = Camera.main;

        if (_mainCam != null)
        {
            var rotation = _mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }
    }
}
