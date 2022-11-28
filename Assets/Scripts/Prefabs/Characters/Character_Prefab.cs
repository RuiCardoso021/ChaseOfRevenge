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
        HealthBar = new HealthBar_cls(SceneManager.GetActiveScene().name);
        myDeck = new Deck();
        Deck deck = new Deck();     
        deck = JsonUtility.FromJson<Deck>(jsonFile.text);
        List<Card> inventoryCards = new List<Card>();
        MaxHealth = Health;
        MaxMana = Mana;
        PermissedByAttack = true;

        foreach (Card card in deck.cards)
        {
            if (card.type == ClassType || card.type == Global.universalCard)
            {
                inventoryCards.Add(card);
            }
        }
        myDeck.cards = inventoryCards.ToArray();
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
        if (HealthBar.Validation)
        {
            HealthBar.GOHealthBar = Instantiate(Resources.Load(Global.linkToHealthBar) as GameObject, this.GameObject().transform);
            HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().health = Health;
            HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().MaxLife = Health;
            HealthBar.GOHealthBar.transform.RotateAroundLocal(Vector3.up, 80);
            //HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().healthBar.GetComponent<Image>().fillOrigin = 1;
            HealthBar.Validation = false;
        }

        if (HealthBar.GOHealthBar != null)
        {
            HealthBar.GOHealthBar.transform.localPosition = new Vector3(0f, HeightPlayer, 0f);
            HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().health = Health;
            HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().healthBar.GetComponent<Image>().fillOrigin = 1;
        }
    }
}

