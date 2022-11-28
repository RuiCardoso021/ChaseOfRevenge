using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Prefab : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI textMeshProUGUI;
    public float MaxLife { get; set; }
    public float health { get; set; }

    void Start()
    {
        health = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = health.ToString() + "/" + MaxLife.ToString();
        healthBar.fillAmount = health / MaxLife;
    }


}
