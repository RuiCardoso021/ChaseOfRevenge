using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    float velocity = 10.0f;
    public float rotation = 90.0f;
    public float rotspeed = 10.0f;
    public float gravity = 9.14f;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(x, 0, y) * velocity;

        transform.Translate(dir * Time.deltaTime);
        transform.Rotate(new Vector3( 0, mouseX * rotation * Time.deltaTime, 0));
    }
}
