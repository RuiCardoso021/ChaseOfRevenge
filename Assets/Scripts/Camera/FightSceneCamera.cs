using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneCamera : MonoBehaviour
{
    public static FightSceneCamera Instance;

    [SerializeField] private GameObject InterfacePanelFight;
    private Camera mainCamera;
    private Vector3 currentPosition;
    private Vector3 finalPosition;
    public bool validation;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        mainCamera = GetComponent<Camera>();
        currentPosition = mainCamera.transform.position;
        finalPosition = new Vector3(-2.6f, 4.5f, -12f);
        validation = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (InterfacePanelFight != null && validation)
            InterfacePanelFight.SetActive(false);

        if (mainCamera != null && validation)
        {
            currentPosition = mainCamera.transform.position;
            if (currentPosition == finalPosition)
            {
                InterfacePanelFight.SetActive(true);
                validation = false;
            }
                
        }
            
    }
}
