using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TheFool.server;

namespace TheFool
{
    class Client : IServiceCallback
    {
        ServiceClient server;
        int playerID;

        public Client()
        {
            server = new ServiceClient(new InstanceContext(this));
        }

        public void drawCards(server.Card[] cards)
        {
            throw new NotImplementedException();
        }

        public void endGame()
        {
            throw new NotImplementedException();
        }

        public void startGame()
        {
            playerID = server.joinGame();

            Console.WriteLine("PlayerID: " + playerID);
        }

        public void startTurn(server.Card[] cardsOnDeck)
        {
            throw new NotImplementedException();
        }
    }
}
