using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class Service : IService
    {
        private int connectedClients;
        private List<Card> deck;
        private List<Card> tableCards;
        private List<Card>[] playerCards;
        private List<IClient> playerCallbacks;

        public Service()
        {
            connectedClients = 0;
            deck = new List<Card>();
            tableCards  = new List<Card>();
            playerCards = new List<Card>[2] { new List<Card>(), new List<Card>() };
            playerCallbacks = new List<IClient>();
        }

        public void clientConnected()
        {
            connectedClients++;

            if (connectedClients == 2)
            {
                generateCards();
                shuffleDeck();
                dealCards();

                playerCallbacks[0].drawCards(playerCards[0]);
                playerCallbacks[1].drawCards(playerCards[1]);
                
                playerCallbacks[0].startTurn(tableCards, playerCards[0]);
            }
        }

        public void joinGame()
        {
            var playerID = playerCallbacks.Count;

            var clientCallback = OperationContext.Current.GetCallbackChannel<IClient>();
            playerCallbacks.Add(clientCallback);
            clientCallback.gameJoined(playerCallbacks.Count - 1);
        }

        public void play(int playerID, Card card)
        {
            tableCards.Add(card);
            playerCards[playerID].Remove(card);
            var nextPlayerID = playerID == 0 ? 1 : 0;

            if (playerCards[playerID].Count == 0)
            {
                playerCallbacks[playerID].victory();
                playerCallbacks[nextPlayerID].loss();
            }
            else
            {
                playerCallbacks[nextPlayerID].startTurn(tableCards, playerCards[nextPlayerID]);
            }
        }

        public void sendMessage(int playerID, string message)
        {
            var receipient = playerID == 0 ? 1 : 0;
            playerCallbacks[receipient].receiveMessage(playerID, message);
        }

        public void surrender(int playerID)
        {
            var opponent = playerID == 0 ? 1 : 0;
            playerCallbacks[opponent].endGame();
        }

        // ====================================================================
        // PRIVATE
        // ====================================================================

        private void generateCards()
        {
            // For 4 suits
            var s = CardSuit.HEARTS;
            do
            {
                // Generate cards for each suit
                var v = CardValues.SIX;
                do
                {
                    deck.Add(new Card(v, s));
                    //Go to next card
                    v++;
                } while (v <= CardValues.ACE);
                //Go to next suit
                s++;
            } while (s <= CardSuit.SPADES);
        }

        private void shuffleDeck()
        {
            // Assigns random number to each element in the list and then orders the list
            var rnd = new Random();
            deck.OrderBy(item => rnd.Next());
        }

        private void dealCards()
        {
            for (int i = 0; i < 6; i++)
            {
                playerCards[0].Add(deck[0]);
                deck.RemoveAt(0);
                playerCards[1].Add(deck[0]);
                deck.RemoveAt(0);
            }
        }
    }
}
