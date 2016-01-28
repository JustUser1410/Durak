using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    public interface IClient
    {
        [OperationContract(IsOneWay = true)]
        void startGame();

        [OperationContract(IsOneWay = true)]
        void startTurn(List<Card> tableCards, List<Card> playerCards);

        [OperationContract(IsOneWay = true)]
        void endGame();

        [OperationContract(IsOneWay = true)]
        void drawCards(List<Card> playerCards);

        [OperationContract(IsOneWay = true)]
        void victory();

        [OperationContract(IsOneWay = true)]
        void loss();

        [OperationContract(IsOneWay = true)]
        void receiveMessage(int playerID, string message);

        [OperationContract(IsOneWay = true)]
        void gameJoined(int playerID);
    }
}
