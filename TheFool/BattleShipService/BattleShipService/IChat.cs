using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BattleShipService
{

    [ServiceContract(Namespace = "BattleShipService", CallbackContract = typeof(IChatCallback))]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void StartChatSession(string player);

        [OperationContract(IsOneWay = true)]
        void PostChatMessage(string message, string postername, string opponent);

    }

    [ServiceContract(Namespace = "BattleShipService")]
    public interface IChatCallback
    {
        [OperationContract]
        void UpdateChatMessages(string message, string playername);
    }
}
