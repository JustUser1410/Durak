using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFool
{
    class Game
    {
        private Table GameTable;

        public Game()
        {
        }

        /// <summary>
        /// Starts game against random player
        /// </summary>
        public void Play();

        /// <summary>
        /// Displays personal game statistics
        /// </summary>
        public void CheckStatistics();

        /// <summary>
        /// Shows Help page
        /// </summary>
        public void SeeHelp();

        public void HostGame(string playerName)
        {
            //Creates table with ID (which will be used as token to join)
        }
        public void JoinGame(int token, string playerName)
        {
            //Joins table with specified token
            //Creates local table
        }
    }
}
