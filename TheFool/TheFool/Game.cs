using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameContract;

namespace TheFool
{
    class Game : IGameCallback
    {
        private Table GameTable;
        private GameClient proxy;

        public Game()
        {
            // instantiate a proxy to contact the service
            WSHttpBinding binding = new WSHttpBinding();
            Uri address = new Uri("http://localhost:8000/calculatorservice");
            EndpointAddress endpointAddress = new EndpointAddress(address);
            proxy = new GameClient(binding, endpointAddress);
        }

        /// <summary>
        /// Starts game against random player
        /// </summary>
        public void Play()
        {

        }

        /// <summary>
        /// Displays personal game statistics
        /// </summary>
        public void CheckStatistics()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows Help page
        /// </summary>
        public void SeeHelp()
        {
            throw new NotImplementedException();
        }

        public void HostGame(string playerName)
        {
            //Creates table with ID (which will be used as token to join)
        }
        public void JoinGame(int token, string playerName)
        {
            //Joins table with specified token
            //Creates local table
        }


        //Methods from IGameCallBack <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public void PlayerTurn(int playerID) { }

        //Might be not needed since each client knows what is on the table
        public void CardsOnTable(List<Card> c) { }

        public void InvalidMove(Errors e) { }

        public void DrawCards(List<Card> c) 
        {
            if (c.Count > 0)
                GameTable.myPlayer.TakeCards(c);
        }

        public void ReceivedMessage(String message) { }

        public void CannotHost(Errors e) { }

        public void CannotJoin(Errors e) { }

        public void PlayerReady(int playerID) { }

        public void GameOver(int yourPossition) { }


    }
}
