using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameContract;

namespace ChatService
{
    public interface IClient
    {
        [OperationContract(IsOneWay = true)]
        void startGame();

        [OperationContract(IsOneWay = true)]
        void startTurn(List<Card> cardsOnDeck);

        [OperationContract(IsOneWay = true)]
        void endGame();

        [OperationContract(IsOneWay = true)]
        void drawCards(List<Card> cards);
    }
}
