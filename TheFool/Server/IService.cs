using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    [ServiceContract(Namespace = "Server", SessionMode = SessionMode.Required, CallbackContract = typeof(IClient))]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void joinGame();

        [OperationContract(IsOneWay = true)]
        void play(int playerID, Card card);

        [OperationContract(IsOneWay = true)]
        void sendMessage(int playerID, string message);

        [OperationContract(IsOneWay = true)]
        void surrender(int playerID);

        [OperationContract(IsOneWay = true)]
        void clientConnected();
    }
}
