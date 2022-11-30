using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public bool Haskey = false;

    public GameObject inventoryScreen;
    //public AudioSource inventoryOpen;
    //public AudioSource inventoryClose;
    public bool isOpen = false;
    public bool canClose = false;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P)) Haskey = !Haskey;

        if (Input.GetKeyDown(KeyCode.I) && isOpen == false && canClose == false)
        {
            isOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //inventoryOpen.Play();
            StartCoroutine(InvControl());
        }
        if (Input.GetKeyDown(KeyCode.I) && isOpen == true && canClose == true)
        {
            isOpen = false;   
            //inventoryClose.Play();
            StartCoroutine(InvControl());
        }
    }

    IEnumerator InvControl()
    {
        yield return new WaitForSeconds(.25f);
        if (isOpen == true)
        {
            inventoryScreen.SetActive(true);
        }
        else
        {
            inventoryScreen.SetActive(false);
        }

        if (isOpen == true)
        {
            canClose = true;
        }
        else
        {
            canClose = false;
        }
    }

    public void buttonDeck()
    {
        if (isOpen == false && canClose == false)
        {
            isOpen = true;
            //inventoryOpen.Play();
            StartCoroutine(InvControl());
        }
        if (isOpen == true && canClose == true)
        {
            isOpen = false;
            //inventoryClose.Play();
            StartCoroutine(InvControl());
        }
    }


}
