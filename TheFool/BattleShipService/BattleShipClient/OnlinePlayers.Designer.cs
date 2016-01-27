namespace BattleShipClient
{
    partial class OnlinePlayers
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
            this.btnInvite = new System.Windows.Forms.Button();
            this.lbOnlinePlayers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnInvite
            // 
            this.btnInvite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvite.Location = new System.Drawing.Point(21, 12);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(59, 21);
            this.btnInvite.TabIndex = 19;
            this.btnInvite.Text = "Invite";
            this.btnInvite.UseVisualStyleBackColor = true;
            // 
            // lbOnlinePlayers
            // 
            this.lbOnlinePlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOnlinePlayers.FormattingEnabled = true;
            this.lbOnlinePlayers.ItemHeight = 16;
            this.lbOnlinePlayers.Location = new System.Drawing.Point(21, 44);
            this.lbOnlinePlayers.Name = "lbOnlinePlayers";
            this.lbOnlinePlayers.Size = new System.Drawing.Size(221, 196);
            this.lbOnlinePlayers.TabIndex = 18;
            // 
            // OnlinePlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 261);
            this.Controls.Add(this.btnInvite);
            this.Controls.Add(this.lbOnlinePlayers);
            this.Name = "OnlinePlayers";
            this.Text = "OnlinePlayers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.ListBox lbOnlinePlayers;
    }
}