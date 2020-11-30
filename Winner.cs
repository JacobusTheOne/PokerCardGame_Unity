using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public string Suit { get; set; }
    public int Cardvalue { get; set; }
    public int Cardindex { get; set; }
}

public class HandValue
{
    public bool isA = false;
    public int value1 = 0;
    public int value2 = 0;
    public int value3 = 0;
    public int value4 = 0;
    public int value5 = 0;
    public bool Contains()
    {
        return isA;
    }
    public int Value1()
    {
        return value1;
    }
    public int Value2()
    {
        return value2;
    }
    public int Value3()
    {
        return value3;
    }
    public int Value4()
    {
        return value4;
    }
    public int Value5()
    {
        return value5;
    }
}

public class Winner : MonoBehaviour
{
    //Player 
    public List<Card> Playerdeck;
    public List<Card> Boarddeck;
    Card Cardtemp;
    public bool player1 = false;
    public bool player2 = false;
    public bool player3 = false;
    public bool player4 = false;
    public bool player5 = false;
    public bool player6 = false;
    private void Awake()
    {
        Playerdeck = new List<Card>();
        Boarddeck = new List<Card>();
        Cardtemp = new Card();
    }

    //public void CovertToCards(List<int> playerDeck, List<int> commonDeck)
    //{
    //    int temp = 0;
    //    for (int i = 0; i < playerDeck.Count; i++)
    //    {
    //        temp = playerDeck[i];
    //        temp %= 13;
    //        temp += 2;
    //        Card someCard = new Card();
    //        if (playerDeck[i] >= 0 && playerDeck[i] <= 12)
    //        {
    //            someCard.Cardindex = playerDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "heart";
    //            Playerdeck.Add(someCard);
    //        }
    //        else if (playerDeck[i] >= 13 && playerDeck[i] <= 25)
    //        {
    //            someCard.Cardindex = playerDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "diamond";
    //            Playerdeck.Add(someCard);
    //        }
    //        else if (playerDeck[i] >= 26 && playerDeck[i] <= 38)
    //        {
    //            someCard.Cardindex = playerDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "club";
    //            Playerdeck.Add(someCard);
    //        }
    //        else
    //        {
    //            someCard.Cardindex = playerDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "spade";
    //            Playerdeck.Add(someCard);
    //        }
    //    }
    //    for (int i = 0; i < commonDeck.Count; i++)
    //    {
    //        temp = commonDeck[i];
    //        temp %= 13;
    //        temp += 2;
    //        Card someCard = new Card();
    //        if (commonDeck[i] >= 0 && commonDeck[i] <= 12)
    //        {
    //            someCard.Cardindex = commonDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "heart";
    //            Boarddeck.Add(someCard);
    //        }
    //        else if (commonDeck[i] >= 13 && commonDeck[i] <= 25)
    //        {
    //            someCard.Cardindex = commonDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "diamond";
    //            Boarddeck.Add(someCard);
    //        }
    //        else if (commonDeck[i] >= 26 && commonDeck[i] <= 38)
    //        {
    //            someCard.Cardindex = commonDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "club";
    //            Boarddeck.Add(someCard);
    //        }
    //        else
    //        {
    //            someCard.Cardindex = commonDeck[i];
    //            someCard.Cardvalue = temp;
    //            someCard.Suit = "spade";
    //            Boarddeck.Add(someCard);
    //        }
    //    }
    //    Debug.Log("Player deck");
    //    foreach(Card card in Playerdeck)
    //    {
    //        Debug.Log("Card index:" + card.Cardindex);
    //        Debug.Log("Card value:" + card.Cardvalue);
    //        Debug.Log("Card suit:" + card.Suit);
    //    }
    //    Debug.Log("Board deck");
    //    foreach (Card card in Boarddeck)
    //    {
    //        Debug.Log("Card index:" + card.Cardindex);
    //        Debug.Log("Card value:" + card.Cardvalue);
    //        Debug.Log("Card suit:" + card.Suit);
    //    }
    //}

    #region Check for winner
    public void CheckWinners(List<int> PlayerDeck1, List<int> PlayerDeck2, List<int> PlayerDeck3, List<int> PlayerDeck4, List<int> PlayerDeck5, List<int> PlayerDeck6, List<int> CommonDeck)
    {
        List<HandValue> playerdeck1 = new List<HandValue>();
        List<HandValue> playerdeck2 = new List<HandValue>();
        List<HandValue> playerdeck3 = new List<HandValue>();
        List<HandValue> playerdeck4 = new List<HandValue>();
        List<HandValue> playerdeck5 = new List<HandValue>();
        List<HandValue> playerdeck6 = new List<HandValue>();

        #region Add Values To Player Decks
        playerdeck1.Add(RoyalFlush(PlayerDeck1, CommonDeck));
        playerdeck2.Add(RoyalFlush(PlayerDeck2, CommonDeck));
        playerdeck3.Add(RoyalFlush(PlayerDeck3, CommonDeck));
        playerdeck4.Add(RoyalFlush(PlayerDeck4, CommonDeck));
        playerdeck5.Add(RoyalFlush(PlayerDeck5, CommonDeck));
        playerdeck6.Add(RoyalFlush(PlayerDeck6, CommonDeck));

        playerdeck1.Add(StraightFlush(PlayerDeck1, CommonDeck));
        playerdeck2.Add(StraightFlush(PlayerDeck2, CommonDeck));
        playerdeck3.Add(StraightFlush(PlayerDeck3, CommonDeck));
        playerdeck4.Add(StraightFlush(PlayerDeck4, CommonDeck));
        playerdeck5.Add(StraightFlush(PlayerDeck5, CommonDeck));
        playerdeck6.Add(StraightFlush(PlayerDeck6, CommonDeck));

        playerdeck1.Add(FourOfAKind(PlayerDeck1, CommonDeck));
        playerdeck2.Add(FourOfAKind(PlayerDeck2, CommonDeck));
        playerdeck3.Add(FourOfAKind(PlayerDeck3, CommonDeck));
        playerdeck4.Add(FourOfAKind(PlayerDeck4, CommonDeck));
        playerdeck5.Add(FourOfAKind(PlayerDeck5, CommonDeck));
        playerdeck6.Add(FourOfAKind(PlayerDeck6, CommonDeck));

        playerdeck1.Add(FullHouse(PlayerDeck1, CommonDeck));
        playerdeck2.Add(FullHouse(PlayerDeck2, CommonDeck));
        playerdeck3.Add(FullHouse(PlayerDeck3, CommonDeck));
        playerdeck4.Add(FullHouse(PlayerDeck4, CommonDeck));
        playerdeck5.Add(FullHouse(PlayerDeck5, CommonDeck));
        playerdeck6.Add(FullHouse(PlayerDeck6, CommonDeck));

        playerdeck1.Add(Flush(PlayerDeck1, CommonDeck));
        playerdeck2.Add(Flush(PlayerDeck2, CommonDeck));
        playerdeck3.Add(Flush(PlayerDeck3, CommonDeck));
        playerdeck4.Add(Flush(PlayerDeck4, CommonDeck));
        playerdeck5.Add(Flush(PlayerDeck5, CommonDeck));
        playerdeck6.Add(Flush(PlayerDeck6, CommonDeck));

        playerdeck1.Add(Straight(PlayerDeck1, CommonDeck));
        playerdeck2.Add(Straight(PlayerDeck2, CommonDeck));
        playerdeck3.Add(Straight(PlayerDeck3, CommonDeck));
        playerdeck4.Add(Straight(PlayerDeck4, CommonDeck));
        playerdeck5.Add(Straight(PlayerDeck5, CommonDeck));
        playerdeck6.Add(Straight(PlayerDeck6, CommonDeck));

        playerdeck1.Add(Triple(PlayerDeck1, CommonDeck));
        playerdeck2.Add(Triple(PlayerDeck2, CommonDeck));
        playerdeck3.Add(Triple(PlayerDeck3, CommonDeck));
        playerdeck4.Add(Triple(PlayerDeck4, CommonDeck));
        playerdeck5.Add(Triple(PlayerDeck5, CommonDeck));
        playerdeck6.Add(Triple(PlayerDeck6, CommonDeck));

        playerdeck1.Add(TwoPair(PlayerDeck1, CommonDeck));
        playerdeck2.Add(TwoPair(PlayerDeck2, CommonDeck));
        playerdeck3.Add(TwoPair(PlayerDeck3, CommonDeck));
        playerdeck4.Add(TwoPair(PlayerDeck4, CommonDeck));
        playerdeck5.Add(TwoPair(PlayerDeck5, CommonDeck));
        playerdeck6.Add(TwoPair(PlayerDeck6, CommonDeck));

        playerdeck1.Add(Double(PlayerDeck1, CommonDeck));
        playerdeck2.Add(Double(PlayerDeck2, CommonDeck));
        playerdeck3.Add(Double(PlayerDeck3, CommonDeck));
        playerdeck4.Add(Double(PlayerDeck4, CommonDeck));
        playerdeck5.Add(Double(PlayerDeck5, CommonDeck));
        playerdeck6.Add(Double(PlayerDeck6, CommonDeck));

        playerdeck1.Add(HighCard(PlayerDeck1, CommonDeck));
        playerdeck2.Add(HighCard(PlayerDeck2, CommonDeck));
        playerdeck3.Add(HighCard(PlayerDeck3, CommonDeck));
        playerdeck4.Add(HighCard(PlayerDeck4, CommonDeck));
        playerdeck5.Add(HighCard(PlayerDeck5, CommonDeck));
        playerdeck6.Add(HighCard(PlayerDeck6, CommonDeck));
        #endregion

        if (playerdeck1[0].Contains() || playerdeck2[0].Contains() || playerdeck3[0].Contains()
            || playerdeck4[0].Contains() || playerdeck5[0].Contains() || playerdeck6[0].Contains())
        {
            Debug.Log("One of the decks is a Royal Flush.");
            WinningHands(playerdeck1[0], playerdeck2[0], playerdeck3[0], playerdeck4[0], playerdeck5[0], playerdeck6[0], 1);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[1].Contains() || playerdeck2[1].Contains() || playerdeck3[1].Contains()
            || playerdeck4[1].Contains() || playerdeck5[1].Contains() || playerdeck6[1].Contains())
        {
            Debug.Log("One of the decks is a Straight Flush.");
            WinningHands(playerdeck1[1], playerdeck2[1], playerdeck3[1], playerdeck4[1], playerdeck5[1], playerdeck6[1], 1);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[2].Contains() || playerdeck2[2].Contains() || playerdeck3[2].Contains()
            || playerdeck4[2].Contains() || playerdeck5[2].Contains() || playerdeck6[2].Contains())
        {
            Debug.Log("One of the decks is a Four of a Kind.");
            WinningHands(playerdeck1[2], playerdeck2[2], playerdeck3[2], playerdeck4[2], playerdeck5[2], playerdeck6[2], 2);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[3].Contains() || playerdeck2[3].Contains() || playerdeck3[3].Contains()
            || playerdeck4[3].Contains() || playerdeck5[3].Contains() || playerdeck6[3].Contains())
        {
            Debug.Log("One of the decks is a Fullhouse.");
            WinningHands(playerdeck1[3], playerdeck2[3], playerdeck3[3], playerdeck4[3], playerdeck5[3], playerdeck6[3], 3);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[4].Contains() || playerdeck2[4].Contains() || playerdeck3[4].Contains()
            || playerdeck4[4].Contains() || playerdeck5[4].Contains() || playerdeck6[4].Contains())
        {
            Debug.Log("One of the decks is a Flush.");
            WinningHands(playerdeck1[4], playerdeck2[4], playerdeck3[4], playerdeck4[4], playerdeck5[4], playerdeck6[4], 5);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[5].Contains() || playerdeck2[5].Contains() || playerdeck3[5].Contains()
            || playerdeck4[5].Contains() || playerdeck5[5].Contains() || playerdeck6[5].Contains())
        {
            Debug.Log("One of the decks is a Straight.");
            WinningHands(playerdeck1[5], playerdeck2[5], playerdeck3[5], playerdeck4[5], playerdeck5[5], playerdeck6[5], 1);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");

        }
        else if (playerdeck1[6].Contains() || playerdeck2[6].Contains() || playerdeck3[6].Contains()
            || playerdeck4[6].Contains() || playerdeck5[6].Contains() || playerdeck6[6].Contains())
        {
            Debug.Log("One of the decks is a Triple.");
            WinningHands(playerdeck1[6], playerdeck2[6], playerdeck3[6], playerdeck4[6], playerdeck5[6], playerdeck6[6], 3);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[7].Contains() || playerdeck2[7].Contains() || playerdeck3[7].Contains()
            || playerdeck4[7].Contains() || playerdeck5[7].Contains() || playerdeck6[7].Contains())
        {
            Debug.Log("One of the decks is a Two Pair.");
            WinningHands(playerdeck1[7], playerdeck2[7], playerdeck3[7], playerdeck4[7], playerdeck5[7], playerdeck6[7], 3);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[8].Contains() || playerdeck2[8].Contains() || playerdeck3[8].Contains()
            || playerdeck4[8].Contains() || playerdeck5[8].Contains() || playerdeck6[8].Contains())
        {
            Debug.Log("One of the decks is a Double.");
            WinningHands(playerdeck1[8], playerdeck2[8], playerdeck3[8], playerdeck4[8], playerdeck5[8], playerdeck6[8], 4);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
        else if (playerdeck1[9].Contains() || playerdeck2[9].Contains() || playerdeck3[9].Contains()
            || playerdeck4[9].Contains() || playerdeck5[9].Contains() || playerdeck6[9].Contains())
        {
            Debug.Log("One of the decks has a Highcard.");
            WinningHands(playerdeck1[9], playerdeck2[9], playerdeck3[9], playerdeck4[9], playerdeck5[9], playerdeck6[9], 5);
            if (player1)
                Debug.Log("Player 1 wins");
            if (player2)
                Debug.Log("Player 2 wins");
            if (player3)
                Debug.Log("Player 3 wins");
            if (player4)
                Debug.Log("Player 4 wins");
            if (player5)
                Debug.Log("Player 5 wins");
            if (player6)
                Debug.Log("Player 6 wins");
        }
    }
    #endregion
    public void WinningHands(HandValue some_hand1, HandValue some_hand2, HandValue some_hand3, HandValue some_hand4, HandValue some_hand5, HandValue some_hand6, int checkDepth)
    {
        HandValue hand1 = new HandValue(); hand1 = some_hand1;
        HandValue hand2 = new HandValue(); hand2 = some_hand2;
        HandValue hand3 = new HandValue(); hand3 = some_hand3;
        HandValue hand4 = new HandValue(); hand4 = some_hand4;
        HandValue hand5 = new HandValue(); hand5 = some_hand5;
        HandValue hand6 = new HandValue(); hand6 = some_hand6;
        bool seat1_phase1 = false; bool seat2_phase1 = false;bool seat3_phase1 = false;bool seat4_phase1 = false;bool seat5_phase1 = false;bool seat6_phase1 = false;
        bool seat1_phase2 = false; bool seat2_phase2 = false;bool seat3_phase2 = false;bool seat4_phase2 = false;bool seat5_phase2 = false; bool seat6_phase2 = false;
        bool seat1_phase3 = false; bool seat2_phase3 = false; bool seat3_phase3 = false; bool seat4_phase3 = false; bool seat5_phase3 = false; bool seat6_phase3 = false;
        bool seat1_phase4 = false; bool seat2_phase4 = false; bool seat3_phase4 = false; bool seat4_phase4 = false; bool seat5_phase4 = false; bool seat6_phase4 = false;
        bool seat1_phase5 = false; bool seat2_phase5 = false; bool seat3_phase5 = false; bool seat4_phase5 = false; bool seat5_phase5 = false; bool seat6_phase5 = false;
        int cnt = 0;
        
        bool found = false;
        List<bool> PhaseValues = new List<bool>();
        do
        {
            if (checkDepth >= 1)
            {
                if (Highest(hand1.value1, hand2.value1, hand3.value1, hand4.value1, hand5.value1, hand6.value1,
                            hand1.isA, hand2.isA, hand3.isA, hand4.isA, hand5.isA, hand6.isA) && hand1.isA)
                { seat1_phase1 = true; player1 = true; PhaseValues.Add(true); }
                else if (hand1.isA)
                { seat1_phase1 = false; player1 = false; }
                if (Highest(hand2.value1, hand1.value1, hand3.value1, hand4.value1, hand5.value1, hand6.value1,
                            hand2.isA, hand1.isA, hand3.isA, hand4.isA, hand5.isA, hand6.isA) && hand2.isA)
                { seat2_phase1 = true; player2 = true; PhaseValues.Add(true); }
                else if (hand2.isA)
                { seat2_phase1 = false; player2 = false; }
                if (Highest(hand3.value1, hand1.value1, hand2.value1, hand4.value1, hand5.value1, hand6.value1,
                            hand3.isA, hand1.isA, hand2.isA, hand4.isA, hand5.isA, hand6.isA) && hand3.isA)
                { seat3_phase1 = true; player3 = true; PhaseValues.Add(true); }
                else if (hand3.isA)
                { seat3_phase1 = false; player3 = false; }
                if (Highest(hand4.value1, hand2.value1, hand1.value1, hand3.value1, hand5.value1, hand6.value1,
                            hand4.isA, hand2.isA, hand1.isA, hand3.isA, hand5.isA, hand6.isA) && hand4.isA)
                { seat4_phase1 = true; player4 = true; PhaseValues.Add(true); }
                else if (hand4.isA)
                { seat4_phase1 = false; player4 = false; }
                if (Highest(hand5.value1, hand4.value1, hand2.value1, hand1.value1, hand3.value1, hand6.value1,
                            hand5.isA, hand4.isA, hand2.isA, hand1.isA, hand3.isA, hand6.isA) && hand5.isA)
                { seat5_phase1 = true; player5 = true; PhaseValues.Add(true); }
                else if (hand5.isA)
                { seat5_phase1 = false; player5 = false; }
                if (Highest(hand6.value1, hand5.value1, hand4.value1, hand2.value1, hand1.value1, hand3.value1,
                            hand6.isA, hand5.isA, hand4.isA, hand2.isA, hand1.isA, hand3.isA) && hand6.isA)
                { seat6_phase1 = true; player6 = true; PhaseValues.Add(true); }
                else if (hand6.isA)
                { seat6_phase1 = false; player6 = false; }

                foreach (bool i in PhaseValues)
                    cnt++;
                if (cnt == 1)
                    break;
                cnt = 0;
                PhaseValues.Clear();
            }
            if (checkDepth >= 2)
            {
                player1 = false; player2 = false; player3 = false; player4 = false; player5 = false; player6 = false;
                if (Highest(hand1.value2, hand2.value2, hand3.value2, hand4.value2, hand5.value2, hand6.value2,
                            seat1_phase1, seat2_phase1, seat3_phase1, seat4_phase1, seat5_phase1, seat6_phase1) && seat1_phase1)
                { seat1_phase2 = true; player1 = true; PhaseValues.Add(true); }
                else if (seat1_phase1)
                { seat1_phase2 = false; player1 = false; }
                if (Highest(hand2.value2, hand1.value2, hand3.value2, hand4.value2, hand5.value2, hand6.value2,
                            seat2_phase1, seat1_phase1, seat3_phase1, seat4_phase1, seat5_phase1, seat6_phase1) && seat2_phase1)
                { seat2_phase2 = true; player2 = true; PhaseValues.Add(true); }
                else if (seat2_phase1)
                { seat2_phase2 = false; player2 = false; }
                if (Highest(hand3.value2, hand1.value2, hand2.value2, hand4.value2, hand5.value2, hand6.value2,
                            seat3_phase1, seat1_phase1, seat2_phase1, seat4_phase1, seat5_phase1, seat6_phase1) && seat3_phase1)
                { seat3_phase2 = true; player3 = true; PhaseValues.Add(true); }
                else if (seat3_phase1)
                { seat3_phase2 = false; player3 = false; }
                if (Highest(hand4.value2, hand2.value2, hand1.value2, hand3.value2, hand5.value2, hand6.value2,
                            seat4_phase1, seat2_phase1, seat1_phase1, seat3_phase1, seat5_phase1, seat6_phase1) && seat4_phase1)
                { seat4_phase2 = true; player4 = true; PhaseValues.Add(true); }
                else if (seat4_phase1)
                { seat4_phase2 = false; player4 = false; }
                if (Highest(hand5.value2, hand4.value2, hand2.value2, hand1.value2, hand3.value2, hand6.value2,
                            seat5_phase1, seat4_phase1, seat2_phase1, seat1_phase1, seat3_phase1, seat6_phase1) && seat5_phase1)
                { seat5_phase2 = true; player5 = true; PhaseValues.Add(true); }
                else if (seat5_phase1)
                { seat5_phase2 = false; player5 = false; }
                if (Highest(hand6.value2, hand5.value2, hand4.value2, hand2.value2, hand1.value2, hand3.value2,
                            seat6_phase1, seat5_phase1, seat4_phase1, seat2_phase1, seat1_phase1, seat3_phase1) && seat6_phase1)
                { seat6_phase2 = true; player6 = true; PhaseValues.Add(true); }
                else if (seat6_phase1)
                { seat6_phase2 = false; player6 = false; }

                foreach (bool i in PhaseValues)
                    cnt++;
                if (cnt == 1)
                    break;
                cnt = 0;
                PhaseValues.Clear();

            }
            if (checkDepth >= 3)
            {
                player1 = false; player2 = false; player3 = false; player4 = false; player5 = false; player6 = false;
                if (Highest(hand1.value3, hand2.value3, hand3.value3, hand4.value3, hand5.value3, hand6.value3,
                            seat1_phase2, seat2_phase2, seat3_phase2, seat4_phase2, seat5_phase2, seat6_phase2) && seat1_phase2)
                { seat1_phase3 = true; player1 = true; PhaseValues.Add(true); }
                else if (seat1_phase2)
                { seat1_phase3 = false; player1 = false; }
                if (Highest(hand2.value3, hand1.value3, hand3.value3, hand4.value3, hand5.value3, hand6.value3,
                            seat2_phase2, seat1_phase2, seat3_phase2, seat4_phase2, seat5_phase2, seat6_phase2) && seat2_phase2)
                { seat2_phase3 = true; player2 = true; PhaseValues.Add(true); }
                else if (seat2_phase2)
                { seat2_phase3 = false; player2 = false; }
                if (Highest(hand3.value3, hand1.value3, hand2.value3, hand4.value3, hand5.value3, hand6.value3,
                            seat3_phase2, seat1_phase2, seat2_phase2, seat4_phase2, seat5_phase2, seat6_phase2) && seat3_phase2)
                { seat3_phase3 = true; player3 = true; PhaseValues.Add(true); }
                else if (seat3_phase2)
                { seat3_phase3 = false; player3 = false; }
                if (Highest(hand4.value3, hand2.value3, hand1.value3, hand3.value3, hand5.value3, hand6.value3,
                            seat4_phase2, seat2_phase2, seat1_phase2, seat3_phase2, seat5_phase2, seat6_phase2) && seat4_phase2)
                { seat4_phase3 = true; player4 = true; PhaseValues.Add(true); }
                else if (seat4_phase2)
                { seat4_phase3 = false; player4 = false; }
                if (Highest(hand5.value3, hand4.value3, hand2.value3, hand1.value3, hand3.value3, hand6.value3,
                            seat5_phase2, seat4_phase2, seat2_phase2, seat1_phase2, seat3_phase2, seat6_phase2) && seat5_phase2)
                { seat5_phase3 = true; player5 = true; PhaseValues.Add(true); }
                else if (seat5_phase2)
                { seat5_phase3 = false; player5 = false; }
                if (Highest(hand6.value3, hand5.value3, hand4.value3, hand2.value3, hand1.value3, hand3.value3,
                            seat6_phase2, seat5_phase2, seat4_phase2, seat2_phase2, seat1_phase2, seat3_phase2) && seat6_phase2)
                { seat6_phase3 = true; player6 = true; PhaseValues.Add(true); }
                else if (seat6_phase2)
                { seat6_phase3 = false; player6 = false; }

                foreach (bool i in PhaseValues)
                    cnt++;
                if (cnt == 1)
                    break;
                cnt = 0;
                PhaseValues.Clear();

            }
            if (checkDepth >= 4)
            {
                player1 = false; player2 = false; player3 = false; player4 = false; player5 = false; player6 = false;
                if (Highest(hand1.value4, hand2.value4, hand3.value4, hand4.value4, hand5.value4, hand6.value4,
                            seat1_phase3, seat2_phase3, seat3_phase3, seat4_phase3, seat5_phase3, seat6_phase3) && seat1_phase3)
                { seat1_phase4 = true; player1 = true; PhaseValues.Add(true); }
                else if (seat1_phase3)
                { seat1_phase4 = false; player1 = false; }
                if (Highest(hand2.value4, hand1.value4, hand3.value4, hand4.value4, hand5.value4, hand6.value4,
                            seat2_phase3, seat1_phase3, seat3_phase3, seat4_phase3, seat5_phase3, seat6_phase3) && seat2_phase3)
                { seat2_phase4 = true; player2 = true; PhaseValues.Add(true); }
                else if (seat2_phase3)
                { seat2_phase4 = false; player2 = false; }
                if (Highest(hand3.value4, hand1.value4, hand2.value4, hand4.value4, hand5.value4, hand6.value4,
                            seat3_phase3, seat1_phase3, seat2_phase3, seat4_phase3, seat5_phase3, seat6_phase3) && seat3_phase3)
                { seat3_phase4 = true; player3 = true; PhaseValues.Add(true); }
                else if (seat3_phase3)
                { seat3_phase4 = false; player3 = false; }
                if (Highest(hand4.value4, hand2.value4, hand1.value4, hand3.value4, hand5.value4, hand6.value4,
                            seat4_phase3, seat2_phase3, seat1_phase3, seat3_phase3, seat5_phase3, seat6_phase3) && seat4_phase3)
                { seat4_phase4 = true; player4 = true; PhaseValues.Add(true); }
                else if (seat4_phase3)
                { seat4_phase4 = false; player4 = false; }
                if (Highest(hand5.value4, hand4.value4, hand2.value4, hand1.value4, hand3.value4, hand6.value4,
                            seat5_phase3, seat4_phase3, seat2_phase3, seat1_phase3, seat3_phase3, seat6_phase3) && seat5_phase3)
                { seat5_phase4 = true; player5 = true; PhaseValues.Add(true); }
                else if (seat5_phase3)
                { seat5_phase4 = false; player5 = false; }
                if (Highest(hand6.value4, hand5.value4, hand4.value4, hand2.value4, hand1.value4, hand3.value4,
                            seat6_phase3, seat5_phase3, seat4_phase3, seat2_phase3, seat1_phase3, seat3_phase3) && seat6_phase3)
                { seat6_phase4 = true; player6 = true; PhaseValues.Add(true); }
                else if (seat6_phase3)
                { seat6_phase4 = false; player6 = false; }
            }
            if (checkDepth >= 5)
            {
                player1 = false; player2 = false; player3 = false; player4 = false; player5 = false; player6 = false;
                if (Highest(hand1.value5, hand2.value5, hand3.value5, hand4.value5, hand5.value5, hand6.value5,
                            seat1_phase4, seat2_phase4, seat3_phase4, seat4_phase4, seat5_phase4, seat6_phase4) && seat1_phase4)
                { seat1_phase5 = true; player1 = true; PhaseValues.Add(true); }
                else if (seat1_phase4)
                { seat1_phase5 = false; player1 = false; }
                if (Highest(hand2.value5, hand1.value5, hand3.value5, hand4.value5, hand5.value5, hand6.value5,
                            seat2_phase4, seat1_phase4, seat3_phase4, seat4_phase4, seat5_phase4, seat6_phase4) && seat2_phase4)
                { seat2_phase5 = true; player2 = true; PhaseValues.Add(true); }
                else if (seat2_phase4)
                { seat2_phase5 = false; player2 = false; }
                if (Highest(hand3.value5, hand1.value5, hand2.value5, hand4.value5, hand5.value5, hand6.value5,
                            seat3_phase4, seat1_phase4, seat2_phase4, seat4_phase4, seat5_phase4, seat6_phase4) && seat3_phase4)
                { seat3_phase5 = true; player3 = true; PhaseValues.Add(true); }
                else if (seat3_phase4)
                { seat3_phase5 = false; player3 = false;  }
                if (Highest(hand4.value5, hand2.value5, hand1.value5, hand3.value5, hand5.value5, hand6.value5,
                            seat4_phase4, seat2_phase4, seat1_phase4, seat3_phase4, seat5_phase4, seat6_phase4) && seat4_phase4)
                { seat4_phase5 = true; player4 = true; PhaseValues.Add(true); }
                else if (seat4_phase4)
                { seat4_phase5 = false; player4 = false;  }
                if (Highest(hand5.value5, hand4.value5, hand2.value5, hand1.value5, hand3.value5, hand6.value5,
                            seat5_phase4, seat4_phase4, seat2_phase4, seat1_phase4, seat3_phase4, seat6_phase4) && seat5_phase4)
                { seat5_phase5 = true; player5 = true; PhaseValues.Add(true); }
                else if (seat5_phase4)
                { seat5_phase5 = false; player5 = false;  }
                if (Highest(hand6.value5, hand5.value5, hand4.value5, hand2.value5, hand1.value5, hand3.value5,
                            seat6_phase4, seat5_phase4, seat4_phase4, seat2_phase4, seat1_phase4, seat3_phase4) && seat6_phase4)
                { seat6_phase5 = true; player6 = true; PhaseValues.Add(true); }
                else if (seat6_phase4)
                { seat6_phase5 = false; player6 = false; }

                foreach (bool i in PhaseValues)
                    cnt++;
                if (cnt == 1)
                    break;
                cnt = 0;
                PhaseValues.Clear();

            }
        } while (found);

    }

    public bool Highest(int tested, int value1,int value2, int value3, int value4, int value5,
                        bool testBool, bool value1Bool,bool value2Bool, bool value3Bool,bool value4Bool,bool value5Bool)
        
    {
        if (!testBool)
            tested = 0;
        if (!value1Bool)
            value1 = 0;
        if (!value2Bool)
            value2 = 0;
        if (!value3Bool)
            value3 = 0;
        if (!value4Bool)
            value4 = 0;
        if (!value5Bool)
            value5 = 0;
        List<int> allValues = new List<int>();
        bool highest = true;
        allValues.Add(value1); allValues.Add(value2); allValues.Add(value3); allValues.Add(value4); allValues.Add(value5);
        foreach(int i in allValues)
        {
            if(i > tested)
            {
                highest = false;
                break;
            }
        }
        return highest;
    }

    private List<Card> ConvertIntCards(List<int> playerDeck)
    {
        int temp = 0;
        Card someCard = new Card();
        List<Card> newDeck = new List<Card>();
        for (int i = 0; i < playerDeck.Count; i++)
        {
            temp = playerDeck[i];
            temp %= 13;
            temp += 2;
            if (playerDeck[i] >= 0 && playerDeck[i] <= 12)
            {
                someCard.Cardindex = playerDeck[i];
                someCard.Cardvalue = temp;
                someCard.Suit = "heart";
                newDeck.Add(someCard);
            }
            else if (playerDeck[i] >= 13 && playerDeck[i] <= 25)
            {
                someCard.Cardindex = playerDeck[i];
                someCard.Cardvalue = temp;
                someCard.Suit = "diamond";
                newDeck.Add(someCard);
            }
            else if (playerDeck[i] >= 26 && playerDeck[i] <= 38)
            {
                someCard.Cardindex = playerDeck[i];
                someCard.Cardvalue = temp;
                someCard.Suit = "club";
                newDeck.Add(someCard);
            }
            else
            {
                someCard.Cardindex = playerDeck[i];
                someCard.Cardvalue = temp;
                someCard.Suit = "spade";
                newDeck.Add(someCard);
            }
        }
        return newDeck;
    }
    //Redo Highcard, Double and Triple (Combine the decks and check the values)
    #region Check Highcard
    public HandValue HighCard(List<int> playerDeck,List<int> commonDeck)
    {
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);
            List<Card> Combinedcards = new List<Card>();
            Combinedcards = ConvertIntCards(tempTogetherDeck);
            Combinedcards.Sort((a, b) => b.Cardvalue.CompareTo(a.Cardvalue));
            if (Combinedcards[0].Cardvalue > 0)
                handValue.isA = true;
            handValue.value1 = Combinedcards[0].Cardvalue;
            handValue.value2 = Combinedcards[1].Cardvalue;
            handValue.value3 = Combinedcards[2].Cardvalue;
            handValue.value4 = Combinedcards[3].Cardvalue;
            handValue.value5 = Combinedcards[4].Cardvalue;

            Debug.Log("Highcards, Value1:" + handValue.value1 + " Value2:" + handValue.value2 +
                " Value3:" + handValue.value3 + " Value4: " + handValue.value4 + " Value5:" + handValue.value5);
        }
        return handValue;
    }
    #endregion
    #region Check Double
    public HandValue Double(List<int> playerDeck, List<int> commonDeck)
    {

        bool foundDouble = false;
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);

            //List<Card> Playercards = ConvertIntCards(tempPlayerDeck);
            //List<Card> Boardcards = ConvertIntCards(tempCommonDeck);
            List<Card> Combinedcards = new List<Card>();
            Combinedcards = ConvertIntCards(tempTogetherDeck);

            Card temp1 = new Card();


            int n = Combinedcards.Count;
            Combinedcards.Sort((a, b) => a.Cardvalue.CompareTo(b.Cardvalue));
            while (n > 1)
            {
                n--;
                if (Combinedcards[n].Cardvalue == Combinedcards[n - 1].Cardvalue)
                {
                    foundDouble = true;

                    handValue.isA = true;
                    temp1 = Combinedcards[n];

                    handValue.value1 = Combinedcards[n].Cardvalue;
                    break;
                }
            }
            if (foundDouble)
            {
                for (int i = 0; i < 2; i++)
                {
                    Combinedcards.Remove(temp1);
                }
                Combinedcards.Sort((a, b) => b.Cardvalue.CompareTo(a.Cardvalue));

                handValue.value2 = Combinedcards[0].Cardvalue;
                handValue.value3 = Combinedcards[1].Cardvalue;
                handValue.value4 = Combinedcards[2].Cardvalue;
            }
        }
        return handValue;
    }
    #endregion
    #region Check Triple
    public HandValue Triple(List<int> playerDeck, List<int> commonDeck)
    {
        bool foundTriple = false;
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);
            //List<Card> Playercards = ConvertIntCards(tempPlayerDeck);
            //List<Card> Boardcards = ConvertIntCards(tempCommonDeck);
            List<Card> Combinedcards = new List<Card>();
            Combinedcards = ConvertIntCards(tempTogetherDeck);
            Card temp1 = new Card();
            int n = Combinedcards.Count;
            Combinedcards.Sort((a, b) => b.Cardvalue.CompareTo(a.Cardvalue));
            while (n > 2)
            {
                n--;
                if (Combinedcards[n].Cardvalue == Combinedcards[n - 1].Cardvalue && Combinedcards[n - 1].Cardvalue == Combinedcards[n - 2].Cardvalue)
                {
                    temp1 = Combinedcards[n];
                    foundTriple = true;
                }
            }
            if (foundTriple)
            {
                for (int i = 0; i < 3; i++)
                {
                    Combinedcards.Remove(temp1);
                }
                Combinedcards.Sort((a, b) => a.Cardvalue.CompareTo(b.Cardvalue));
                handValue.isA = true;
                handValue.value1 = temp1.Cardvalue;
                handValue.value2 = Combinedcards[0].Cardvalue;
                handValue.value3 = Combinedcards[1].Cardvalue;
            }
        }
        return handValue;
    }

    #endregion
    #region Check Two Pair
   public HandValue TwoPair(List<int> playerDeck, List<int> commonDeck)
    {
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            int temp;
            for (int i = 0; i < tempPlayerDeck.Count; i++)
            {
                temp = tempPlayerDeck[i];
                temp %= 13;
                temp += 2;
                tempPlayerDeck[i] = temp;
            }
            for (int i = 0; i < tempCommonDeck.Count; i++)
            {
                temp = tempCommonDeck[i];
                temp %= 13;
                temp += 2;
                tempCommonDeck[i] = temp;
            }
            List<int> combineValues = new List<int>();
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);
            int Highcard = 0;
            bool doubleFound = false;
            int n = tempTogetherDeck.Count;
            do
            {
                temp = 0;
                doubleFound = false;
                while (n > 0)
                {
                    n--;
                    for (int i = 0; i < n; i++)
                    {
                        if (tempTogetherDeck[i] == tempTogetherDeck[n])
                        {
                            temp = tempTogetherDeck[i];
                            combineValues.Add(temp);
                            doubleFound = true;
                            break;
                        }
                    }
                    if (doubleFound)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            tempTogetherDeck.Remove(temp);
                        }
                        n = tempTogetherDeck.Count;
                        break;
                    }
                }
            } while (doubleFound);
            //Code to find the highcard needed
            tempTogetherDeck.Sort();
            if (combineValues.Count == 1)
                combineValues.Clear();
            combineValues.Sort((a, b) => b.CompareTo(a));
            List<int> combineValuesFinal = new List<int>() { 0, 0 };
            if (combineValues.Count >= 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    combineValuesFinal[i] = combineValues[i];
                }
            }
            tempTogetherDeck.Sort((a, b) => b.CompareTo(a));
            if (combineValues.Count >= 2)
            {
                handValue.isA = true; handValue.value1 = combineValuesFinal[0]; handValue.value2 = combineValuesFinal[1]; handValue.value3 = tempTogetherDeck[0];
            }
            //string twoPair = "TwoPair:Value1:" + combineValuesFinal[0] + "Value2:" + combineValuesFinal[1] + "Highcard:" + handValue.value3;
            //Debug.Log(twoPair);
        }
        return handValue;
    }
    #endregion
    #region Check Straight
    public HandValue Straight(List<int> playerDeck, List<int> commonDeck)
    {
        List<int> tempPlayerDeck = new List<int>(playerDeck);
        List<int> tempCommonDeck = new List<int>(commonDeck);
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            bool hasStraight = false;
            int temp;
            for (int i = 0; i < tempPlayerDeck.Count; i++)
            {
                temp = tempPlayerDeck[i];
                temp %= 13;
                temp += 2;
                tempPlayerDeck[i] = temp;
            }
            for (int i = 0; i < tempCommonDeck.Count; i++)
            {
                temp = tempCommonDeck[i];
                temp %= 13;
                temp += 2;
                tempCommonDeck[i] = temp;
            }
            List<int> combineValues = new List<int>();
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);
            tempTogetherDeck.Sort();
            int Highcard = 0;
            temp = 0;
            int cnt = 0;
            int n = tempTogetherDeck.Count;
            while (n > 0)
            {
                n--;
                if (n == 0)
                    break;
                if ((tempTogetherDeck[n - 1] + 1) == tempTogetherDeck[n])
                {
                    cnt += 1;
                    if (cnt == 4)
                    {
                        temp = tempTogetherDeck[n + 3];
                        hasStraight = true;
                        break;
                    }
                }
                else
                {
                    cnt = 0;
                }

            }
            if (hasStraight)
            {
                handValue.isA = true;
                handValue.value1 = temp;
            }
            int Straight = temp;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < tempPlayerDeck.Count; k++)
                {
                    if (temp == tempPlayerDeck[k])
                    {
                        tempPlayerDeck.Remove(temp);
                        break;
                    }
                }
                temp -= 1;
            }
            tempPlayerDeck.Sort((a, b) => b.CompareTo(a));
            if (tempPlayerDeck.Count > 0)
                Highcard = tempPlayerDeck[0];
        }
        return handValue;
    }
    #endregion
    #region Check Flush
    public HandValue Flush(List<int> playerDeck, List<int> commonDeck)
    {
        List<int> tempPlayerDeck = new List<int>(playerDeck);
        List<int> tempCommonDeck = new List<int>(commonDeck);
        int temp;
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> combineValues = new List<int>();
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);
            List<int> tempTogetherHeart = new List<int>();
            List<int> tempTogetherDiamond = new List<int>();
            List<int> tempTogetherClub = new List<int>();
            List<int> tempTogetherSpade = new List<int>();

            List<int> zeroValues = new List<int>() { 0, 0, 0, 0, 0 };
            List<int> flushValues = new List<int>();
            for (int i = 0; i < tempTogetherDeck.Count; i++)
            {
                temp = tempTogetherDeck[i];
                temp %= 13;
                temp += 2;
                if (tempTogetherDeck[i] >= 0 && tempTogetherDeck[i] <= 12)
                    tempTogetherHeart.Add(temp);
                else if (tempTogetherDeck[i] >= 13 && tempTogetherDeck[i] <= 25)
                    tempTogetherDiamond.Add(temp);
                else if (tempTogetherDeck[i] >= 26 && tempTogetherDeck[i] <= 38)
                    tempTogetherClub.Add(temp);
                else
                    tempTogetherSpade.Add(temp);
                tempTogetherDeck[i] = temp;
            }
            if (tempTogetherHeart.Count >= 5)
            {
                tempTogetherHeart.Sort((a, b) => b.CompareTo(a));
                flushValues.AddRange(tempTogetherHeart);
                handValue.isA = true; handValue.value1 = flushValues[0]; handValue.value2 = flushValues[1]; handValue.value3 = flushValues[2];
                handValue.value4 = flushValues[3]; handValue.value5 = flushValues[4];
                //Debug.Log("Hearts:(" + tempTogetherHeart[0] + ", " + tempTogetherHeart[1] + ", " + tempTogetherHeart[2] + ", " + tempTogetherHeart[3] + ", " + tempTogetherHeart[4]);
            }
            else if (tempTogetherDiamond.Count >= 5)
            {
                tempTogetherDiamond.Sort((a, b) => b.CompareTo(a));
                flushValues.AddRange(tempTogetherDiamond);
                handValue.isA = true; handValue.value1 = flushValues[0]; handValue.value2 = flushValues[1]; handValue.value3 = flushValues[2];
                handValue.value4 = flushValues[3]; handValue.value5 = flushValues[4];
            }
            else if (tempTogetherClub.Count >= 5)
            {
                tempTogetherClub.Sort((a, b) => b.CompareTo(a));
                flushValues.AddRange(tempTogetherClub);
                handValue.isA = true; handValue.value1 = flushValues[0]; handValue.value2 = flushValues[1]; handValue.value3 = flushValues[2];
                handValue.value4 = flushValues[3]; handValue.value5 = flushValues[4];
            }
            else if (tempTogetherSpade.Count >= 5)
            {
                tempTogetherSpade.Sort((a, b) => b.CompareTo(a));
                flushValues.AddRange(tempTogetherSpade);
                handValue.isA = true; handValue.value1 = flushValues[0]; handValue.value2 = flushValues[1]; handValue.value3 = flushValues[2];
                handValue.value4 = flushValues[3]; handValue.value5 = flushValues[4];
            }
            else
                flushValues.AddRange(zeroValues);
            int n = flushValues.Count;
            while (n > 4)
            {
                n--;
                if (!tempCommonDeck.Remove(flushValues[n]))
                {
                    tempPlayerDeck.Remove(flushValues[n]);
                }
            }
            List<int> emptyList = new List<int>();
        }
        return handValue;
    }
    #endregion

    #region Check Full House
    public HandValue FullHouse(List<int> playerDeck, List<int> commonDeck)
    {
        bool fullhouseFound = false;
        bool found = false;
        bool tripleD = false;
        bool tripleF = false;
        bool doubleF = false;
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            int high = 0;
            int low = 0;
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            int cnt = 0;
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            int value1 = 0;
            int value2 = 0;
            List<int> value3 = new List<int>();
            tempTogetherDeck.AddRange(tempPlayerDeck);
            List<int> combinedDeck = new List<int>(tempTogetherDeck);
            for (int i = 0; i < combinedDeck.Count; i++)
            {
                temp1 = combinedDeck[i];
                temp1 %= 13;
                temp1 += 2;
                combinedDeck[i] = temp1;
            }
            combinedDeck.Sort();
            int n = tempTogetherDeck.Count;
            do
            {
                found = false;
                while (n > 2)
                {
                    n--;

                    temp1 = combinedDeck[n - 2];

                    //Debug.Log("Temp1: " + temp1);
                    temp2 = combinedDeck[n - 1];

                    //Debug.Log("Temp2: " + temp2);
                    temp3 = combinedDeck[n];

                    //Debug.Log("Temp3: " + temp3);
                    if (temp1 == temp2 && temp2 == temp3 && !tripleD)
                    {

                        value1 = temp1;
                        found = true;
                        tripleD = true;
                        tripleF = true;
                    }
                    else if ((temp1 == temp2 || temp2 == temp3) && tripleD)
                    {
                        value2 = temp2;
                        //found = true;
                        doubleF = true;
                        fullhouseFound = true;
                    }
                    if (tripleF || doubleF)
                    {
                        if (tripleF)
                        {
                            high = value1;
                            combinedDeck.Remove(value1);
                            combinedDeck.Remove(value1);
                            combinedDeck.Remove(value1);
                        }
                        else if (doubleF)
                        {
                            low = value2;
                            combinedDeck.Remove(value2);
                            combinedDeck.Remove(value2);
                        }
                        n = combinedDeck.Count;
                        tripleF = false;
                        doubleF = false;
                        break;
                    }
                }
            } while (found);
            //Debug.Log("Fullhouse found:V1:" + value1 + "V2:" + value2);
            int val1, val2 = 0;
            cnt = 0;
            if (fullhouseFound == true)
            {

                do
                {
                    n = tempCommonDeck.Count;
                    found = false;
                    for (int i = 0; i < n; i++)
                    {
                        val1 = tempCommonDeck[i];
                        temp1 = tempCommonDeck[i];
                        temp1 %= 13;
                        temp1 += 2;
                        if (temp1 == value1)
                        {
                            cnt += 1;
                            found = true;
                            tempCommonDeck.Remove(val1);
                            break;
                        }
                    }
                    if (cnt == 3)
                        break;
                } while (found);
                do
                {
                    if (cnt == 3)
                        break;
                    n = tempPlayerDeck.Count;
                    found = false;
                    for (int i = 0; i < n; i++)
                    {
                        val1 = tempPlayerDeck[i];
                        temp1 = tempPlayerDeck[i];
                        temp1 %= 13;
                        temp1 += 2;
                        if (temp1 == value1)
                        {
                            cnt += 1;
                            found = true;
                            tempPlayerDeck.Remove(val1);
                            break;
                        }
                    }
                } while (found);
                cnt = 0;
                do
                {
                    if (cnt == 2)
                        break;
                    n = tempCommonDeck.Count;
                    found = false;
                    for (int i = 0; i < n; i++)
                    {
                        val1 = tempCommonDeck[i];
                        temp1 = tempCommonDeck[i];
                        temp1 %= 13;
                        temp1 += 2;
                        if (temp1 == value2)
                        {
                            cnt += 1;
                            found = true;
                            tempCommonDeck.Remove(val1);
                            break;
                        }
                    }

                } while (found);
                do
                {
                    if (cnt == 2)
                        break;
                    n = tempPlayerDeck.Count;
                    found = false;
                    for (int i = 0; i < n; i++)
                    {
                        val1 = tempPlayerDeck[i];
                        temp1 = tempPlayerDeck[i];
                        temp1 %= 13;
                        temp1 += 2;
                        if (temp1 == value2)
                        {
                            cnt += 1;
                            found = true;
                            tempPlayerDeck.Remove(val1);
                            break;
                        }
                    }
                } while (found);

            }

            if (fullhouseFound)
            {

                handValue.isA = true;
                handValue.value1 = high;
                handValue.value2 = low;
            }
        }
        return handValue;
    }
    #endregion
    #region Check Four of a kind
    public HandValue FourOfAKind(List<int> playerDeck, List<int> commonDeck)
    {
        bool foundFour, found = false;
        foundFour = false;
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);
            List<int> combinedDeck = new List<int>(tempTogetherDeck);

            int temp1, temp2, temp3, temp4, value1, cnt, val1 = 0;
            value1 = 0;
            for (int i = 0; i < combinedDeck.Count; i++)
            {
                temp1 = combinedDeck[i];
                temp1 %= 13;
                temp1 += 2;
                combinedDeck[i] = temp1;
            }
            combinedDeck.Sort();
            int n = combinedDeck.Count;


            while (n > 3)
            {
                n--;
                temp4 = combinedDeck[n - 3];
                temp3 = combinedDeck[n - 2];

                //Debug.Log("Temp1: " + temp1);
                temp2 = combinedDeck[n - 1];

                //Debug.Log("Temp2: " + temp2);
                temp1 = combinedDeck[n];

                //Debug.Log("Temp3: " + temp3);
                if (temp1 == temp2 && temp2 == temp3 && temp3 == temp4)
                {

                    value1 = temp1;
                    foundFour = true;
                    handValue.isA = true;
                    handValue.value1 = temp1;
                    break;
                }
            }
            cnt = 0;
            if (foundFour)
            {
                for (int i = 0; i < 4; i++)
                {
                    tempTogetherDeck.Remove(handValue.value1);
                }
                tempTogetherDeck.Sort((a, b) => b.CompareTo(a));
                handValue.value2 = tempTogetherDeck[0];
            }
        }
        return handValue;
    }
    #endregion
    #region Check Straight Flush
    public HandValue StraightFlush(List<int> playerDeck, List<int> commonDeck)
    {
        string straightflush = "";
        bool straightFlush = false;
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);

            //List<Card> Playercards = ConvertIntCards(tempPlayerDeck);
            //List<Card> Boardcards = ConvertIntCards(tempCommonDeck);
            List<Card> Combinedcards = new List<Card>();
            Combinedcards = ConvertIntCards(tempTogetherDeck);

            Card temp1 = new Card();
            Card temp2 = new Card();
            Card temp3 = new Card();
            Card temp4 = new Card();
            Card temp5 = new Card();

            int n = Combinedcards.Count;
            Combinedcards.Sort((a, b) => a.Cardvalue.CompareTo(b.Cardvalue));
            Combinedcards.Sort((a, b) => a.Suit.CompareTo(b.Suit));
            //foreach (Card i in Combinedcards)
            //{
            //    Debug.Log("Card suit: " + i.Suit);
            //    Debug.Log("Card value: " + i.Cardvalue);
            //}

            while (n > 4)
            {
                n--;
                temp1 = Combinedcards[n];
                temp2 = Combinedcards[n - 1];
                temp2.Cardvalue = Combinedcards[n - 1].Cardvalue + 1;
                temp3 = Combinedcards[n - 2];
                temp3.Cardvalue = Combinedcards[n - 2].Cardvalue + 2;
                temp4 = Combinedcards[n - 3];
                temp4.Cardvalue = Combinedcards[n - 3].Cardvalue + 3;
                temp5 = Combinedcards[n - 4];
                temp5.Cardvalue = Combinedcards[n - 4].Cardvalue + 4;
                if (temp1.Cardvalue == temp2.Cardvalue && temp2.Cardvalue == temp3.Cardvalue && temp3.Cardvalue == temp4.Cardvalue && temp4.Cardvalue == temp5.Cardvalue &&
                    temp1.Suit == temp2.Suit && temp2.Suit == temp3.Suit && temp3.Suit == temp4.Suit && temp4.Suit == temp5.Suit)
                {
                    straightFlush = true;
                    break;
                }
            }
            if (straightFlush)
            {
                handValue.isA = true;
                handValue.value1 = temp1.Cardvalue;
            }
            else
            {
                straightflush += "false";
            }
        }
        return handValue;
    }
    #endregion
    #region Check Royal Flush
    public HandValue RoyalFlush(List<int> playerDeck, List<int> commonDeck)
    {
        bool foundRoyalFlush = false;
        HandValue handValue = new HandValue();
        if (playerDeck.Count > 0)
        {
            List<int> tempPlayerDeck = new List<int>(playerDeck);
            List<int> tempCommonDeck = new List<int>(commonDeck);
            List<int> tempTogetherDeck = new List<int>(tempCommonDeck);
            tempTogetherDeck.AddRange(tempPlayerDeck);

            //List<Card> Playercards = ConvertIntCards(tempPlayerDeck);
            //List<Card> Boardcards = ConvertIntCards(tempCommonDeck);
            List<Card> Combinedcards = new List<Card>();
            Combinedcards = ConvertIntCards(tempTogetherDeck);

            Card temp1 = new Card();
            Card temp2 = new Card();
            Card temp3 = new Card();
            Card temp4 = new Card();
            Card temp5 = new Card();

            int n = Combinedcards.Count;
            Combinedcards.Sort((a, b) => a.Cardvalue.CompareTo(b.Cardvalue));
            Combinedcards.Sort((a, b) => a.Suit.CompareTo(b.Suit));
            //foreach (Card i in Combinedcards)
            //{
            //    Debug.Log("Card suit: " + i.Suit);
            //    Debug.Log("Card value: " + i.Cardvalue);
            //}

            while (n > 4)
            {
                n--;
                temp1 = Combinedcards[n];
                temp2 = Combinedcards[n - 1];
                temp2.Cardvalue = Combinedcards[n - 1].Cardvalue + 1;
                temp3 = Combinedcards[n - 2];
                temp3.Cardvalue = Combinedcards[n - 2].Cardvalue + 2;
                temp4 = Combinedcards[n - 3];
                temp4.Cardvalue = Combinedcards[n - 3].Cardvalue + 3;
                temp5 = Combinedcards[n - 4];
                temp5.Cardvalue = Combinedcards[n - 4].Cardvalue + 4;
                if (temp1.Cardvalue == temp2.Cardvalue && temp2.Cardvalue == temp3.Cardvalue && temp3.Cardvalue == temp4.Cardvalue && temp4.Cardvalue == temp5.Cardvalue &&
                    temp1.Suit == temp2.Suit && temp2.Suit == temp3.Suit && temp3.Suit == temp4.Suit && temp4.Suit == temp5.Suit && temp1.Cardvalue == 14)
                {
                    foundRoyalFlush = true;
                    break;
                }
            }
            if (foundRoyalFlush)
            {
                handValue.isA = true;
            }
            else
            {
                handValue.isA = false;
            }
        }
        return handValue;
    }
    #endregion


}
