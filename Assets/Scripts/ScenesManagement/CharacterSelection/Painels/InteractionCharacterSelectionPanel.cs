using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionCharacterSelectionPanel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textName;
    //[SerializeField] private Image _imageProfile;
    [SerializeField] private TextMeshProUGUI _txtLife;
    [SerializeField] private TextMeshProUGUI _txtMana;
    [SerializeField] private TextMeshProUGUI _txtClassType;
    [SerializeField] private Image _healthBar;

    public string Name;
    public float Health;
    public int Mana;
    public string ClassType;

    // Start is called before the first frame update
    void Start()
    {
        Health = 1;
        Name = "Nick Name";
        Mana = 1;
        ClassType = "class";
    }

    // Update is called once per frame
    void Update()
    {

        _textName.text = Name;
        _txtLife.text = Health.ToString();
        _txtMana.text = Mana.ToString();
        _txtClassType.text = ClassType;
        _healthBar.fillAmount = Health / Health;
    }
}
