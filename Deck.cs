using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    List<int> cards;
    //List<int> cardsCopy;
    //Making a delegate
    public delegate void OnDeckIntCreated();
    public event OnDeckIntCreated onComplete;

    void Start()
    {
        onComplete +=  Shuffle;
        onComplete += FindObjectOfType<GameController>().GetDeckInt;
         
        onComplete();
    }

    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)
        {
            yield return i;
        }
    }

    public void Shuffle()
    {
        if (cards == null)
        {
            cards = new List<int>();
        }
        else
        {
            cards.Clear();
        }

        for (int i = 0; i < 52; i++)
        {
            cards.Add(i);
        }

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
        
    }

    public int Pop()
    {
        int temp = -1;
        if (cards != null)
        {
            temp = cards[0];
            cards.RemoveAt(0);
        }
        return temp;
    }

    public List<int>GetCardsInt()
    {
        return cards;
    }

	

    
}
