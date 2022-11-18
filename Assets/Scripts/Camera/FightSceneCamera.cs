using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Focus;
    private Vector3 InicialPosition;
    private Vector3 PositionFixed;

    public float transitionDuration = 2.5f;
    public Transform target;



    // Start is called before the first frame update
    void Start()
    {
        PositionFixed = mainCamera.transform.position;
        InicialPosition = mainCamera.transform.position + new Vector3(10, 10, 10);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
