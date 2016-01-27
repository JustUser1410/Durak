using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameContract
{
    public enum CardValues 
    { 
        NULL  = 0,
        SIX   = 6,
        SEVEN = 7,
        EIGHT = 8,
        NINE  = 9,
        TEN   = 10,
        JACK  = 11,
        QUEEN = 12,
        KING  = 13,
        ACE   = 14
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
