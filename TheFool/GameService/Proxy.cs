using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameContract;
using TheFool;

namespace GameService
{
    class Proxy : ClientBase<IGameCallback>
    {
        public Proxy()
        { }

        public Proxy(string endpointConfiguration)
            : base(endpointConfiguration)
        { }
        public Proxy(string endpointConfiguration, EndpointAddress remoteAddress)
            : base(endpointConfiguration,remoteAddress)
        { }
        public Proxy(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress)
            : base(binding,remoteAddress)
        { }

        public void PlayerTurn(int playerID)
        {
            base.Channel.PlayerTurn(playerID);
        }

        public void CardsOnTable(List<Card> c)
        {
            base.Channel.CardsOnTable(c);
        }

        public void DrawCards(List<Card> c)
        {
            base.Channel.DrawCards(c);
        }

        public void ReceivedMessage(String message)
        {
            base.Channel.ReceivedMessage(message);
        }

        public void PlayerReady(int playerID)
        {
            base.Channel.PlayerReady(playerID);
        }

        public void GameOver(int yourPosition)
        {
            base.Channel.GameOver(yourPosition);
        }

    }
}
