using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Prefab : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI _txtLife;
    public float MaxLife;
    public float health;

    void Start()
    {
        health = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        _txtLife.text = health.ToString();
        healthBar.fillAmount = health / MaxLife;
    }
}
