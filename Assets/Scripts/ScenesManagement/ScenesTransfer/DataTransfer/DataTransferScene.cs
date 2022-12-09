using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class DataTransferScene : MonoBehaviour
{
    public static DataTransferScene Instance;

    public string LastSceneName;
    public string CurrentSceneName;
    public GameObject Spawn;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Debug.Log("Last: " + LastSceneName + "Cur: " + CurrentSceneName);
    }
}
