using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //if (Input.GetKeyDown(KeyCode.P)) Haskey = !Haskey;
        openOrCloseInventoryWithKeyI();

    }

    private void openOrCloseInventoryWithKeyI()
    {
        if (SceneManager.GetActiveScene().name != "CharacterSelection" || SceneManager.GetActiveScene().name != "FightScene")
        {
            if (Input.GetKeyDown(KeyCode.I) && !isOpen && !canClose)
            {
                isOpen = true;

                //inventoryOpen.Play();
                StartCoroutine(InvControl());
            }
            if (Input.GetKeyDown(KeyCode.I) && isOpen && canClose)
            {
                isOpen = false;
                //inventoryClose.Play();
                StartCoroutine(InvControl());
            }
        }
        
    }

    IEnumerator InvControl()
    {
        yield return new WaitForSeconds(.25f);
        if (isOpen == true)
        {
            inventoryScreen.SetActive(true);
            canClose = true;
        }
        else
        {
            inventoryScreen.SetActive(false);
            canClose = false;
        }
    }

    public void buttonDeck()
    {
        if (!isOpen && !canClose)
        {
            isOpen = true;
            //inventoryOpen.Play();
            StartCoroutine(InvControl());
        }
            
        if (isOpen && canClose)
        {
            isOpen = false;
            //inventoryClose.Play();
            StartCoroutine(InvControl());
        }
        
        
    }


}
