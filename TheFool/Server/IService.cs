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
        [OperationContract(IsOneWay = false)]
        int joinGame();

        [OperationContract(IsOneWay = true)]
        void play(int playerID, Card card);
    }
}
