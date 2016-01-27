using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatService
{
    [ServiceContract(Namespace = "DurakService", CallbackContract = typeof(IChatCallback))]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void StartChatSession(string player);

        [OperationContract(IsOneWay = true)]
        void addPlyer(Player player);

        [OperationContract(IsOneWay = true)]
        void PostChatMessage(string message, string postername, string opponent);

        [OperationContract(IsOneWay = true)]
        void createNewUser(string name, string psw);

    }

    [ServiceContract(Namespace = "DurakService")]
    public interface IChatCallback
    {
        [OperationContract]
        void UpdateChatMessages(string message, string playername);
    }
}
