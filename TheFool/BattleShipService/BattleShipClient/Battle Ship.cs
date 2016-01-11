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
    public partial class Battle_Ship : Form, ServiceReference1.IChatCallback
    {
        string Playername;
        string Opponent;
        ServiceReference1.ChatClient proxy2;

        private int type;
        private List<Cell> cellList = new List<Cell>();
        Point a1 = new Point(0, 0);
        Graphics grapgics;
        int drawRow = 0;
        int drawCol = 0;
        public Battle_Ship(Game game, string username, string opponent)
        {
            InitializeComponent();
            this.type = 0;

            proxy2 = new ServiceReference1.ChatClient(new InstanceContext(this));

            this.lbName.Text = username + " !";
            this.Playername = username;
            this.Opponent = opponent;
            proxy2.StartChatSession(Playername);
        }

        private void createCell()
        {
            for (int i = 0; i < 10; i++)
            {
                a1.X = 0;
                for (int j = 0; j < 9; j++)
                {
                    Cell temp = new Cell(a1, this.imageList1.Images[0]);
                    a1.X += 35;
                    this.cellList.Add(temp);
                }
                a1.Y += 35;
            }
        }

        private void PaintCell(Cell a, Graphics gr)
        {
            Rectangle destrec = new Rectangle(a.P.X, a.P.Y, 70, 35);
            gr.DrawImage(a.Image, destrec);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            grapgics = e.Graphics;
            Rectangle rect = this.Bounds;
            int col = rect.Width;
            int row = rect.Height;
            this.drawCol = 0;
            this.drawRow = 0;
            int x = 35;

            Pen p = new Pen(Brushes.Green);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            for (int i = 0; i <= row; i++)
            {
                e.Graphics.DrawLine(p, 5, drawCol, rect.Width, drawCol);
                drawCol += x;
            }
            for (int j = 0; j <= col; j++)
            {
                e.Graphics.DrawLine(p, drawRow, 5, drawRow, rect.Height);
                drawRow += x;
            }

            this.createCell();
            foreach (Cell item in cellList)
            {
                this.PaintCell(item, grapgics);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = this.Bounds;
            int col = rect.Width;
            int row = rect.Height;
            this.drawCol = 0;
            this.drawRow = 0;
            int x = 35;

            Pen p = new Pen(Brushes.Green);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            for (int i = 0; i <= row; i++)
            {
                e.Graphics.DrawLine(p, 5, drawCol, rect.Width, drawCol);
                drawCol += x;
            }
            for (int j = 0; j <= col; j++)
            {
                e.Graphics.DrawLine(p, drawRow, 5, drawRow, rect.Height);
                drawRow += x;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.type = 1;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Point a = new Point(-1, -1);

            foreach (Cell item in cellList)
            {
                if (e.X > item.P.X && e.X <= item.P.X + 35 && e.Y > item.P.Y && e.Y <= item.P.Y + 35)
                {
                    for (int i = 0; i < cellList.Count; i++)
                    {
                        if (cellList[i].getCell() == item)
                        {
                            cellList[i].Image = this.imageList1.Images[1];
                        }

                    }
                }
            }
            this.panel2.Refresh();
        }


        public void UpdateChatMessages(string message, string playername)
        {
            this.lb_DisplayMessages.ScrollAlwaysVisible = true;
            this.lb_DisplayMessages.Items.Add(playername + ": " + message);
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (this.tbWriteChat.Text != "")
            {
                string msg = this.tbWriteChat.Text;
                this.tbWriteChat.Text = string.Empty;
                proxy2.PostChatMessage(msg, Playername, Opponent);
                this.lb_DisplayMessages.Items.Add(Playername + " : " + msg);
            }
            else
            {
                MessageBox.Show("You have to type the message first.");
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
