using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BattleShipService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GameService : IPortal, IChat
    {
        static Action<List<Player>> PlayerLogIn_Event = delegate { };
        static Action<String> Invitation_Send_Event = delegate { };
        static Action<Game> Game_Start_Event = delegate { };


        public List<Player> onlinePlayers;
        public List<Player> registeredPlayers;
        List<Game> gamesLists;

        public GameService()
        {
            onlinePlayers = new List<Player>();
            registeredPlayers = new List<Player>();
            gamesLists = new List<Game>();


            registeredPlayers.Add(new Player("tool", "bar"));
            registeredPlayers.Add(new Player("bar", "tool"));
            registeredPlayers.Add(new Player("aa", "bb"));
        }

        public bool Login(string name, string passwd)
        {
            foreach (Player p in registeredPlayers)
            {
                if (p.name == name && p.passwd == passwd)
                {
                    p.IPortal_Callback = OperationContext.Current.GetCallbackChannel<IPortalCallback>();
                    onlinePlayers.Add(p);
                    PlayerLogIn_Event += p.IPortal_Callback.PlayerLoggedIn;
                    //Subscribing to events.

                    return true;
                }
            }
            return false;
        }

        public List<Player> GetOnlinePlayer()
        {
            return onlinePlayers;
        }


        public void InvitePlayer(string p1, string p2)
        {
            Player playerinvitee = GetPlayer(p1);
            // playerinvitee.IPortal_Callback.NotifyChallenge(p2);
            Invitation_Send_Event += playerinvitee.IPortal_Callback.NotifyChallenge;
            Invitation_Send_Event(p2);
        }

        public void AcceptInvitation(string p1, string p2)
        {
            Player player1 = GetPlayer(p1);
            Player player2 = GetPlayer(p2);
            Game game = new Game(1, player1, player2);

            Game_Start_Event += player1.IPortal_Callback.NotifyResponce;
            Game_Start_Event += player2.IPortal_Callback.NotifyResponce;
            Game_Start_Event(game);

        }

        public Player GetPlayer(string playerusername)
        {
            foreach (Player players in this.onlinePlayers)
            {
                if (players.name == playerusername)
                {
                    return players;
                }
            }
            return null;
        }

        public void Update()
        {
            PlayerLogIn_Event(onlinePlayers);
        }


        public void PostChatMessage(string message, string postername, string opponent)
        {
            Player p = GetPlayer(opponent);
            p.IchatCallBack.UpdateChatMessages(message, postername);

        }

        public void StartChatSession(string player)
        {
            Start(player);
        }
        public void Start(string player)
        {
            Player p1 = GetPlayer(player);
            p1.IchatCallBack = OperationContext.Current.GetCallbackChannel<IChatCallback>();
        }
    }
}



