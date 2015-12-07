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
            if (GameTable == null)
            {
                this.GameTable = new Table();
                int playerID = GameTable.myPlayer.ID;
                proxy.PlayRandom(playerID);
            }
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

        public void HostGame()
        {
            //Creates table with ID (which will be used as token to join)
            if(GameTable == null)
            {
                this.GameTable = new Table();
                int playerID = GameTable.myPlayer.ID;
                proxy.HostGame(GameTable.TableID, playerID);
            }
        }

        public void JoinGame(int token)
        {
            //Joins table with specified token
            //Creates local table
            if (GameTable == null)
            {
                this.GameTable = new Table(token);
                int playerID = GameTable.myPlayer.ID;
                if (proxy.JoinGame(token, playerID) != Errors.NONE)
                    this.GameTable = null;
            }
        }


        //Methods from IGameCallBack <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public void PlayerTurn(int playerID) 
        { 
            // Check if it's your turn

            // if TRUE, notify user to attack

            // else, wait for opponent to atack
        }

        //Might be not needed since each client knows what is on the table
        //Might be used to update client GUI
        public void CardsOnTable(List<Card> c) { }

        //Probably not needed since Attack() and Defend() returns true/false now
        public void InvalidMove(Errors e) { }

        public void DrawCards(List<Card> c) 
        {
            if (c.Count > 0 && GameTable != null)
                GameTable.myPlayer.TakeCards(c);
        }

        public void ReceivedMessage(String message) { }

        public void CannotHost(Errors e) { }

        //Probably not needed since JoinGame has return value now
        public void CannotJoin(Errors e) { }

        public void PlayerReady(int playerID) 
        {
            //set the opponent
            this.GameTable.SetOpponent(playerID);
            // wait to be notified who has next turn
        }

        public void GameOver(int yourPossition) 
        { 
            // Notify user of his achievements

            // Update statistics
            // Destry the table after game ends
            this.GameTable = null;
        }
    }
}
