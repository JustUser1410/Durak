using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GameContract;

namespace ChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GameService : IChat, IGame
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

        //------------------------------------------------------Game Service Starts Here--------------------------------------

        private Dealer aDealer;

        public bool Attack(int playerID, Card c)
        {
            // Put the card on the table
            bool output = aDealer.PlayCard(c);
            if (output)
                Console.WriteLine("Attack successful!");
            else
                Console.WriteLine("Card is not allowed!");
            return output;
        }

        public void EndAttack(int playerID)
        {
            Console.WriteLine("Player {0} ended attack.", playerID);
            aDealer.EndAttack();
        }

        public bool Defend(int playerID, Card c)
        {
            bool output = aDealer.PlayCard(c);
            if (output)
                Console.WriteLine("Defence successful!");
            else
                Console.WriteLine("Card is not allowed!");
            return output;
        }

        public List<Card> TakeCards(int playerID)
        {
            Console.WriteLine("Player {0} was unable to defend", playerID);
            // Get cards off the table and
            // return them to the player
            return aDealer.GetCardsOnTable();
        }

        public void Surrender(int playerID)
        {
            // Notify opponenet that player surrendered
            aDealer.Surrender(playerID);
            // Get rid of the dealer
            aDealer = null;
            Console.WriteLine("Player {0} surrenders. Game is over.", playerID);
        }

        public void PlayRandom(int playerID)
        {
            if (aDealer == null)
            {
                aDealer = new Dealer();
                aDealer.Connect(playerID);
                Console.WriteLine("First player joined! {0}", playerID);
            }
            else
            {
                aDealer.Connect(playerID);
                Console.WriteLine("Second player joined! {0}", playerID);
            }
        }

        public void HostGame(int token, int playerID)
        {
            // create the token
            // wait for somebody to join
        }

        public Errors JoinGame(int token, int playerID)
        {
            // Check if the token is valid
            // Start game
            return Errors.NONE;
        }

        public void OutOfCards(int playerID)
        {
            // Check if game ends
            if (aDealer.GameEnds(playerID))
            {
                // Discard of the dealer
                aDealer = null;
                Console.WriteLine("Player {0} won!", playerID);
            }
            else
            {
                aDealer.EndAttack();
                Console.WriteLine("Player {0} is out of cards.", playerID);
            }
        }

    }
}



