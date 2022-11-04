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
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private TextMeshProUGUI _textMana;
    [SerializeField] private TextMeshProUGUI _textHealth;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        if (ManagerGameFigth.Instance.Manager.CharactersOnFight != null)
        {
            Character_cls player = ManagerGameFigth.Instance.Manager.CurrentCharacter.GetComponent<Character_cls>();
            _textHealth.text = "Health: " + player.Health.ToString();
            _textMana.text = "Mana: " + player.Mana.ToString();
            _textName.text = player.Name.ToString();          
        }

        if (_mainCam != null)
        {
            var rotation = _mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);

        }
    }
}
