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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperForm));
            pictureBoxSmille = new System.Windows.Forms.PictureBox();
            pictureBoxMeme = new System.Windows.Forms.PictureBox();
            RemainingBombs = new System.Windows.Forms.Label();
            timeRemainingLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Player2NameLabel = new System.Windows.Forms.Label();
            this.Player1NameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(pictureBoxSmille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxMeme)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailspanel
            // 
            detailspanel.AccessibleName = "details";
            detailspanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            detailspanel.AutoSize = true;
            detailspanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            detailspanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            detailspanel.Controls.Add(pictureBoxSmille);
            detailspanel.Controls.Add(pictureBoxMeme);
            detailspanel.Controls.Add(RemainingBombs);
            detailspanel.Controls.Add(timeRemainingLabel);
            detailspanel.Controls.Add(this.label4);
            detailspanel.Controls.Add(this.Player2NameLabel);
            detailspanel.Controls.Add(this.Player1NameLabel);
            detailspanel.Controls.Add(this.label2);
            detailspanel.Controls.Add(this.label1);
            detailspanel.Location = new System.Drawing.Point(12, 57);
            detailspanel.Name = "detailspanel";
            detailspanel.Size = new System.Drawing.Size(444, 108);
            detailspanel.TabIndex = 1;
            // 
            // pictureBoxSmille
            // 
            pictureBoxSmille.Image = global::Minesweeper.Properties.Resources.oie_transparent__1_;
            pictureBoxSmille.InitialImage = global::Minesweeper.Properties.Resources.trollface_meme;
            pictureBoxSmille.Location = new System.Drawing.Point(218, 7);
            pictureBoxSmille.Name = "pictureBoxSmille";
            pictureBoxSmille.Size = new System.Drawing.Size(72, 71);
            pictureBoxSmille.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBoxSmille.TabIndex = 12;
            pictureBoxSmille.TabStop = false;
            // 
            // pictureBoxMeme
            // 
            pictureBoxMeme.Image = global::Minesweeper.Properties.Resources.oie_transparent;
            pictureBoxMeme.InitialImage = global::Minesweeper.Properties.Resources.trollface_meme;
            pictureBoxMeme.Location = new System.Drawing.Point(104, 7);
            pictureBoxMeme.Name = "pictureBoxMeme";
            pictureBoxMeme.Size = new System.Drawing.Size(72, 71);
            pictureBoxMeme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBoxMeme.TabIndex = 11;
            pictureBoxMeme.TabStop = false;
            // 
            // RemainingBombs
            // 
            RemainingBombs.AutoSize = true;
            RemainingBombs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            RemainingBombs.Location = new System.Drawing.Point(13, 46);
            RemainingBombs.Name = "RemainingBombs";
            RemainingBombs.Size = new System.Drawing.Size(49, 32);
            RemainingBombs.TabIndex = 9;
            RemainingBombs.Text = "00";
            // 
            // timeRemainingLabel
            // 
            timeRemainingLabel.AutoSize = true;
            timeRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timeRemainingLabel.Location = new System.Drawing.Point(350, 46);
            timeRemainingLabel.Name = "timeRemainingLabel";
            timeRemainingLabel.Size = new System.Drawing.Size(49, 32);
            timeRemainingLabel.TabIndex = 8;
            timeRemainingLabel.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "X";
            // 
            // Player2NameLabel
            // 
            this.Player2NameLabel.AutoSize = true;
            this.Player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2NameLabel.Location = new System.Drawing.Point(113, 79);
            this.Player2NameLabel.Name = "Player2NameLabel";
            this.Player2NameLabel.Size = new System.Drawing.Size(40, 17);
            this.Player2NameLabel.TabIndex = 6;
            this.Player2NameLabel.Text = "BOT";
            // 
            // Player1NameLabel
            // 
            this.Player1NameLabel.AutoSize = true;
            this.Player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1NameLabel.Location = new System.Drawing.Point(215, 79);
            this.Player1NameLabel.Name = "Player1NameLabel";
            this.Player1NameLabel.Size = new System.Drawing.Size(54, 17);
            this.Player1NameLabel.TabIndex = 5;
            this.Player1NameLabel.Text = "Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bombas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 20);
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
            this.panelMatriz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMatriz.Location = new System.Drawing.Point(12, 171);
            this.panelMatriz.Name = "panelMatriz";
            this.panelMatriz.Size = new System.Drawing.Size(95, 103);
            this.panelMatriz.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jogoToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 28);
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
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.novoToolStripMenuItem.Text = "Novo";
            // 
            // fácilToolStripMenuItem1
            // 
            this.fácilToolStripMenuItem1.Name = "fácilToolStripMenuItem1";
            this.fácilToolStripMenuItem1.Size = new System.Drawing.Size(121, 24);
            this.fácilToolStripMenuItem1.Text = "Fácil";
            this.fácilToolStripMenuItem1.Click += new System.EventHandler(this.facilToolStripMenuItem1_Click);
            // 
            // médioToolStripMenuItem1
            // 
            this.médioToolStripMenuItem1.Name = "médioToolStripMenuItem1";
            this.médioToolStripMenuItem1.Size = new System.Drawing.Size(121, 24);
            this.médioToolStripMenuItem1.Text = "Médio";
            this.médioToolStripMenuItem1.Click += new System.EventHandler(this.medioToolStripMenuItem1_Click);
            // 
            // difícilToolStripMenuItem1
            // 
            this.difícilToolStripMenuItem1.Name = "difícilToolStripMenuItem1";
            this.difícilToolStripMenuItem1.Size = new System.Drawing.Size(121, 24);
            this.difícilToolStripMenuItem1.Text = "Difícil";
            this.difícilToolStripMenuItem1.Click += new System.EventHandler(this.dificilToolStripMenuItem1_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
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
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // MinesweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(469, 506);
            this.Controls.Add(detailspanel);
            this.Controls.Add(this.panelMatriz);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MinesweeperForm";
            this.Text = "MinesweeperForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosing);
            this.Load += new System.EventHandler(this.MinesweeperForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            detailspanel.ResumeLayout(false);
            detailspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxSmille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxMeme)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Player2NameLabel;
        private System.Windows.Forms.Label Player1NameLabel;
        private System.Windows.Forms.ToolStripMenuItem fácilToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem médioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem difícilToolStripMenuItem1;
        private System.Windows.Forms.Label label4;
        private static System.Windows.Forms.Label timeRemainingLabel;
        public static System.Windows.Forms.Label RemainingBombs;
        public static System.Windows.Forms.Button[][] btn;
        public static System.Windows.Forms.Timer timer;
        private static System.Windows.Forms.PictureBox pictureBoxMeme;
        private static System.Windows.Forms.PictureBox pictureBoxSmille;

    }

}