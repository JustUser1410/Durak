using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFool
{
    class Player
    {
        private List<Card> cards;

        public int ID { get; private set; }
        public String Name { get; private set; }

        /// <summary>
        /// Creates player with specified id and name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Player(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.cards = new List<Card>();
        }

        /// <summary>
        /// Plays one card from players hand. Returns the card that was played
        /// </summary>
        /// <param name="index"> index of the card</param>
        /// <returns>card at index</returns>
        public Card PlayCard(int index)
        {
            Card temp = new Card(CardValues.NULL, CardSuit.NULL);
            if (cards.Count > index)
            {
                temp = cards[index];
                cards.RemoveAt(index);
            }
            return temp;
        }

        /// <summary>
        /// Gives player a list of cards
        /// </summary>
        /// <param name="c">list of cards</param>
        public void TakeCards(List<Card> c)
        {
            if (c.Count > 0)
                foreach (Card card in c)
                    cards.Add(card);
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}
