using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFool
{
    class Table
    {
        private List<Card> CardsOnTable;
        Player myPlayer;
        private int opponentID;

        public Int32 TableID { get; private set; }

        /// <summary>
        /// Creates table with specified table ID and players name
        /// </summary>
        /// <param name="id">Table id. Used as token when hosting/joining the game</param>
        /// <param name="name">Name of the player that's using this client</param>
        public Table(int id, string name)
        {
            opponentID = -1;
            this.CardsOnTable = new List<Card>();
        }

        /// <summary>
        /// Sets opponent for the player. Opponent cannont be changed for specified table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SetOpponent(int id)
        {
            if (this.opponentID == -1)
            {
                this.opponentID = id;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Adds card to the tableS
        /// </summary>
        /// <param name="c"></param>
        public void AddCard(Card c)
        {
            if(c.GetValue() != CardValues.NULL)
                CardsOnTable.Add(c);
        }

        /// <summary>
        /// Clears cards on the table at the end of each turn
        /// </summary>
        /// <returns>List of cards</returns>
        public List<Card> ClearTable()
        {
            List<Card> temp = CardsOnTable;
            CardsOnTable.Clear();
            return temp;
        }

        /// <summary>
        /// Tells that player with specified ID surrenders
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>FALSE if player with specified ID is not playing</returns>
        public bool Surrender(int playerID)
        {
            //TO Do
            throw new NotImplementedException();
        }
    }
}
