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
        private int opponentID;

        public Int32 TableID { get; private set; }
        public Player myPlayer { get; private set; }

        /// <summary>
        /// Creates table with specified table ID
        /// </summary>
        /// <param name="id">Table id. Used as token when hosting/joining the game</param>
        public Table(int id)
        {
            opponentID = -1;
            this.TableID = id;
            this.CardsOnTable = new List<Card>();
            this.myPlayer = new Player(
                (new Random()).Next(10,1000), "Player");
        }

        /// <summary>
        /// Creates new table with random ID
        /// </summary>
        public Table()
        {
            opponentID = -1;
            this.TableID = (new Random()).Next(10, 10000);
            this.CardsOnTable = new List<Card>();
            this.myPlayer = new Player(
                (new Random()).Next(10, 1000), "Player");
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
