using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheFool.server;
using System.ServiceModel;

namespace TheFool
{

    public partial class Form1 : Form, IServiceCallback
    {
        public List<PictureBox> pictureBoxList;
        private List<Card> myCards;
        private List<Card> playedCards;
        private int playerID;
        private ServiceClient server;
        private bool playerTurn;
        private int gamesWon;
        private int gamesLost;
        private bool gameStarted;
        private int tag = 0;

        public Form1()
        {
            InitializeComponent();
            this.panelGame.Visible = false;
            this.panelMain.Visible = true;
            this.pictureBoxList = new List<PictureBox>();
            server = new ServiceClient(new InstanceContext(this));
            playerTurn = false;
            gamesWon = 0;
            gamesLost = 0;
            gameStarted = false;

            //--------------Generate Cards---------------
            playedCards = new List<Card>();
            myCards = new List<Card>();
            //myCards.Add(new Card(CardValues.EIGHT, CardSuit.CLUBS));
            //myCards.Add(new Card(CardValues.NINE, CardSuit.HEARTS));
            //myCards.Add(new Card(CardValues.KING, CardSuit.CLUBS));
            //myCards.Add(new Card(CardValues.SIX, CardSuit.SPADES));
            //myCards.Add(new Card(CardValues.ACE, CardSuit.DIAMONDS));
            //myCards.Add(new Card(CardValues.QUEEN, CardSuit.CLUBS));

            ShowMyCards();
            ShowOpCArds(6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panelGame.Visible = false;
            labelMessage.Text = "You have surrendered.";
            gameStarted = false;
            chatMessages.Items.Clear();
            gamesLost++;
            server.surrender(playerID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            this.panelGame.Visible = true;
            startGame();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //this.pictureBoxList.Add(pictureBox13);
            RefreshTable();
        }

        public void RefreshTable()
        {
            if (pictureBoxList.Count == 1)
            {
                this.pictureBoxList[0].Location = new Point(320, 170);
            }
            if (pictureBoxList.Count == 2)
            {
                this.pictureBoxList[1].BringToFront();
                this.pictureBoxList[0].Location = new Point(313, 170);
                this.pictureBoxList[1].Location = new Point(327, 170);
            }
            if (pictureBoxList.Count == 3)
            {
                this.pictureBoxList[1].BringToFront();
                this.pictureBoxList[2].BringToFront();
                this.pictureBoxList[0].Location = new Point(306, 170);
                this.pictureBoxList[1].Location = new Point(320, 170);
                this.pictureBoxList[2].Location = new Point(334, 170);
            }
            if (pictureBoxList.Count == 4)
            {
                this.pictureBoxList[1].BringToFront();
                this.pictureBoxList[2].BringToFront();
                this.pictureBoxList[3].BringToFront();
                this.pictureBoxList[0].Location = new Point(299, 170);
                this.pictureBoxList[1].Location = new Point(313, 170);
                this.pictureBoxList[2].Location = new Point(327, 170);
                this.pictureBoxList[3].Location = new Point(341, 170);
            }
            if (pictureBoxList.Count == 5)
            {
                this.pictureBoxList[1].BringToFront();
                this.pictureBoxList[2].BringToFront();
                this.pictureBoxList[3].BringToFront();
                this.pictureBoxList[4].BringToFront();
                this.pictureBoxList[0].Location = new Point(292, 170);
                this.pictureBoxList[1].Location = new Point(306, 170);
                this.pictureBoxList[2].Location = new Point(320, 170);
                this.pictureBoxList[3].Location = new Point(336, 170);
                this.pictureBoxList[4].Location = new Point(350, 170);
            }
            if (pictureBoxList.Count == 6)
            {
                this.pictureBoxList[1].BringToFront();
                this.pictureBoxList[2].BringToFront();
                this.pictureBoxList[3].BringToFront();
                this.pictureBoxList[4].BringToFront();
                this.pictureBoxList[5].BringToFront();
                this.pictureBoxList[0].Location = new Point(285, 170);
                this.pictureBoxList[1].Location = new Point(299, 170);
                this.pictureBoxList[2].Location = new Point(313, 170);
                this.pictureBoxList[3].Location = new Point(327, 170);
                this.pictureBoxList[4].Location = new Point(341, 170);
                this.pictureBoxList[5].Location = new Point(355, 170);
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //this.pictureBoxList.Add(pictureBox12);
            RefreshTable();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //this.pictureBoxList.Add(pictureBox11);
            RefreshTable();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //this.pictureBoxList.Add(pictureBox10);
            RefreshTable();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //this.pictureBoxList.Add(pictureBox4);
            RefreshTable();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.pictureBoxList.Add(pictureBox2);
            RefreshTable();
        }

        private void ShowOpCArds(int count)
        {
            int x = 150,
                y = 50;
            for (int i = 0; i < count; i++)
            {
                PictureBox box = new PictureBox();
                // Match card with the picture
                box.Image = TheFool.Properties.Resources.back;
                // set the location
                box.Location = new Point(x, y);
                box.Width = 50;
                box.Height = 70;
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.Visible = true;
                // Post picture
                this.panelGame.Controls.Add(box);
                // Adjust the location for the next one
                x += 55;
            }
        }

        private void ShowPlayedCards()
        {
            int x = 150,
                y = 170;
            bool attack = true;
            foreach (Card c in playedCards)
            {
                PictureBox box = new PictureBox();
                
                // Match card with the picture
                box.Image = MapCard(c.suit, c.value);
                // set the location
                box.Location = new Point(x, y);
                box.Width = 50;
                box.Height = 70;
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.Visible = true;
                // Adjust the location for the next one
                if (attack)
                {
                    x += 10;
                    y += 10;
                }
                else
                {
                    x += 55;
                    y -= 10;
                    box.Name = "def";
                }
                // Post picture
                this.panelGame.Controls.Add(box);
                attack = !attack;
            }
        }

        private void ShowMyCards()
        {
            int x = 150,
                y = 286;
            int count = 0;
            foreach (Card c in myCards)
            {
                PictureBox box = new PictureBox();
                // Match card with the picture
                box.Image = MapCard(c.suit, c.value);
                box.Tag = myCards.IndexOf(c);
                
                // set the location
                box.Location = new Point(x, y);
                box.Width = 50;
                box.Height = 70;
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.Visible = true;
                box.Click += box_Click;
                box.Name = count.ToString();    // This will let you know which card was pressed
                // Post picture
                this.panelGame.Controls.Add(box);
                // Adjust the location for the next one
                x += 55;

            }
            
        }

        /// <summary>
        /// Called whenever generated picture box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void box_Click(object sender, EventArgs e)
        {
            if (playerTurn)
            {
                int index = int.Parse(((PictureBox)sender).Tag.ToString());
                //int index = Convert.ToInt32(((PictureBox)sender).Name);
                var playedCard = myCards[index];
                server.play(playerID, playedCard);
                playedCards.Add(playedCard);
                myCards.Remove(playedCard);
                playerTurn = false;
                labelMessage.Text = "Waiting for Opponent";
                Reload();
            }
            else
            {
                labelMessage.Text = "Hold your horses! Waiting for Opponent";
            }
            
        }

        private void Reload()
        {
            for (int ix = this.panelGame.Controls.Count - 1; ix >= 0; ix--)
                if (this.panelGame.Controls[ix] is PictureBox) 
                    this.panelGame.Controls[ix].Dispose();
            ShowMyCards();
            ShowPlayedCards();
            ShowOpCArds(6);
            // bring "defence" cards to front
            for (int ix = this.panelGame.Controls.Count - 1; ix >= 0; ix--)
                if (this.panelGame.Controls[ix] is PictureBox)
                    if (((PictureBox)this.panelGame.Controls[ix]).Name == "def")
                        this.panelGame.Controls[ix].BringToFront();
        }

        private Image MapCard(CardSuit suit, CardValues value)
        {
            if (suit == CardSuit.CLUBS)
            {
                if (value == CardValues.SIX)
                    return TheFool.Properties.Resources._6_of_clubs;
                if (value == CardValues.SEVEN)
                    return TheFool.Properties.Resources._7_of_clubs;
                if (value == CardValues.EIGHT)
                    return TheFool.Properties.Resources._8_of_clubs;
                if (value == CardValues.NINE)
                    return TheFool.Properties.Resources._9_of_clubs;
                if (value == CardValues.TEN)
                    return TheFool.Properties.Resources._10_of_clubs;
                if (value == CardValues.JACK)
                    return TheFool.Properties.Resources.jack_of_clubs2;
                if (value == CardValues.QUEEN)
                    return TheFool.Properties.Resources.queen_of_clubs2;
                if (value == CardValues.KING)
                    return TheFool.Properties.Resources.king_of_clubs2;
                if (value == CardValues.ACE)
                    return TheFool.Properties.Resources.ace_of_clubs;
                // Default
                return TheFool.Properties.Resources.back;
            }
            else if (suit == CardSuit.DIAMONDS)
            {
                if (value == CardValues.SIX)
                    return TheFool.Properties.Resources._6_of_diamonds;
                if (value == CardValues.SEVEN)
                    return TheFool.Properties.Resources._7_of_diamonds;
                if (value == CardValues.EIGHT)
                    return TheFool.Properties.Resources._8_of_diamonds;
                if (value == CardValues.NINE)
                    return TheFool.Properties.Resources._9_of_diamonds;
                if (value == CardValues.TEN)
                    return TheFool.Properties.Resources._10_of_diamonds;
                if (value == CardValues.JACK)
                    return TheFool.Properties.Resources.jack_of_diamonds2;
                if (value == CardValues.QUEEN)
                    return TheFool.Properties.Resources.queen_of_diamonds2;
                if (value == CardValues.KING)
                    return TheFool.Properties.Resources.king_of_diamonds2;
                if (value == CardValues.ACE)
                    return TheFool.Properties.Resources.ace_of_diamonds;
                // Default
                return TheFool.Properties.Resources.back;
            }
            else if (suit == CardSuit.HEARTS)
            {
                if (value == CardValues.SIX)
                    return TheFool.Properties.Resources._6_of_hearts;
                if (value == CardValues.SEVEN)
                    return TheFool.Properties.Resources._7_of_hearts;
                if (value == CardValues.EIGHT)
                    return TheFool.Properties.Resources._8_of_hearts;
                if (value == CardValues.NINE)
                    return TheFool.Properties.Resources._9_of_hearts;
                if (value == CardValues.TEN)
                    return TheFool.Properties.Resources._10_of_hearts;
                if (value == CardValues.JACK)
                    return TheFool.Properties.Resources.jack_of_hearts2;
                if (value == CardValues.QUEEN)
                    return TheFool.Properties.Resources.queen_of_hearts2;
                if (value == CardValues.KING)
                    return TheFool.Properties.Resources.king_of_hearts2;
                if (value == CardValues.ACE)
                    return TheFool.Properties.Resources.ace_of_hearts;
                // Default
                return TheFool.Properties.Resources.back;
            }
            else if (suit == CardSuit.SPADES)
            {
                if (value == CardValues.SIX)
                    return TheFool.Properties.Resources._6_of_spades;
                if (value == CardValues.SEVEN)
                    return TheFool.Properties.Resources._7_of_spades;
                if (value == CardValues.EIGHT)
                    return TheFool.Properties.Resources._8_of_spades;
                if (value == CardValues.NINE)
                    return TheFool.Properties.Resources._9_of_spades;
                if (value == CardValues.TEN)
                    return TheFool.Properties.Resources._10_of_spades;
                if (value == CardValues.JACK)
                    return TheFool.Properties.Resources.jack_of_spades2;
                if (value == CardValues.QUEEN)
                    return TheFool.Properties.Resources.queen_of_spades2;
                if (value == CardValues.KING)
                    return TheFool.Properties.Resources.king_of_spades2;
                if (value == CardValues.ACE)
                    return TheFool.Properties.Resources.ace_of_spades2;
                // Default
                return TheFool.Properties.Resources.back;
            }
            else
                return TheFool.Properties.Resources.back;
        }

        public void startGame()
        {
            server.joinGame();
        }

        public void gameJoined(int playerID)
        {
            this.playerID = playerID;
            playerName.Text = "Player " + (playerID + 1);
            if (playerID == 0)
            {
                labelMessage.Text = "Waiting for another player to join";
            }
            else
            {
                labelMessage.Text = "Waiting for opponent";
                gameStarted = true;
            }
            server.clientConnected();
        }

        public void startTurn(server.Card[] tableCards, server.Card[] playerCards)
        {
            gameStarted = true;
            playerTurn = true;
            labelMessage.Text = "It's your turn!";
            playedCards = tableCards.OfType<Card>().ToList();
            myCards = playerCards.OfType<Card>().ToList();
            Reload();
        }

        public void endGame()
        {
            labelMessage.Text = "Your opponent has surrendered";
            this.panelGame.Visible = false;
            chatMessages.Items.Clear();
            gamesWon++;
        }

        public void drawCards(server.Card[] playerCards)
        {
            myCards = playerCards.OfType<Card>().ToList();
            Reload();
        }

        public void victory()
        {
            labelMessage.Text = "You have won!";
            this.panelGame.Visible = false;
            gameStarted = false;
            chatMessages.Items.Clear();
            gamesWon++;
        }

        public void loss()
        {
            labelMessage.Text = "You have lost...";
            this.panelGame.Visible = false;
            chatMessages.Items.Clear();
            gameStarted = false;
            gamesLost++;
        }

        public void receiveMessage(int playerID, string message)
        {
            chatMessages.Items.Add("Opponent: " + message);
        }

        private void buttonChatSend_Click(object sender, EventArgs e)
        {
            if (chatInput.Text != "" && gameStarted)
            {
                server.sendMessage(playerID, chatInput.Text);
                chatMessages.Items.Add("You: " + chatInput.Text);
                chatInput.Text = "";
            }
            else if (chatInput.Text == "" && gameStarted)
            {
                MessageBox.Show("You need to type a message!");
            }
            else
            {
                MessageBox.Show("Waiting for another player to join");
            }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "Games Played: " + (gamesWon + gamesLost) + ". Games Won: " + gamesWon + ". Games Lost: " + gamesLost;
        }
    }
}
