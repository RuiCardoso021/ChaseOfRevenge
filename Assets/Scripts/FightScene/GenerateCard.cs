using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenerateCard : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public GameObject gmCard;
    public GameObject Card;
    public List<GameObject> cards = new List<GameObject>();
    private float numberCards = 4;
    private ReadJson dataCard;
    private Deck deck;
    public TextAsset jsonFile;
    private bool myTurn;
    
    void Start()
    {    
            //generate card list
            List<int> cardsToGive = new List<int>();
            int random;
            float x = -1.4f;
            myTurn = true;

            deck = new Deck();
            deck = JsonUtility.FromJson<Deck>(jsonFile.text);

            for (int i=0; i<numberCards; i++)
            {
                //indice random
                do
                {
                    random = Random.Range(0, deck.cards.Length);
                } while (cardsToGive.Contains(random));
                cardsToGive.Add(random);
                
                //generate card
                Card.GetComponent<ReadJson>().setDataCard(deck.cards[random].mana.ToString(), deck.cards[random].description, deck.cards[random].name, deck.cards[random].src);
                cards.Add(Instantiate(Card, new Vector3(x,1,-7), Quaternion.identity, gmCard.transform));
                
                x+= 0.6f;
            }
    }

        // Update is called once per frame
        void Update()
        {
            //player to play
            if (myTurn){
                Debug.Log(myTurn);
            }else{
                
            }
        }

        public void nextTurn(){
            myTurn = false;
        }
}
