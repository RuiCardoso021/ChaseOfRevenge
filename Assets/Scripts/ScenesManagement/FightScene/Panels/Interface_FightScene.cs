using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interface_FightScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private TextMeshProUGUI _textMana;
    [SerializeField] private TextMeshProUGUI _textHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    private float maxMana;
    private float maxHealth;
    private bool active;
    private GenerateHealthBar _healthBar;

    private void Start()
    {
        //_healthBar = GameObject.Find("GamePlay").GetComponent<GenerateHealthBar>();
        active = true;
    }

    private void Update()
    {
        
        if (ManagerGameFight.Instance.Manager.CharactersOnFight != null)
        {
            Character_cls player = ManagerGameFight.Instance.Manager.CurrentCharacter.GetComponent<Character_cls>();
            if (player != null && active)
            {
                maxMana = player.Mana;
                maxHealth = player.Health;
                active = false;
            }
            if (!active)
            {
                healthBar.fillAmount = player.Health / maxHealth;
                manaBar.fillAmount = player.Mana / maxMana;
                _textHealth.text = player.Health.ToString() + "/" + maxHealth;
                _textMana.text = player.Mana.ToString() + "/" + maxMana;
                _textName.text = player.Name.ToString();    
            }
                  
        }

        if (_mainCam != null)
        {
            var rotation = _mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);

        }
    }
}
