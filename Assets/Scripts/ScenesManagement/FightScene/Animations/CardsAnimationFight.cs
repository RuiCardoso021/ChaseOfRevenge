using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CardsAnimationFight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button buttonAction;
    private Card_Prefab _cardPrefab;

    void Start()
    {
        _cardPrefab = gameObject.GetComponent<Card_Prefab>();
        buttonAction = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonAction = gameObject.GetComponent<Button>();

        
    }

    

    private void OnMouseOver()
    {
        RectTransform rect = this.gameObject.GetComponent<RectTransform>();
        rect.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    private void OnMouseExit()
    {
        RectTransform rect = this.gameObject.GetComponent<RectTransform>();
        rect.transform.localScale = new Vector3(1f, 1f, 1f);    
    }

    private void OnMouseDown()
    {
        if (GameObject.Find(Global.gameplayObject).GetComponent<GamePlayFightScene>()._cardsToPlay.CardChoose != null)
        {
            GameObject.Find(Global.gameplayObject).GetComponent<GamePlayFightScene>()._cardsToPlay.CardChoose = _cardPrefab.dataCard;
        }
    }
}
