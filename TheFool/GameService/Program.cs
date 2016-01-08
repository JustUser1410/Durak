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
        static void Main(string[] args)
        {
        }

        
        public bool Attack(Card c)
        {
            return true;
        }

        public bool Defend(Card c)
        {
            return true;
        }

        public void Surrender()
        {

        }

        public void PlayRandom(int playerID)
        {

        }

        public void HostGame(int token, int playerID)
        {

        }

        public Errors JoinGame(int token, int playerID)
        {
            return Errors.NONE;
        }
    }
}
