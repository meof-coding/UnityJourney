using System;
using System.Collections.Generic;
using ConsoleCards;

// IMPORTANT: Only add code in the section
// indicated below. The code I've provided
// makes your solution work with the 
// automated grader on Coursera

/// <summary>
/// Programming Assignment 3
/// </summary>
class Program
{
    /// <summary>
    /// Programming Assignment 3
    /// </summary>
    /// <param name="args">command-line args</param>
    static void Main(string[] args)
    {
        // loop while there's more input
        string input = Console.ReadLine();
        while (input[0] != 'q')
        {

            // Add your code between this comment
            // and the comment below. You can of
            // course add more space between the
            // comments as needed

            // declare a deck variables and create a deck object
            Deck deck = new Deck();
            // DON'T SHUFFLE THE DECK

            // deal 2 cards each to 4 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)
            //List int 
            List<Card> player1 = new List<Card>();
            List<Card> player2 = new List<Card>();
            List<Card> player3 = new List<Card>();
            List<Card> player4 = new List<Card>();
            for (int i = 0; i < 2; i++)
            {
                player1.Add(deck.TakeTopCard());
                player2.Add(deck.TakeTopCard());
                player3.Add(deck.TakeTopCard());
                player4.Add(deck.TakeTopCard());
            }

            // deal 1 more card to players 2 and 3
            player2.Add(deck.TakeTopCard());
            player3.Add(deck.TakeTopCard());


            // flip all the cards over
            foreach (Card card in player1)
            {
                card.FlipOver();
                // print the cards for player 1
                // The required format for printing out a card is the card rank, followed by a comma, followed by the card suit.
                Console.WriteLine(card.Rank + "," + card.Suit);
            }

            foreach (Card card in player2)
            {
                card.FlipOver();
                // print the cards for player 2
                Console.WriteLine(card.Rank + "," + card.Suit);

            }

            foreach (Card card in player3)
            {
                card.FlipOver();
                // print the cards for player 3
                Console.WriteLine(card.Rank + "," + card.Suit);
            }

            foreach (Card card in player4)
            {
                card.FlipOver();
                 // print the cards for player 4
                Console.WriteLine(card.Rank + "," + card.Suit);
            }

            // Don't add or modify any code below
            // this comment
            input = Console.ReadLine();
        }
    }
}