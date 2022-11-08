using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CardsAnimationFight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private Button buttonAction;
    private Card _thisCard;
    public bool mouse_over;

    void Start()
    {
        mouse_over = false;
        //_cardPrefab = gameObject.GetComponent<Card_Prefab>();
        //buttonAction = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

        //buttonAction = gameObject.GetComponent<Button>();
       
    }

    public void Inicialization(Card Card)
    {
        _thisCard = Card;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameObject.Find(Global.gameplayObject).GetComponent<GamePlayFightScene>()._cardsToPlay.CardChoose != null)
        {
            GameObject.Find(Global.gameplayObject).GetComponent<GamePlayFightScene>()._cardsToPlay.CardChoose = _thisCard;
        }
    }
}
