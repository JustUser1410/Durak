using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFool;
using System.ServiceModel;
//There is no need to copy Card class and enumerations since I added reference

namespace GameService
{
    class Dealer
    {
        private List<Card> Deck;
        private List<Card> cardsOnTable;
        private Proxy prx;

        public Dealer()
        {
            WSHttpBinding binding = new WSHttpBinding();
            Uri address = new Uri("http://localhost:8000/clientservice");
            EndpointAddress endpointAddress = new EndpointAddress(address);
            prx = new Proxy(binding, endpointAddress);

            this.Deck = new List<Card>();
            this.cardsOnTable = new List<Card>();

            // Fill the deck with cards
            GenerateCards();
            // Shuffle the deck
            ShuffleDeck();
        }

        private void GenerateCards()
        {
            // For 4 suits
            CardSuit s = CardSuit.HEARTS;
            do
            {
                // Generate cards for each suit
                CardValues v = CardValues.SIX;
                do
                {
                    this.Deck.Add(new Card(v, s));
                    //Go to next card
                    v++;
                } while (v <= CardValues.ACE);
                //Go to next suit
                s++;
            } while (s <= CardSuit.SPADES);
        }

        private void ShuffleDeck()
        {
            
        }

        private void DealCards()
        { }

        private void DecideFirstPlayer()
        { }

        private void GameEnds()
        { }

    }
}
