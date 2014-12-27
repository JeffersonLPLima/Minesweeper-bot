namespace Minesweeper
{
    partial class MinesweeperForm
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
            System.Windows.Forms.Panel detailspanel;
          
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Player2NameLabel = new System.Windows.Forms.Label();
            this.Player1NameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RemaingBombs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMatriz = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fácilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.médioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.difícilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            detailspanel = new System.Windows.Forms.Panel();
            detailspanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailspanel
            // 
            detailspanel.AccessibleName = "details";
            detailspanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            detailspanel.AutoSize = true;
            detailspanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            detailspanel.Controls.Add(this.label7);
            detailspanel.Controls.Add(this.label6);
            detailspanel.Controls.Add(this.Player2NameLabel);
            detailspanel.Controls.Add(this.Player1NameLabel);
            detailspanel.Controls.Add(this.label3);
            detailspanel.Controls.Add(this.RemaingBombs);
            detailspanel.Controls.Add(this.label2);
            detailspanel.Controls.Add(this.Time);
            detailspanel.Controls.Add(this.label1);
            detailspanel.Location = new System.Drawing.Point(12, 55);
            detailspanel.Name = "detailspanel";
            detailspanel.Size = new System.Drawing.Size(415, 102);
            detailspanel.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "PontosB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "PontosP";
            // 
            // Player2NameLabel
            // 
            this.Player2NameLabel.AutoSize = true;
            this.Player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2NameLabel.Location = new System.Drawing.Point(145, 63);
            this.Player2NameLabel.Name = "Player2NameLabel";
            this.Player2NameLabel.Size = new System.Drawing.Size(40, 17);
            this.Player2NameLabel.TabIndex = 6;
            this.Player2NameLabel.Text = "BOT";
            // 
            // Player1NameLabel
            // 
            this.Player1NameLabel.AutoSize = true;
            this.Player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1NameLabel.Location = new System.Drawing.Point(131, 31);
            this.Player1NameLabel.Name = "Player1NameLabel";
            this.Player1NameLabel.Size = new System.Drawing.Size(54, 17);
            this.Player1NameLabel.TabIndex = 5;
            this.Player1NameLabel.Text = "Player";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pontuação";
            // 
            // RemaingBombs
            // 
            this.RemaingBombs.Enabled = false;
            this.RemaingBombs.Location = new System.Drawing.Point(9, 22);
            this.RemaingBombs.Name = "RemaingBombs";
            this.RemaingBombs.Size = new System.Drawing.Size(75, 75);
            this.RemaingBombs.TabIndex = 3;
            this.RemaingBombs.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bombas";
            // 
            // Time
            // 
            this.Time.Enabled = false;
            this.Time.Location = new System.Drawing.Point(335, 20);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(75, 74);
            this.Time.TabIndex = 1;
            this.Time.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tempo";
            // 
            // panelMatriz
            // 
            this.panelMatriz.AccessibleName = "painelTable";
            this.panelMatriz.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelMatriz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMatriz.Location = new System.Drawing.Point(12, 171);
            this.panelMatriz.Name = "panelMatriz";
            this.panelMatriz.Size = new System.Drawing.Size(415, 326);
            this.panelMatriz.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jogoToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jogoToolStripMenuItem
            // 
            this.jogoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.jogoToolStripMenuItem.Name = "jogoToolStripMenuItem";
            this.jogoToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.jogoToolStripMenuItem.Text = "Jogo";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fácilToolStripMenuItem1,
            this.médioToolStripMenuItem1,
            this.difícilToolStripMenuItem1});
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.novoToolStripMenuItem.Text = "Novo";
            // 
            // fácilToolStripMenuItem1
            // 
            this.fácilToolStripMenuItem1.Name = "fácilToolStripMenuItem1";
            this.fácilToolStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            this.fácilToolStripMenuItem1.Text = "Fácil";
            this.fácilToolStripMenuItem1.Click += new System.EventHandler(this.fácilToolStripMenuItem1_Click);
            // 
            // médioToolStripMenuItem1
            // 
            this.médioToolStripMenuItem1.Name = "médioToolStripMenuItem1";
            this.médioToolStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            this.médioToolStripMenuItem1.Text = "Médio";
            this.médioToolStripMenuItem1.Click += new System.EventHandler(this.médioToolStripMenuItem1_Click);
            // 
            // difícilToolStripMenuItem1
            // 
            this.difícilToolStripMenuItem1.Name = "difícilToolStripMenuItem1";
            this.difícilToolStripMenuItem1.Size = new System.Drawing.Size(175, 24);
            this.difícilToolStripMenuItem1.Text = "Difícil";
            this.difícilToolStripMenuItem1.Click += new System.EventHandler(this.difícilToolStripMenuItem1_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // MinesweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(444, 506);
            this.Controls.Add(detailspanel);
            this.Controls.Add(this.panelMatriz);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MinesweeperForm";
            this.Text = "MinesweeperForm";
            this.Load += new System.EventHandler(this.MinesweeperForm_Load);
            detailspanel.ResumeLayout(false);
            detailspanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        public System.Windows.Forms.Panel panelMatriz;
        private System.Windows.Forms.Button Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemaingBombs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Player2NameLabel;
        private System.Windows.Forms.Label Player1NameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem fácilToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem médioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem difícilToolStripMenuItem1;
    }
}