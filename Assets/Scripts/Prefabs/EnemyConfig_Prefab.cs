using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfig_Prefab : MonoBehaviour
{
    public GameObject[] Teammates = new GameObject[3];
    public int MinAttack;
    public int MaxAttack;
    private int InicialMinAttack;
    private int InicialMaxAttack;

    // Start is called before the first frame update
    void Start()
    {
        InicialMinAttack = MinAttack;
        InicialMaxAttack = MaxAttack;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void valitations()
    {
        if (MinAttack < 0)
            MinAttack = 0;
        if (MaxAttack < 1)
            MaxAttack = 1;
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
        valitations();
    }
}
