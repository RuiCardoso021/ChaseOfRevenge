using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleSelection_Prefab : MonoBehaviour
{
    [HideInInspector] public GameObject CircleSelection;
    private GameObject _enemy;
    public bool setActive = false;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = this.GameObject();
        CircleSelection = Instantiate(Resources.Load(Global.lingToCircleSelection) as GameObject, _enemy.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (CircleSelection != null)
            CircleSelection.SetActive(setActive);
    }


}
