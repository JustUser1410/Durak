using GameContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
            ServiceHost host = new ServiceHost(typeof(Program));

            // define an endpoint for the service
            Type contract = typeof(IGame);
            WSHttpBinding binding = new WSHttpBinding();
            Uri address = new Uri("http://localhost:8000/GameService");
            host.AddServiceEndpoint(contract, binding, address);

            // start hosting
            host.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is being hosted at address " + address);
            Console.WriteLine("Press <ENTER> to stop hosting.\n");
            Console.ReadLine();

            // stop hosting
            host.Close();
        }

        
        public bool Attack(int playerID, Card c)
        {
            // Put the card on the table
            return aDealer.PlayCard(c);
        }

        public void EndAttack(int playerID)
        {
            aDealer.EndAttack();
        }

        public bool Defend(int playerID, Card c)
        {
            if (aDealer.PlayCard(c))
                return true;
            else
                return false;
        }

        public List<Card> TakeCards(int playerID)
        {
            // Get cards off the table and
            // return them to the player
            return aDealer.GetCardsOnTable();
        }

        public void Surrender(int playerID)
        {
            // Notify opponenet that player surrendered
            aDealer.Surrender(playerID);
            // Get rid of the dealer
            aDealer = null;
        }

        public void PlayRandom(int playerID)
        {
            if (aDealer == null)
            {
                aDealer = new Dealer();
                aDealer.Connect(playerID);
            }
            else
                aDealer.Connect(playerID);
        }

        public void HostGame(int token, int playerID)
        {
            // create the token
            // wait for somebody to join
        }

        public Errors JoinGame(int token, int playerID)
        {
            // Check if the token is valid
            // Start game
            return Errors.NONE;
        }

        public void OutOfCards(int playerID)
        {
            // Check if game ends
            if (aDealer.GameEnds(playerID))
            {
                // Discard of the dealer
                aDealer = null;
            }
            else
            {
                aDealer.EndAttack();
            }
        }
    }
}
