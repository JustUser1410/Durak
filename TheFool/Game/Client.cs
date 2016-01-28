using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Game.server;

namespace Game
{
    public class Client : IServiceCallback
    {
        public int playerID { get; private set; }
        private ServiceClient server;

        public Client()
        {
            server = new ServiceClient(new InstanceContext(this));
        }

        public void drawCards(Card[] cards)
        {
            Console.WriteLine("Game has begun!");
            Console.WriteLine("\n");
        }

        public void endGame()
        {
            Console.WriteLine("\nOpponent has surrendered");
        }

        public void startGame()
        {
            playerID = server.joinGame();
            Console.WriteLine($"Welcome Player {playerID + 1}");
            Console.WriteLine("Waiting for all players...");
        }

        public void startTurn(Card[] cardsOnTable, Card[] playerCards)
        {
            Console.WriteLine("\n=============\nIT's YOUR TURN!");
            Console.WriteLine("Cards on Table:");
            printCards(cardsOnTable);
            Console.WriteLine("\nAvailable Cards:");
            printCards(playerCards);

            Console.Write("\nChoose card to play: ");
            var cardIndex = Convert.ToInt32(Console.ReadLine());

            server.play(playerID, playerCards[cardIndex - 1]);
        }

        public void victory()
        {
            Console.WriteLine("\n\nYOU HAVE WON!");
        }

        public void loss()
        {
            Console.WriteLine("\n\nYou have lost...");
        }

        public void receiveMessage(int playerID, string message)
        {

        }

        private void printCards(Card[] cards)
        {
            for (int i = 0; i < cards.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {cards[i].suit.ToString()} -> {cards[i].value.ToString()}");
            }
        }
    }
}
