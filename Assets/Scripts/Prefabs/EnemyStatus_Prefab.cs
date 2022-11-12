using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus_Prefab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private Image _imageProfile;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _txtLife;
    public float MaxLife;
    public float health;
    public string Name;
    public Image ImageProfile;

    void Start()
    {
        Name = "Name";
        health = 1;
        health = MaxLife;
        ImageProfile = gameObject.AddComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _txtLife.text = health.ToString() + "/" + MaxLife.ToString();
        _textName.text = Name;
        _healthBar.fillAmount = health / MaxLife;
        
        if (health <= 0)
        {
            GetComponent<Image>().color = new Color(255,45,42,204);
        }
    }
}
