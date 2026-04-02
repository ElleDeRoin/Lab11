using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    public int maxDeckSize = 16;
    public int currentDeckSize = 16;
    public int minDeckSize = 0;
    public int handSize = 4;
    bool gameWon = false;


    Dictionary<string, string> Cards = new()
{
    { "K", "\u2665" },
    { "K", "\u2660" },
    { "K", "\u2666" },
    { "K", "\u2663" },
    { "Q", "\u2665" },
    { "Q", "\u2660" },
    { "Q", "\u2666" },
    { "Q", "\u2663" },
    { "A", "\u2665" },
    { "A", "\u2660" },
    { "A", "\u2666" },
    { "A", "\u2663" },
    { "J", "\u2665" },
    { "J", "\u2660" },
    { "J", "\u2666" },
    { "J", "\u2663" },
};




    void Start()
    {
        StartingHand();
        Turn();
    }

    void StartingHand()
    {
        //shuffleCards();
        //give first 4 cards
        //subtract 4 cards from current deck size
    }

    void Turn()
    {
        while (currentDeckSize > minDeckSize && (!gameWon))
        {

            //discard a random card from hand and draw another from deck
            // currentDeckSize -= 1;
            //debug log current hand

            //checkWin()

            //if game won gameWon = true break gameWin()
            //if out of cards break loss gameLoss()

            //if not won debug.log("This is not a winning hand. I will attempt to play another round.")


        }
    }
    void checkWin()
    {
        //check if at least 3 of the cards are the same suit
        // if yes gameWon = true
        //if no continue Turn();
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

    }
}
