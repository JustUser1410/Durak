using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameContract;
using ChatService;

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

        public bool Attack(int playerID, Card c)
        {
            return base.Channel.Attack(playerID, c);
        }

        public bool Defend(int playerID, Card c)
        {
            return base.Channel.Defend(playerID, c);
        }

        public void Surrender(int playerID)
        {
            base.Channel.Surrender(playerID);
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

        public void EndAttack(int playerID)
        {
            base.Channel.EndAttack(playerID);
        }

        public List<Card> TakeCards(int playerID)
        {
            return base.Channel.TakeCards(playerID);
        }

        void OutOfCards(int playerID)
        {
            base.Channel.OutOfCards(playerID);
        }
    }
}
