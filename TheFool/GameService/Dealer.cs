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
        private int attacker;               // ID of a player that currently attacks
        private int pTurn;                  // Player that has the current turn

        // It takes player IDs at the beginning
        public Dealer() 
        {
            this.player1 = 0;
            this.player2 = 0;

            callbacks = new List<IGameCallback>();

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
            {
                foreach (IGameCallback item in callbacks)
                    item.PlayerTurn(player1);
                pTurn = player1;
                attacker = player1;
            }
            else
            {
                foreach (IGameCallback item in callbacks)
                    item.PlayerTurn(player2);
                pTurn = player1;
                attacker = player1;
            }
        }

        /// <summary>
        /// Checks if the game is supposed to end. 
        /// It must be called every time one of the players runs out of cards in his hand.
        /// </summary>
        /// <param name="PlayerID">ID of a player that ran out of cards</param>
        /// <returns></returns>
        public bool GameEnds(int PlayerID)
        { 
            // One of the players ran out of cards
            // There are no more cards in the deck
            if (Deck.Count == 0)
            {
                foreach (IGameCallback c in callbacks)
                    if (player1 == PlayerID)
                        c.GameOver(1);
                    else
                        c.GameOver(0);
                return true;
            }
            else
            {
                EndAttack();
                return false;
            }
        }

        // For now, Attack can last as long as both players still have some cards
        // Ideally attack should not last more than 12 turns (there can't be more than 12 cards on the table)
        public bool PlayCard(Card c)
        {
            this.cardsOnTable.Add(c);
            if (cardsOnTable.Count % 2 != 0)
            {
                // if both are trump cards and defenders' is higher
                if (cardsOnTable[cardsOnTable.Count - 1].GetSuit() == this.TrumpSuit
                    && cardsOnTable[cardsOnTable.Count - 2].GetSuit() == this.TrumpSuit
                    && cardsOnTable[cardsOnTable.Count - 2].GetValue() < cardsOnTable[cardsOnTable.Count - 1].GetValue())
                {
                    // Notify opponent about successful defence
                    NextTurn();
                    return true;
                }
                //if defenders' is trump
                else if (cardsOnTable[cardsOnTable.Count - 1].GetSuit() == this.TrumpSuit
                    && cardsOnTable[cardsOnTable.Count - 2].GetSuit() != this.TrumpSuit)
                {
                    // Notify opponent about successful defence
                    NextTurn();
                    return true;
                }
                // if suit is the same and defenders' card is higher
                else if (cardsOnTable[cardsOnTable.Count - 1].GetSuit() == cardsOnTable[cardsOnTable.Count - 2].GetSuit()
                    && cardsOnTable[cardsOnTable.Count - 2].GetValue() < cardsOnTable[cardsOnTable.Count - 1].GetValue())
                {
                    // Notify opponent about successful defence
                    NextTurn();
                    return true;
                }
                else
                {
                    // remove the last card  from the table
                    cardsOnTable.RemoveAt(cardsOnTable.Count - 1);
                    return false;
                }
            }
            else
            {
                // Check if attack is possible
                    // Card value must mach one of those on the table
                if (cardsOnTable.Count == 1) // Its the first card
                {
                    // Notify opponent to defend
                    NextTurn();
                    return true;
                }
                else
                {
                    foreach (Card card in cardsOnTable)
                        if (c.GetValue() == card.GetValue() && c.GetType() != card.GetType()) // one of the cards has the same value, but it's not the same card
                        {
                            NextTurn();
                            return true;
                        }
                    cardsOnTable.RemoveAt(cardsOnTable.Count - 1);
                    return false;
                }
            }
        }

        public List<Card> GetCardsOnTable()
        {
            List<Card> output = cardsOnTable;
            // Clean the table
            cardsOnTable.Clear();
            // Notify opponent that he has turn
            NextTurn();
            return output;
        }

        /// <summary>
        /// Gives turn to the next player
        /// </summary>
        private void NextTurn()
        {
            // Take note of next player
            if (pTurn == player1)
                pTurn = player2;
            else
                pTurn = player1;
            // notify players about who has the next turn
            foreach (IGameCallback item in callbacks)
            {
                item.PlayerTurn(pTurn);
                // notify players about cards on the table
            }
        }

        public void EndAttack()
        {
            int cardCount = cardsOnTable.Count;
            List<Card> p1Draw = new List<Card>();
            List<Card> p2Draw = new List<Card>();
            // Clear the table
            cardsOnTable.Clear();
            // Ask players if they need more cards
                // (Need to add method that returns how many cards each player has) ------------------------------TO DO-------
            // For now we return the same amount of cards that the players put on the table
            for (int i = 0; i < cardCount && Deck.Count > 0; i++ )
            {
                // now it's drawing cards one by one
                // actual rule is that attacker draws first, I'll do it later ------------------------------------TO DO-------
                if (i % 2 == 0)
                    p1Draw.Add(Deck[0]);
                else
                    p2Draw.Add(Deck[0]);
                Deck.RemoveAt(0);
            }
            // Deal the cards
            this.callbacks[0].DrawCards(p1Draw);
            this.callbacks[1].DrawCards(p2Draw);
            // Notify players about next turn
            NextTurn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>True if 2nd player connected</returns>
        public bool Connect(int playerID)
        {
            bool returnvalue = false;
            IGameCallback callback = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            if (player1 == 0)
            {
                player1 = playerID;
                callbacks.Insert(0, callback);
            }
            else if (player2 == 0)
            {
                if (player2 == player1)
                    return false;
                player2 = playerID;
                callbacks.Insert(1, callback);
                // If it's second player, deal cards and start the game
                DealCards();
            }
            return returnvalue;
        }

        public void Surrender(int playerID)
        {
            Deck.Clear();
            if (player1 == playerID)
                GameEnds(player2);
            else
                GameEnds(player1);
        }

    }
}
