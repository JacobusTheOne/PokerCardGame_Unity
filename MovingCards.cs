using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DeckInstantiation))]
public class MovingCards : MonoBehaviour {

    //List<GameObject> cardDeck;
    public DeckInstantiation deckInstantiation;
    //List<Vector2> vector2sFirstCardPositions;
    public float speed = 2.0f;
    //private IEnumerator coroutine;
    int cardCount = 0;
    //List<Vector2> vector2sSecondCardPostions;
    //List<Vector2> vector2sThirdCardPositions;
    //List<Vector2> vector2sFourthCardPositions;
    //List<bool> boolFirstCardPositions;
    //List<bool> boolSecondCardPositions;
    //List<bool> boolThirdCardPositions;
    //List<bool> boolFourthCardPositions;

    //private void Start()
    //{
    //    cardDeck = new List<GameObject>();
    //    cardDeck = deckInstantiation.GetCardObjects();
    //    MakeWaypoints();
    //    BoolWaypoints();
    //}

    //private void BoolWaypoints()
    //{
    //    boolFirstCardPositions = new List<bool>();
    //    boolSecondCardPositions = new List<bool>();
    //    boolThirdCardPositions = new List<bool>();
    //    boolFourthCardPositions = new List<bool>();

    //    boolFirstCardPositions.AddRange(new bool[] { true, true, true });
    //    boolSecondCardPositions.AddRange(new bool[] { true, true, true, true });
    //    boolThirdCardPositions.AddRange(new bool[] { false, true });
    //    boolFourthCardPositions.AddRange(new bool[] { false, true });

    //}
    ////Movingcards is the subscriber for deckinstantiation
    //public void OnDeckCreated(object source, Event args)
    //{
    //    cardDeck = FindObjectOfType<DeckInstantiation>().GetCardObjects();
    //}

    //Going to be used for delegate
    //public void OnDeckCreated()
    //{
    //    cardDeck = FindObjectOfType<DeckInstantiation>().GetCardObjects();
    //}

    //private void MakeWaypoints()
    //{
    //    vector2sFirstCardPositions = new List<Vector2>();
    //    vector2sSecondCardPostions = new List<Vector2>();
    //    vector2sThirdCardPositions = new List<Vector2>();
    //    vector2sFourthCardPositions = new List<Vector2>();

    //    vector2sFirstCardPositions.Add(new Vector2(-1, 0));
    //    vector2sFirstCardPositions.Add(new Vector2(-2, 0));
    //    vector2sFirstCardPositions.Add(new Vector2(-3, 0));

    //    vector2sSecondCardPostions.Add(new Vector2(0, -4));
    //    vector2sSecondCardPostions.Add(new Vector2(0, 4));
    //    vector2sSecondCardPostions.Add(new Vector2(-1, -4));
    //    vector2sSecondCardPostions.Add(new Vector2(-1, 4));

    //    vector2sThirdCardPositions.Add(new Vector2(1, 0));
    //    vector2sThirdCardPositions.Add(new Vector2(-4, 0));

    //    vector2sFourthCardPositions.Add(new Vector2(1, 0));
    //    vector2sFourthCardPositions.Add(new Vector2(-5, 0));
    //}

    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 10, 300, 28), "Move First Set Of Cards"))
    //    {
    //        //cardDeck = FindObjectOfType<DeckInstantiation>().GetCardObjects();
    //        StopCoroutine("MoveCards");
    //        StartCoroutine(MoveCards(vector2sFirstCardPositions, cardDeck, boolFirstCardPositions));
    //    }
    //    if (GUI.Button(new Rect(10, 38, 300, 28), "Move Second set of Cards"))
    //    {
    //        StopCoroutine("MoveCards");
    //        StartCoroutine(MoveCards(vector2sSecondCardPostions, cardDeck, boolSecondCardPositions));
    //    }
    //    if (GUI.Button(new Rect(10, 66, 300, 28), "Move Third set of Cards"))
    //    {
    //        StopCoroutine("MoveCards");
    //        StartCoroutine(MoveCards(vector2sThirdCardPositions, cardDeck, boolThirdCardPositions));
    //    }
    //    if (GUI.Button(new Rect(10, 94, 300, 28), "Move Fourth set of Cards"))
    //    {
    //        StopCoroutine("MoveCards");
    //        StartCoroutine(MoveCards(vector2sFourthCardPositions, cardDeck, boolFourthCardPositions));
    //    }
    //}
    //Move a list of cards to a list of positions the list count of both needs to be the same
    
}
