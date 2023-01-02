using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerChest : MonoBehaviour
{
    // Start is called before the first frame update
    public Deck cardsInteractionDeck;
    [SerializeField] private TextAsset jsonFile;


    void Start()
    {
        cardsInteractionDeck = JsonUtility.FromJson<Deck>(jsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
