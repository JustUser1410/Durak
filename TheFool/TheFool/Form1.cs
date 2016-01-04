using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheFool
{
    public partial class Form1 : Form
    {
        public List<PictureBox> pictureBoxList;
        public Form1()
        {
            InitializeComponent();
            this.panelGame.Visible = false;
            this.panelMain.Visible = true;
            this.pictureBoxList = new List<PictureBox>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panelGame.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            this.panelGame.Visible = true;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.pictureBoxList.Add(pictureBox13);
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
            this.pictureBoxList.Add(pictureBox12);
            RefreshTable();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.pictureBoxList.Add(pictureBox11);
            RefreshTable();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.pictureBoxList.Add(pictureBox10);
            RefreshTable();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.pictureBoxList.Add(pictureBox4);
            RefreshTable();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.pictureBoxList.Add(pictureBox2);
            RefreshTable();
        }
    }
}
