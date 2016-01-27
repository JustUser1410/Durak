using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using BattleShipService;

namespace BattleShipClient
{
    public partial class IPortal : Form, ServiceReference1.IPortalCallback
    {
        ServiceReference1.PortalClient proxy;
        public List<BattleShipService.Player> onlinePlayers;
        public string opponent;

        public string myUsername;

        public IPortal()
        {
            InitializeComponent();
            proxy = new ServiceReference1.PortalClient(new InstanceContext(this));

            onlinePlayers = new List<BattleShipService.Player>();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string name = this.tbName.Text;
            myUsername = name;
            string passwd = this.tbPasswd.Text;
            if (name == "")
            {
                MessageBox.Show("Please input your username!");
                this.tbName.Focus();
            }
            else if (passwd == "")
            {
                MessageBox.Show("Please input the password!");
                this.tbPasswd.Focus();
            }
            else
            {
                bool result = proxy.Login(name, passwd);
                if (result)
                {
                    this.lbName.Text = name + " !";
                    MessageBox.Show("You are successfully logged in.");
                    proxy.Update();
                    //this.lbOnlinePlayers.Items.Add(name);
                }
                else
                {
                    MessageBox.Show("Login Failed, check your input again");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            if (this.lbOnlinePlayers.SelectedItem != null)
            {
                if (this.lbOnlinePlayers.SelectedItem.ToString() != myUsername)
                {
                    string opponentPlayer = this.lbOnlinePlayers.SelectedItem.ToString();
                    this.opponent = opponentPlayer;
                    proxy.InvitePlayer(opponentPlayer, myUsername);
                }
                else
                {
                    MessageBox.Show("You cannot invite yourself!");
                }
            }
            else
            {
                MessageBox.Show("You have to select your opponent Player.");
            }
        }

        public void NotifyChallenge(string Name)
        {
            DialogResult inviteAccept = MessageBox.Show(Name + " invited you to play a game.\nDo you want to play?",
            "Accept/Decline",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            // MessageBox.Show(Name);
            string opponent = Name;

            //Player accept to play.
            if (inviteAccept == DialogResult.Yes)
            {
                this.opponent = opponent;
                proxy.AcceptInvitation(myUsername, opponent);
            }
        }

        void Battle_Ship_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        
        public void NotifyResponce(BattleShipService.Game game)
        {
            Battle_Ship main = new Battle_Ship(game, myUsername, opponent);
            main.FormClosed += Battle_Ship_FormClosed;
            main.Show();
            this.Hide();
        }

        public void PlayerLoggedIn(List<BattleShipService.Player> playerlists)
        {
            this.lbOnlinePlayers.Items.Clear();
            onlinePlayers = playerlists;
            foreach (BattleShipService.Player players in playerlists)
            {
                lbOnlinePlayers.Items.Add(players.name);
            }
        }
    }
}
