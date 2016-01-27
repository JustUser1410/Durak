using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GameService : IChat
    {
        static Action<List<Player>> PlayerLogIn_Event = delegate { };
        static Action<String> Invitation_Send_Event = delegate { };
        static Action<Game> Game_Start_Event = delegate { };


        public List<Player> onlinePlayers = new List<Player>();
        public List<Player> registeredPlayers;
        Player Leo = new Player("Leo","123");
        Player Leo2 = new Player("Leo2","123");


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


        public void PostChatMessage(string message, string postername, string opponent)
        {
            Player p = GetPlayer(opponent);
            p.IchatCallBack.UpdateChatMessages(message, postername);

        }

        public void StartChatSession(string player)
        {
            onlinePlayers.Add(Leo);
            onlinePlayers.Add(Leo2);
            Start(player);
        }
        public void addPlyer(Player player)
        {
            onlinePlayers.Add(player);
        }

        public void createNewUser(string name,string psw)
        { 
            Player playerP = new Player(name, psw);
            addPlyer(playerP);
        }

        public void Start(string player)
        {
            Player p1 = GetPlayer(player);
            p1.IchatCallBack = OperationContext.Current.GetCallbackChannel<IChatCallback>();
        }

    }
}



