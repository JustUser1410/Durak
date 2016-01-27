using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameContract;

namespace ChatService
{
    public interface IServer
    {
        [OperationContract(IsOneWay = false)]
        int joinGame();

        [OperationContract(IsOneWay = true)]
        void play(int playerID, Card card);
    }
}
