using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Status_Prefab : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private TextMeshProUGUI _textRangeAttack;
    [SerializeField] private TextMeshProUGUI _textLife;

    private void Start()
    {
        Enemy_Prefab enemy_prefab = _characterPrefab.GetComponent<Enemy_Prefab>();
        StartStatus(enemy_prefab.Name, enemy_prefab.MinAttack, enemy_prefab.MaxAttack, enemy_prefab.Health);
    }

    // Update is called once per frame
    void Update()
    {
        string _nameScene = SceneManager.GetActiveScene().name;
        if (_nameScene == "FightScene")
        {
            if (this.gameObject.activeSelf == true)
                this.gameObject.SetActive(false);
        }
        else
        {
            if (this.gameObject.activeSelf == false)
                this.gameObject.SetActive(true);

            UpdateRotation();
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

    public void StartStatus(string name, int minAttack, int maxAttack, float life)
    {
        int maxAtta = maxAttack - 1;
        _textRangeAttack.text = minAttack.ToString() + "-" + maxAtta.ToString();
        _textName.text = name;
        _textLife.text = life.ToString();
    }

}
