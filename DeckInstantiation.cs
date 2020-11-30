using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Deck))]
public class DeckInstantiation : MonoBehaviour 
{
    #region Singleton
    private static DeckInstantiation _instance;
    public static DeckInstantiation Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("DeckInstantiation");
                go.AddComponent<DeckInstantiation>();
            }
            return _instance;
        }

    }
    #endregion

    //define a delegate
    public delegate void OnDeckCreated();
    public static event OnDeckCreated onComplete;

    public Vector3 start;
    public float cardOffset;
    public GameObject cardPrefab;
    public List<GameObject> cardDeck;
    Deck deck;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        cardDeck = new List<GameObject>();
        
        deck = GetComponent<Deck>();
        //Used for delegate
        onComplete += ShowCards;
        onComplete += FindObjectOfType<GameController>().OnDeckCreated;
        //onComplete += FindObjectOfType<GameController>().AssignIntToPlayers;
        
        onComplete();
        //MovingCards movingCards = FindObjectOfType<MovingCards>();

        
        //DeckInstantiation deckInstantiation = GetComponent<DeckInstantiation>();
        ////Need to subscribe the subscriber
        //deckInstantiation.DeckCreated += movingCards.OnDeckCreated;
    }
    public List<GameObject> GetCardObjects()
    {
        return cardDeck;

    }

    ////Define a delegate
    //public delegate void DeckCreatedEventHandler(object source, Event args);
    ////Define an event based on that delegate
    //public event DeckCreatedEventHandler DeckCreated;
    ////Notify all the subscribers
    //protected virtual void OnDeckCreated()
    //{
    //    if(DeckCreated!=null)
    //    {
    //        DeckCreated(this,Event.current);
    //    }
    //}
    void ShowCards()
    {
        int cardCount = 0;

        foreach(int i in deck.GetCards())
        {
            float co = cardOffset * cardCount;

            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
            cardDeck.Add(cardCopy);
            Vector3 temp = start + new Vector3(co, 0f);
            cardCopy.transform.position = temp;

            CardModel cardModel = cardCopy.GetComponent<CardModel>();
            cardModel.cardIndex = i;
            //cardModel.ToggleFace(false);

            cardCount++;
        }
        ////Raise the event
        //OnDeckCreated();

    }
    


}
