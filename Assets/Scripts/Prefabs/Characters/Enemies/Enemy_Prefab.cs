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

    [HideInInspector] public float MaxHealth;
    [HideInInspector] public bool PermissedByAttack;
    [HideInInspector] public HealthBar_cls HealthBar;
    [HideInInspector] public float HeightEnemy;

    public GameObject[] Teammates = new GameObject[3];
    public string Name;
    public string ClassType;
    public float Health;
    public int MinAttack;
    public int MaxAttack;
    public Sprite ImageProfile;

    // Start is called before the first frame update
    void Start()
    {
        HeightEnemy = GetComponent<CapsuleCollider>().height;
        HealthBar = new HealthBar_cls(SceneManager.GetActiveScene().name);
        MaxHealth = Health;
        PermissedByAttack = true;
        InicialMinAttack = MinAttack;
        InicialMaxAttack = MaxAttack;
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
        if (Health < 0) Health = 0;
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
        if (HealthBar!= null)
        {
            if (HealthBar.Validation)
            {
                HealthBar.GOHealthBar = Instantiate(Resources.Load(Global.linkToHealthBar) as GameObject, this.GameObject().transform);
                HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().health = Health;
                HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().MaxLife = Health;
                HealthBar.GOHealthBar.transform.RotateAroundLocal(Vector3.up, -80);
                HealthBar.Validation = false;
            }

            if (HealthBar.GOHealthBar != null)
            {
                HealthBar.GOHealthBar.GetComponent<HealthBar_Prefab>().health = Health;
                HealthBar.GOHealthBar.transform.localPosition = new Vector3(0f, HeightEnemy, 0f);
            }
        }
        
    }
}
