using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class CardsAnimationFight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    public bool mouse_over;
    public bool mouse_click;
    public bool isNewItem;

    void Start()
    {
        isNewItem = true;
        mouse_over = false;
        mouse_click = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Time.timeScale != 0)
            mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Time.timeScale != 0)
            mouse_over = false;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.timeScale != 0)
            mouse_click = true;
    }
}
