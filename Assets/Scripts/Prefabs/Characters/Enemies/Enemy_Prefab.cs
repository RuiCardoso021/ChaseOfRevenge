using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

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
    private bool effectDead = true;
    GameObject effectNumber;

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
    
    public void setValueHealth(float value)
    {
        _animator.SetInteger("Transition", 5);
        //StartCoroutine(destoryGameObject());
        Health += value;
    }
    
    IEnumerable destoryGameObject() {
        GameObject infoValues = Instantiate(Resources.Load(Global.linkToInfoValuesCharacter) as GameObject);
        yield return infoValues != null;

        Destroy(infoValues,1f);

    }

    private void HealthValidation()
    {
        if (Health <= 0) { Health = 0; enemyIsDead = true; Dead(); }
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


    public void Dead()
    {
        if (effectDead)
        {
            _animator.SetInteger("Transition", 4);
            //yield return new WaitForSeconds(1.5f);
            GameObject _effect = Instantiate(Resources.Load(Global.linkToDeadEffect) as GameObject,
                                             new Vector3(0,2f, 0),
                                             Quaternion.identity);
            //Destroy(gameObject);
            effectDead = false;
        }
    }
}
