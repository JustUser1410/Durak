using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BattleShipService
{
    [ServiceContract(Namespace = "BattleShipService", CallbackContract = typeof(IPortalCallback))]

    public interface IPortal
    {
        [OperationContract]
        bool Login(string name, string passwd);

        [OperationContract]
        List<Player> GetOnlinePlayer();

        [OperationContract(IsOneWay = true)]
        void InvitePlayer(string p1, string p2);

        [OperationContract(IsOneWay = true)]
        void AcceptInvitation(string p1, string p2);

        [OperationContract]
        Player GetPlayer(string playerusername);

        [OperationContract(IsOneWay = true)]
        void Update();
    }


    [ServiceContract(Namespace = "BattleShipService")]
    public interface IPortalCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyChallenge(string Name);

        [OperationContract]
        void NotifyResponce(Game game);

        [OperationContract(IsOneWay = true)]
        void PlayerLoggedIn(List<Player> playerlists);
    }
}
