using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFool;      // Not sure why Card class and enumerations are used from here, but that's the only way it works
using System.ServiceModel;
using GameContract;

namespace GameService
{
    class Dealer
    {
        private List<Card> Deck;
        private List<Card> cardsOnTable;
        private CardSuit TrumpSuit;         //  The suit that defeats others
        private List<IGameCallback> callbacks;
        private int player1;
        private int player2;

        // It takes player IDs at the beginning
        public Dealer(int player1, int player2) 
        {
            this.player1 = player1;
            this.player2 = player2;
            
            // Set up contracts
            // TO DO

            this.Deck = new List<Card>();
            this.cardsOnTable = new List<Card>();

            // Fill the deck with cards
            GenerateCards();
            // Shuffle the deck
            ShuffleDeck();
        }

        private void GenerateCards()
        {
            // For 4 suits
            CardSuit s = CardSuit.HEARTS;
            do
            {
                // Generate cards for each suit
                CardValues v = CardValues.SIX;
                do
                {
                    this.Deck.Add(new Card(v, s));
                    //Go to next card
                    v++;
                } while (v <= CardValues.ACE);
                //Go to next suit
                s++;
            } while (s <= CardSuit.SPADES);
        }

        private void ShuffleDeck()
        {
            // Assigns random number to each element in the list and then orders the list
            var rnd = new Random();
            this.Deck.OrderBy(item => rnd.Next());
        }

        private void DealCards()
        {
            List<Card> p1 = new List<Card>();
            List<Card> p2 = new List<Card>();
            // Make listst of 6 cards for both players
            while (p1.Count < 6 && p2.Count < 6)
            {
                p1.Add(this.Deck[0]);
                this.Deck.RemoveAt(0);
                p2.Add(this.Deck[0]);
                this.Deck.RemoveAt(0);
            }
            // Check Trump Suit
            // It's the last card in the deck
            this.TrumpSuit = this.Deck[this.Deck.Count - 1].GetSuit();

            // Give cards to players
            this.callbacks[0].DrawCards(p1);
            this.callbacks[1].DrawCards(p2);

            // Check, which one is first
            DecideFirstPlayer(p1, p2);
        }

        // Right now it assumes that at least one of the players has a Trump Suit
        // This will have to be fixed
        private void DecideFirstPlayer(List<Card> p1, List<Card> p2)
        {
            Card p1Smallest = null;
            Card p2Smallest = null;
            // Find smallest Trump of Player1
            for (int i = 0; i < 6; i++)
                if (p1[i].GetSuit() == this.TrumpSuit)
                    for (int j = i; j < 6; i++)
                        if (p1[j].GetSuit() == this.TrumpSuit)
                            if (p1[i].GetValue() > p1[j].GetValue())
                                p1Smallest = p1[j];
                            else
                                p1Smallest = p1[i];
            // Find smallest Trump of Player2
            for (int i = 0; i < 6; i++)
                if (p2[i].GetSuit() == this.TrumpSuit)
                    for (int j = i; j < 6; i++)
                        if (p2[j].GetSuit() == this.TrumpSuit)
                            if (p2[i].GetValue() > p2[j].GetValue())
                                p2Smallest = p2[j];
                            else
                                p2Smallest = p2[i];
            // Decide who takes the first turn
            // Anounce that player to everybody
            if (p1Smallest.GetValue() < p2Smallest.GetValue())
                foreach(IGameCallback item in callbacks)
                    item.PlayerTurn(player1);
            else
                foreach (IGameCallback item in callbacks)
                    item.PlayerTurn(player2);
        }

        private void GameEnds()
        { 

        }

    }
}
