using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameContract;

namespace TheFool
{
    class GameClient : ClientBase<IGame>
    {
        public GameClient()
        { }

        public GameClient(string endpointConfiguration)
            : base(endpointConfiguration)
        { }
        public GameClient(string endpointConfiguration, EndpointAddress remoteAddress)
            : base(endpointConfiguration,remoteAddress)
        { }
        public GameClient(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress)
            : base(binding,remoteAddress)
        { }

        public bool Attack(Card c)
        {
            return base.Channel.Attack(c);
        }

        public bool Defend(Card c)
        {
            return base.Channel.Defend(c);
        }

        public void Surrender()
        {
            base.Channel.Surrender();
        }

        public void PlayRandom(int playerID)
        {
            base.Channel.PlayRandom(playerID);
        }

        public void HostGame(int token, int playerID)
        {
            base.Channel.HostGame(token, playerID);
        }

        public Errors JoinGame(int token, int playerID)
        {
            return base.Channel.JoinGame(token, playerID);
        }

    }
}
