using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Prefab : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI textMeshProUGUI;

    // Update is called once per frame

    public void UpdateLife(float life, float maxlife)
    {
        textMeshProUGUI.text = life.ToString() + "/" + maxlife.ToString();
        healthBar.fillAmount = life / maxlife;
    }


}
