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

    private void Start()
    {
        //_healthBar = GameObject.Find("GamePlay").GetComponent<GenerateHealthBar>();
        active = true;
    }

    private void Update()
    {
        
        if (ManagerGameFight.Instance.Manager.CharactersOnFight != null)
        {
            Character_Prefab player = ManagerGameFight.Instance.Manager.CurrentCharacter.GetComponent<Character_Prefab>();
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
    }
}
