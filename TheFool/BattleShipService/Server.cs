using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameContract;

namespace ChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Server : IServer
    {
        private List<IClient> playerCallbacks;

        private List<Card> deck;
        private List<Card> cardsOnTable;
        private List<Card> cardsPlayer1;
        private List<Card> cardsPlayer2;
        
        private int nextPlayerID;

        public int joinGame()
        {
            var playerID = playerCallbacks.Count;

            IClient clientCallback = OperationContext.Current.GetCallbackChannel<IClient>();
            playerCallbacks.Add(clientCallback);

            // We can start game when quorum is reached
            if (playerCallbacks.Count == 2)
            {
                generateCards();
                shuffleDeck();
                dealCards();
            }

            return playerID;
        }

        public void play(int playerID, Card card)
        {
            if (playerID == 0)
            {
                nextPlayerID = 1;
            }
            else if (playerID == 1)
            {
                nextPlayerID = 0;
            }

            cardsOnTable.Add(card);

            playerCallbacks[nextPlayerID].startTurn(cardsOnTable);
        }

        // ====================================================================
        // PRIVATE
        // ====================================================================

        private void generateCards()
        {
            // For 4 suits
            CardSuit s = CardSuit.HEARTS;
            do
            {
                // Generate cards for each suit
                CardValues v = CardValues.SIX;
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
            while (cardsPlayer1.Count < 6 && cardsPlayer2.Count < 6)
            {
                cardsPlayer1.Add(deck[0]);
                deck.RemoveAt(0);
                cardsPlayer2.Add(deck[0]);
                deck.RemoveAt(0);
            }

            playerCallbacks[0].drawCards(cardsPlayer1);
            playerCallbacks[1].drawCards(cardsPlayer2);
        }
    }
}
