using GameContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFool;

namespace GameService
{
    class Program : IGame
    {
        private Dealer aDealer;

        static void Main(string[] args)
        {

        }

        private void Init()
        {

        }
        
        public bool Attack(Card c)
        {
            // Put the card on the table
            return aDealer.PlayCard(c);
        }

        public void EndAttack()
        {
            aDealer.EndAttack();
        }

        public bool Defend(Card c)
        {
            if (aDealer.PlayCard(c))
                return true;
            else
                return false;
        }

        List<Card> TakeCards()
        {
            // Get cards off the table and
            // return them to the player
            return aDealer.GetCardsOnTable();
        }

        public void Surrender()
        {
            // Notify opponenet that player surrendered
            // Get rid of the dealer
        }

        public void PlayRandom(int playerID)
        {
            // If it's a first player
                // Wait for another one
            // If it's second
                // Create a dealer
                // Start the game
        }

        public void HostGame(int token, int playerID)
        {
            // create the token
            // wait for somebody to join
        }

        public Errors JoinGame(int token, int playerID)
        {
            // Check if the token is valid
            // create dealer
            // Start game
            return Errors.NONE;
        }
    }
}
