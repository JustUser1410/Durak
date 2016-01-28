namespace TheFool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnStats = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.panelGame = new System.Windows.Forms.Panel();
            this.chatInput = new System.Windows.Forms.TextBox();
            this.chatMessages = new System.Windows.Forms.ListBox();
            this.playerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.buttonChatSend = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnStats);
            this.panelMain.Controls.Add(this.button2);
            this.panelMain.Controls.Add(this.btnPlay);
            this.panelMain.Location = new System.Drawing.Point(0, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(685, 425);
            this.panelMain.TabIndex = 10;
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(227, 104);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(168, 53);
            this.btnStats.TabIndex = 14;
            this.btnStats.Text = "Statistics";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 53);
            this.button2.TabIndex = 12;
            this.button2.Text = "Exit Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(32, 104);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(168, 53);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "Play Game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click_1);
            // 
            // panelGame
            // 
            this.panelGame.Controls.Add(this.buttonChatSend);
            this.panelGame.Controls.Add(this.chatInput);
            this.panelGame.Controls.Add(this.chatMessages);
            this.panelGame.Controls.Add(this.playerName);
            this.panelGame.Controls.Add(this.label2);
            this.panelGame.Controls.Add(this.pictureBox3);
            this.panelGame.Controls.Add(this.button4);
            this.panelGame.Controls.Add(this.pictureBox14);
            this.panelGame.Location = new System.Drawing.Point(3, 35);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(942, 430);
            this.panelGame.TabIndex = 11;
            // 
            // chatInput
            // 
            this.chatInput.AcceptsReturn = true;
            this.chatInput.Location = new System.Drawing.Point(688, 398);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(159, 20);
            this.chatInput.TabIndex = 20;
            // 
            // chatMessages
            // 
            this.chatMessages.FormattingEnabled = true;
            this.chatMessages.Location = new System.Drawing.Point(688, 13);
            this.chatMessages.Name = "chatMessages";
            this.chatMessages.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chatMessages.Size = new System.Drawing.Size(242, 381);
            this.chatMessages.TabIndex = 19;
            // 
            // playerName
            // 
            this.playerName.AutoSize = true;
            this.playerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.playerName.ForeColor = System.Drawing.Color.White;
            this.playerName.Location = new System.Drawing.Point(299, 373);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(62, 24);
            this.playerName.TabIndex = 18;
            this.playerName.Text = "Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(299, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Opponent";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(509, 168);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 70);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Brown;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(545, 360);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 44);
            this.button4.TabIndex = 0;
            this.button4.Text = "Surrender";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(470, 179);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(70, 50);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 16;
            this.pictureBox14.TabStop = false;
            // 
            // buttonChatSend
            // 
            this.buttonChatSend.Location = new System.Drawing.Point(853, 396);
            this.buttonChatSend.Name = "buttonChatSend";
            this.buttonChatSend.Size = new System.Drawing.Size(75, 23);
            this.buttonChatSend.TabIndex = 21;
            this.buttonChatSend.Text = "Send";
            this.buttonChatSend.UseVisualStyleBackColor = true;
            this.buttonChatSend.Click += new System.EventHandler(this.buttonChatSend_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelMessage.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelMessage.Location = new System.Drawing.Point(12, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(957, 465);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "The Fool";
            this.panelMain.ResumeLayout(false);
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label playerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.TextBox chatInput;
        private System.Windows.Forms.ListBox chatMessages;
        private System.Windows.Forms.Button buttonChatSend;
        private System.Windows.Forms.Label labelMessage;
    }
}

