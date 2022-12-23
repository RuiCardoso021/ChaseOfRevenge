using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Character_Prefab : MonoBehaviour
{

    [SerializeField] private TextAsset jsonFile;
    [SerializeField] private GameObject _canvasLife;

    [HideInInspector] public bool PermissedByAttack;
    [HideInInspector] public int MaxMana;
    [HideInInspector] public float MaxHealth;
    [HideInInspector] public HealthBar_cls HealthBar;
    [HideInInspector] public float HeightPlayer;

    public string Name;
    public int Mana;
    public string ClassType;
    public float Health;
    public Sprite ImageProfile;
    public Deck myDeck;
    private Animator animator;

    private void Start()
    {
        HeightPlayer = GetComponent<PlayerMovement>().playerHeight;
        animator = GetComponentInChildren<Animator>();

        myDeck = JsonUtility.FromJson<Deck>(jsonFile.text);
        myDeck.GetInicialCards(ClassType);
        MaxHealth = Health;
        MaxMana = Mana;
        PermissedByAttack = true;
    }


    private void Update()
    {
        HealthValidation();
        ManaValidation();
        validateHealthBar();
    }

    private void HealthValidation()
    {
        if (Health < 0) Health = 0;
        if (Health > MaxHealth) Health = MaxHealth;
    }

    private void ManaValidation()
    {
        if (Mana < 0) Mana = 0;
    }

    public void HealthUpdate(float value)
    {
        Health += value;
        if (value < 0)
        {
            animator.SetInteger("Transition", 3);
            
        }
    }

    private void validateHealthBar()
    {
        if (_canvasLife != null)
        {
            if (_canvasLife.GetComponent<LifeManager_Prefab>() != null)
            {
                _canvasLife.GetComponent<LifeManager_Prefab>()._healthbarPrefab.GetComponent<HealthBar_Prefab>().UpdateLife(Health, MaxHealth);
            }
        }
        
    }
}

