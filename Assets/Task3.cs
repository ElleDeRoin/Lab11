using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    public int maxDeckSize = 16;
    public int currentDeckSize;
    public int minDeckSize = 0;
    public int handSize = 4;

    bool gameWon = false;

    List<(string rank, string suit)> deck = new();
    List<(string rank, string suit)> hand = new();

    void Awake()
    {
        string[] ranks = { "K", "Q", "A", "J" };
        string[] suits = { "\u2665", "\u2660", "\u2666", "\u2663" };

        foreach (var rank in ranks)
        {
            foreach (var suit in suits)
            {
                deck.Add((rank, suit));
            }
        }
    }

    void Start()
    {
        StartingHand();
        Turn();
    }

    void StartingHand()
    {
        shuffleCards();

        for (int i = 0; i < handSize; i++)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }

        currentDeckSize = deck.Count;

        Debug.Log("Starting Hand:");
        DebugHand();
    }

    void Turn()
    {
        while (currentDeckSize > minDeckSize && !gameWon)
        {
 
            int removeIndex = Random.Range(0, hand.Count);
            hand.RemoveAt(removeIndex);


            if (deck.Count > 0)
            {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
                currentDeckSize--;
            }

            DebugHand();

            checkWin();

            if (gameWon)
            {
                gameWin();
                return;
            }

            if (currentDeckSize == 0)
            {
                gameLoss();
                return;
            }

            Debug.Log("This is not a winning hand. Trying another round...");
        }
    }

    void checkWin()
    {
        var suitGroups = hand.GroupBy(card => card.suit);

        foreach (var group in suitGroups)
        {
            if (group.Count() >= 3)
            {
                gameWon = true;
                return;
            }
        }
    }

    void gameWin()
    {
        Debug.Log("The game is WON");
    }

    void gameLoss()
    {
        Debug.Log("The deck is empty. The game is LOST");
    }

    void shuffleCards()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(i, deck.Count);
            var temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    void DebugHand()
    {
        string handString = "Hand: ";

        foreach (var card in hand)
        {
            handString += $"{card.rank}{card.suit} ";
        }

        Debug.Log(handString);
    }
}