using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public struct Card
    {
        public CardValues value;
        public CardSuit suit;

        public Card(CardValues value, CardSuit suit)
        {
            this.value = value;
            this.suit = suit;
        }
    }

    public enum CardValues
    {
        NULL = 0,
        SIX = 6,
        SEVEN = 7,
        EIGHT = 8,
        NINE = 9,
        TEN = 10,
        JACK = 11,
        QUEEN = 12,
        KING = 13,
        ACE = 14
    };

    public enum CardSuit
    {
        NULL,
        HEARTS,
        DIAMONDS,
        CLUBS,
        SPADES
    }
}
