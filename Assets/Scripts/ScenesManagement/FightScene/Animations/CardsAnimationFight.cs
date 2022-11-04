using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsAnimationFight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera _mainCam;
    private Quaternion rotation;
    private CardManager cardManager;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<GamePlayFightScene>()._cardsToPlay.CardsOnHand != null)
        {
            Quaternion rotation = _mainCam.transform.rotation;
            GetComponent<GamePlayFightScene>()._cardsToPlay.rotationCardsFromCamera(rotation);
        }
  
    }
}
