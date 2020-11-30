using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Move the cards on the screen; Distribute the list of int values between players per turn; Maximum of 6 players; End of game determine the winners
//Determine who has the small blind and who has the big blind at the start and each consecutive turn
//Create a GUI to control the flow cards
public class GameController : MonoBehaviour
{
    Winner winner;
    DeckInstantiation deckInstantiation;
    //MovingCards movingCards;

    public bool[] seats = {true,true,true,true,true,true};
    List<int> cardDeckInt;
    #region CommonDeckInt
    private List<int> commonDeck;
    #endregion
    #region PlayerDeckInt
    private List<int> seat1Player;
    private List<int> seat2Player;
    private List<int> seat3Player;
    private List<int> seat4Player;
    private List<int> seat5Player;
    private List<int> seat6Player;
    #endregion
    #region Moving Card Variables
    List<Vector2> playerPositions;
    List<Vector2> firstCommonCardPositions;
    List<Vector2> secondCommonCardPostions;
    List<Vector2> thirdCommonCardPostions;
    List<bool> listShowPlayerCards;
    List<bool> listShowFirstCommonCardPositions;
    List<bool> listShowSecondCommonCardPositions;
    List<bool> listShowThirdCommonCardPositions;
    List<GameObject> cardDeck;
    public float speed;
    int cardCount = 0;
    #endregion
    private void Awake()
    {
        winner = FindObjectOfType<Winner>();
    }

    private void Start()
    {

        InitialVariableSetup();
        commonDeck = new List<int>();
        //deckInstantiation = FindObjectOfType<DeckInstantiation>();
        //DeckInstantiation.onComplete += AssignIntToPlayers;
        //DeckInstantiation.onComplete += OnDeckCreated;
         

    }
    public void GetDeckInt()
    {
        cardDeckInt = new List<int>();
        cardDeckInt = FindObjectOfType<Deck>().GetCardsInt();
    }
    public void AssignIntToPlayers()
    {
        seat1Player = new List<int>();
        seat2Player = new List<int>();
        seat3Player = new List<int>();
        seat4Player = new List<int>();
        seat5Player = new List<int>();
        seat6Player = new List<int>();
        int i = 0;
        int k = 0;
        int max = 0;
        foreach (bool s in seats)
        {
            if (s == true)
                max += 1;
        }
        //Seat 1
        if (seats[0] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat1Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 2
        if (seats[1] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat2Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 3
        if (seats[2] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat3Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 4
        if (seats[3] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat4Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 5
        if (seats[4] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat5Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 6
        if (seats[5] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat6Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 1
        if (seats[0] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat1Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 2
        if (seats[1] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat2Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 3
        if (seats[2] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat3Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 4
        if (seats[3] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat4Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 5
        if (seats[4] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat5Player.Add(temp);
            i += 1;
            k += 1;
        }
        //Seat 6
        if (seats[5] == true)
        {
            if (i == max)
                i = 0;
            if (k == 2)
                k = 0;
            int temp = cardDeckInt[0];
            cardDeckInt.RemoveAt(0);
            seat6Player.Add(temp);
            i += 1;

            k += 1;
        }
    }
    private void AssignIntToFirstCommonDeck()
    {  
        commonDeck.Add(Pop());
        commonDeck.Add(Pop());
        commonDeck.Add(Pop());
    }
    private void AssignIntToSecondCommonDeck()
    {
        Pop();
        commonDeck.Add(Pop());
    }
    private void AssignIntToThirdCommonDeck()
    {
        Pop();
        commonDeck.Add(Pop());
    }
    private int Pop()
    {
        int temp = cardDeckInt[0];
        cardDeckInt.RemoveAt(0);
        return temp;
    }

    private void OnGUI()
    {

        if (GUI.Button(new Rect(10, 10, 300, 28), "Move First Set Of Cards"))
        {
            StartCoroutine(MoveCards(playerPositions, cardDeck, listShowPlayerCards));
            AssignIntToPlayers();
        }
        if (GUI.Button(new Rect(10, 38, 300, 28), "Move Second set of Cards"))
        {
            //StopCoroutine("MoveCards");
            StartCoroutine(MoveCards(firstCommonCardPositions, cardDeck, listShowFirstCommonCardPositions));
            AssignIntToFirstCommonDeck();
            

        }
        if (GUI.Button(new Rect(10, 66, 300, 28), "Move Third set of Cards"))
        {
            //StopCoroutine("MoveCards");
            StartCoroutine(MoveCards(secondCommonCardPostions, cardDeck, listShowSecondCommonCardPositions));
            AssignIntToSecondCommonDeck();
            
        }
        if (GUI.Button(new Rect(10, 94, 300, 28), "Move Fourth set of Cards"))
        {
            //StopCoroutine("MoveCards");
            StartCoroutine(MoveCards(thirdCommonCardPostions, cardDeck, listShowThirdCommonCardPositions));
            AssignIntToThirdCommonDeck();
            //List<int> tempList1 = new List<int>() { 8, 9 };
            //List<int> tempList2 = new List<int>() { 10, 11, 12, 8, 15 };
            winner.CheckWinners(seat1Player, seat2Player, seat3Player, seat4Player, seat5Player, seat6Player, commonDeck);
            //winner.FourOfAKind(seat2Player, commonDeck);
            //winner.FourOfAKind(seat3Player, commonDeck);
            //winner.FourOfAKind(seat4Player, commonDeck);
            //winner.FourOfAKind(seat5Player, commonDeck);
            //winner.FourOfAKind(seat6Player, commonDeck);
        }

    }
    public IEnumerator MoveCards(List<Vector2> positions, List<GameObject> gameObject, List<bool> show)
    {
        int i = 0;
        while (i < positions.Count)
        {
            gameObject[cardCount].GetComponent<Transform>().position = Vector2.MoveTowards(gameObject[cardCount].GetComponent<Transform>().position, positions[i], speed * Time.deltaTime);
            if (Vector2.Distance(gameObject[cardCount].GetComponent<Transform>().position, positions[i]) == 0f)
            {
                gameObject[cardCount].GetComponent<CardModel>().ToggleFace(show[i]);
                i += 1;
                cardCount += 1;
            }
            yield return new WaitForFixedUpdate();
        }

    }
    public void OnDeckCreated()
    {
        cardDeck = FindObjectOfType<DeckInstantiation>().GetCardObjects();
        //allCards = FindObjectOfType<Deck>().GetCardInt();
    }

    #region Initial setup of the variables
    private void InitialVariableSetup()
    {
        PlayerPositions();
        FirstCommonCardPositions();
        SecondCommonCardPositions();
        ThirdCommonCardPositions();

        ShowPlayerCards();
        ShowFirstCommonPositions();
        ShowSecondCommonPositions();
        ShowThirdCommonPositions();
    }

    
    
    private void ShowThirdCommonPositions()
    {
        listShowThirdCommonCardPositions = new List<bool>();
        listShowThirdCommonCardPositions.AddRange(new bool[] { false, true });
    }

    private void ShowSecondCommonPositions()
    {
        listShowSecondCommonCardPositions = new List<bool>();
        listShowSecondCommonCardPositions.AddRange(new bool[] { false, true });
    }

    private void ShowFirstCommonPositions()
    {
        listShowFirstCommonCardPositions = new List<bool>();
        listShowFirstCommonCardPositions.AddRange(new bool[] { true, true, true });
    }

    private void ShowPlayerCards()
    {
        listShowPlayerCards = new List<bool>();
        listShowPlayerCards.AddRange(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true });
    }

    private void ThirdCommonCardPositions()
    {
        thirdCommonCardPostions = new List<Vector2>();
        thirdCommonCardPostions.Add(new Vector2(1, 0));
        thirdCommonCardPostions.Add(new Vector2(-5, 0));
    }

    private void SecondCommonCardPositions()
    {
        secondCommonCardPostions = new List<Vector2>();
        secondCommonCardPostions.Add(new Vector2(1, 0));
        secondCommonCardPostions.Add(new Vector2(-4, 0));
    }

    private void FirstCommonCardPositions()
    {
        firstCommonCardPositions = new List<Vector2>();
        firstCommonCardPositions.Add(new Vector2(-1, 0));
        firstCommonCardPositions.Add(new Vector2(-2, 0));
        firstCommonCardPositions.Add(new Vector2(-3, 0));
    }
    #endregion
    public void PlayerPositions()
    {
        
        
        playerPositions = new List<Vector2>();
        //Seat 1
        if (seats[0] == true)
        {
            playerPositions.Add(new Vector2(3, -3));
        }
        //listIntAllPlayerCards[0][0] = Pop();
        //Seat 2
        if (seats[1] == true)
        { 
            playerPositions.Add(new Vector2(0.5f, -3));          
        }
        //Seat 3
        if (seats[2] == true)
        {
            
            playerPositions.Add(new Vector2(-3, -3));

        }
        //Seat 4
        if (seats[3] == true)
        {
            playerPositions.Add(new Vector2(-3, 3));
        }
        //Seat 5
        if (seats[4] == true)
        {

            playerPositions.Add(new Vector2(0, 3));

        }
        //Seat 6
        if (seats[5] == true)
        {

            playerPositions.Add(new Vector2(3, 3));

        }
        //Seat 1
        if (seats[0] == true)
        {

            playerPositions.Add(new Vector2(4, -3));

        }
        //listIntAllPlayerCards[0][1] = Pop();
        //Seat 2
        if (seats[1] == true)
        {

            playerPositions.Add(new Vector2(-0.5f, -3));

        }
        //Seat 3
        if (seats[2] == true)
        {

            playerPositions.Add(new Vector2(-4, -3));

        }
        //Seat 4 
        if (seats[3] == true)
        {

            playerPositions.Add(new Vector2(-4, 3));

        }
        //Seat 5
        if (seats[4] == true)
        {

            playerPositions.Add(new Vector2(-1, 3));

        }
        //Seat 6
        if (seats[5] == true)
        {

            playerPositions.Add(new Vector2(4, 3));

        }

    }
    
}
