using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CardsOnHandAnimation : MonoBehaviour
{


    void Start()
    {
        
    }

    private void Update()
    {
        if (ManagerGameFight.Instance.PermissedExecute)
            AnimationCard();
    }

    //Apply event mouse over on cards
    private void AnimationCard()
    {
        GameObject ContentCardsGame = this.GameObject();


        if (ContentCardsGame != null)
        {
            for (int i = 0; i < ContentCardsGame.transform.childCount; i++)
            {
                GameObject child = ContentCardsGame.transform.GetChild(i).gameObject;

                //if (Time.time < 120)
                //{
                //    Debug.Log(Time.time);
                //}
                FirstAnimation(child);
                MouseHoverAnimation(child);
            }
        }     
    }

    private void FirstAnimation(GameObject child)
    {
        CardsAnimationFight cardAnimation = child.GetComponent<CardsAnimationFight>();
        float time = 0;

        if (cardAnimation != null)
        {
            Canvas canvas = child.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.pixelPerfect = true;
                if (cardAnimation.isNewItem)
                {
                    RectTransform rect = child.gameObject.GetComponent<RectTransform>();
                    rect.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    rect.pivot = new Vector2(0f, 0f);
                    canvas.overrideSorting = true;
                    canvas.sortingOrder = 1;
                    cardAnimation.isNewItem = false;
                }
            }
        }
    }

    private void MouseHoverAnimation(GameObject child)
    {
        CardsAnimationFight cardAnimation = child.GetComponent<CardsAnimationFight>();

        if (cardAnimation != null)
        {
            Canvas canvas = child.GetComponent<Canvas>();
            //canvas.pixelPerfect = true;

            //set transformation card if houver
            if (canvas != null)
            {
                if (!cardAnimation.isNewItem)
                {
                    if (cardAnimation.mouse_over)
                    {
                        RectTransform rect = child.gameObject.GetComponent<RectTransform>();
                        //rect.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        rect.pivot = new Vector2(0.5f, 0.22f);
                        canvas.overrideSorting = true;
                        canvas.sortingOrder = 1;
                    }
                    else if (!cardAnimation.mouse_over)
                    {
                        RectTransform rect = child.gameObject.GetComponent<RectTransform>();
                        rect.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                        rect.pivot = new Vector2(0.5f, 0.5f);
                        canvas.overrideSorting = false;
                        canvas.sortingOrder = 0;
                    }
                }
                
            }
        }
    }
}