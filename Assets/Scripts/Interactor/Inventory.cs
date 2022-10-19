using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool Haskey = false;
    public GameObject inventoryScreen;
    public AudioSource inventoryOpen;
    public AudioSource inventoryClose;
    public bool isOpen = false;
    public bool canClose = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Haskey = !Haskey;

        if (Input.GetKey(KeyCode.I) && isOpen == false && canClose == false)
        {
            isOpen = true;
            inventoryOpen.Play();
            StartCoroutine(InventoryControl());
        }
        if (Input.GetKey(KeyCode.I) && isOpen == true && canClose == true)
        {
            isOpen = false;
            inventoryClose.Play();
            StartCoroutine(InventoryControl());
        }
    }

    public void ExitButton()
    {
        isOpen = false;
        inventoryClose.Play();
        StartCoroutine(InventoryControl());
    }

    IEnumerator InventoryControl()
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
}
