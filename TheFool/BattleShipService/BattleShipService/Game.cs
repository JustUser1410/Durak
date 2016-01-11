using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace BattleShipService
{
    [DataContract]
    public class Game
    {
        private int gameid;
        private Player player1;
        private Player player2;
        private Player playertoplay;

        public Game(int gameid, Player player1, Player player2)
        {
            this.gameid = gameid;
            this.player1 = player1;
            this.player2 = player2;

            //Making a player start random.
            int playerstart = new Random().Next(1, 3);
            if (playerstart == 1)
            {
                this.playertoplay = this.player1;
            }
            else
            {
                this.playertoplay = this.player2;
            }
        }

        [DataMember]
        public Player PlayerToPlay { get { return this.playertoplay; } private set { this.playertoplay = value; } }

        [DataMember]
        public Player Player1 { get { return this.player1; } private set { this.player1 = value; } }

        [DataMember]
        public Player Player2 { get { return this.player2; } private set { this.player2 = value; } }

        [DataMember]
        public int GameID { get { return this.gameid; } private set { this.gameid = value; } }
    }
}
