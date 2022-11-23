using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Prefab : MonoBehaviour
{
    public Image healthBar;
    public float MaxLife;
    public float health;

    void Start()
    {
        health = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / MaxLife;
    }
}
