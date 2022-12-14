using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Prefab : MonoBehaviour
{
    private int InicialMinAttack;
    private int InicialMaxAttack;
    [SerializeField] private GameObject _canvasLife;

    [HideInInspector] public float MaxHealth;
    [HideInInspector] public bool PermissedByAttack;
    [HideInInspector] public HealthBar_cls HealthBar;
    [HideInInspector] public float HeightEnemy;

    public GameObject[] Teammates = new GameObject[3];
    public int id;
    public string Name;
    public string ClassType;
    public float Health;
    public int MinAttack;
    public int MaxAttack;
    public Sprite ImageProfile;
    public bool enemyIsDead;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        HeightEnemy = GetComponent<CapsuleCollider>().height;
        HealthBar = new HealthBar_cls(SceneManager.GetActiveScene().name);
        MaxHealth = Health;
        enemyIsDead = false;
        PermissedByAttack = true;
        InicialMinAttack = MinAttack;
        InicialMaxAttack = MaxAttack;
        _animator.SetInteger("Transition", 0);
    }

    void Update()
    {
        HealthValidation();
        validateHealthBar();  
        
    }

    public void setInicialMinAndMaxAttack()
    {
        MaxAttack = InicialMaxAttack;
        MinAttack = InicialMinAttack;
    }

    public int getRangeAttack()
    {
        if (MaxAttack > 1) _animator.SetInteger("Transition", 2);
        return Random.Range(MinAttack, MaxAttack);
    }

    public void SubtractRangeAttack(int value)
    {

        MinAttack -= value;
        MaxAttack -= value;
        valitationRangeAttack();
    }


    private void HealthValidation()
    {
        if (Health <= 0) { Health = 0; enemyIsDead = true; }
        if (Health > MaxHealth) Health = MaxHealth;
    }

    private void valitationRangeAttack()
    {
        if (MinAttack < 0)
            MinAttack = 0;
        if (MaxAttack < 1)
            MaxAttack = 1;
    }

    private void validateHealthBar()
    {
        if (_canvasLife.GetComponent<LifeManager_Prefab>() != null)
        {
            _canvasLife.GetComponent<LifeManager_Prefab>()._healthbarPrefab.GetComponent<HealthBar_Prefab>().UpdateLife(Health, MaxHealth);
        }
    }

}
