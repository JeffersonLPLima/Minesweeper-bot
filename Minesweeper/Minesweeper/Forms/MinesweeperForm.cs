using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        /// <summary>
        /// Image Locations
        /// </summary>
        private static String noDesmImg = "Forms/Images/casaInativa.JPG";

        private static String noMarcImg = "Forms/Images/casaAtiva.JPG";
        private static String Img1 = "Forms/Images/1.JPG";
        private static String Img2 = "Forms/Images/2.JPG";
        private static String Img3 = "Forms/Images/3.JPG";
        private static String Img4 = "Forms/Images/4.JPG";
        private static String Img5 = "Forms/Images/5.JPG";
        private static String Img6 = "Forms/Images/6.JPG";
        private static String Img7 = "Forms/Images/7.JPG";
        private static String Img8 = "Forms/Images/8.JPG";
        private static String mineImg = "Forms/Images/mine.JPG";
        private static String flagImg = "Forms/Images/flag.JPG";


        private static int timeRemaining;
        private static bool click;
        private static Game gameMine;
        public static Thread thread;
        private static int initialTime;



        public MinesweeperForm(int difficulty, String name)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            if (difficulty == 1) { 
                gameMine = new Game(name, 8, 8);
                initialTime = 15;
                timeRemaining = initialTime;
            }
            else if (difficulty == 2) {
                gameMine = new Game(name, 16, 16);
                initialTime = 13;
                timeRemaining = initialTime;
            }
            else { 
                gameMine = new Game(name, 30, 16);
                initialTime = 10;
                timeRemaining = initialTime;

            }
            click = true;
            gameMine.Player1.Name = name;

            InitializeComponent();
        }






        public void btnEvent_Click(object sender, MouseEventArgs e)
        {

            if (gameMine.Round % 2 == 0)
            {

                String[] pos = ((Button)sender).Name.Split(',');
                int posx = Convert.ToInt32(pos[0]);

                int posy = Convert.ToInt32(pos[1]);

                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (!gameMine.Table.Table[posx, posy].Flaged)
                    {
                        if (!gameMine.Table.Table[posx, posy].Visited)
                        {

                            Image imgFlag = Image.FromFile(flagImg);
                            btn[posx][posy].Image = imgFlag;
                            gameMine.Table.Bombs -= 1;
                            RemainingBombs.Text = gameMine.Table.Bombs.ToString();
                            gameMine.Table.Table[posx, posy].Flaged = true;
                        }
                    }
                    else if (gameMine.Table.Table[posx, posy].Flaged)
                    {
                        if (!gameMine.Table.Table[posx, posy].Visited)
                        {
                            Image imgFlag = Image.FromFile(noDesmImg);
                            btn[posx][posy].Image = imgFlag;
                            gameMine.Table.Bombs += 1;
                            RemainingBombs.Text = gameMine.Table.Bombs.ToString();
                            gameMine.Table.Table[posx, posy].Flaged = false;
                        }
                    }
                }
                else
                {
                    if (!gameMine.Table.Table[posx, posy].Visited)
                    {
                        timeRemaining = initialTime;
                        timeRemainingLabel.Text = initialTime.ToString();
                        Console.WriteLine(((Button)sender).Name);

                        Position positionClicked = new Position(posx, posy);

                        gameMine.Player1.LastPosition = positionClicked;
                    }
                    if (click)
                    {
                        click = false;
                        thread = new Thread(new ThreadStart(gameMine.run));

                        thread.Start();
                        timer.Start();

                    }
                }
            }

        }

        public void MinesweeperForm_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();   
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(this.timer1_Tick);
            timeRemainingLabel.Text = timeRemaining.ToString();

            RemainingBombs.Text = gameMine.Table.Bombs.ToString();
            Player1NameLabel.Text = gameMine.Player1.Name;
            Player2NameLabel.Text = gameMine.Player2.Name;

            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
            Image img = Image.FromFile(noDesmImg);
            panelMatriz.Size = new Size(25 * matrizX, 25 * matrizY);

            btn = new Button[matrizX][];
            for (int x = 0; x < matrizX; x++)
            {
                btn[x] = new Button[matrizY];
                for (int y = 0; y < matrizY; y++)
                {
                    btn[x][y] = new Button();
                    btn[x][y].Name = Convert.ToString(x + "," + y);


                    btn[x][y].AccessibleName = "casa";
                    btn[x][y].Size = new Size(25, 25);

                    btn[x][y].Image = img;

                    btn[x][y].Visible = true;
                    btn[x][y].Location = new Point(x * 25, y * 25);
                    btn[x][y].MouseUp += new MouseEventHandler(this.btnEvent_Click);
                    panelMatriz.Controls.Add(btn[x][y]);


                }
            }
            this.panelMatriz.Location = new System.Drawing.Point(System.Convert.ToInt32((this.Size.Width / 2) - (this.panelMatriz.Size.Width / 2)), 171);
        }
        public static void showTableBombs()
        {
            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
            Console.WriteLine("Bombas no tabuleiro");
            gameMine.Table.showBombs();
            Console.WriteLine("=======================");
            Image img;
            for (int x = 0; x < matrizX; x++)
            {
                for (int y = 0; y < matrizY; y++)
                {

                    if (gameMine.Table.Table[x, y].Key == 10)
                    {
                        img = Image.FromFile(mineImg);
                        btn[x][y].Image = img;

                    }

                }
            }
            timer.Stop();

            if (gameMine.Round % 2 == 0) { 
                smilleButton.Image = Properties.Resources.smilleCoroa;
            }
            else {
                memButton.Image = Properties.Resources.trollface_memeCoroa;

            }


            MessageBox.Show(gameMine.getTurnPlayer().Name + " Ganhou!!", "Minesweeper");

        }
        /// <summary>
        /// Update Rendered Table
        /// 
        /// </summary>
        public static void updateTable()
        {

            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
            Console.WriteLine("Tabuleiro no MinesweeperForms");
            gameMine.Table.printMatrix();
            Console.WriteLine("=======================");
            for (int x = 0; x < matrizX; x++)
            {
                for (int y = 0; y < matrizY; y++)
                {

                    if (gameMine.Table.Table[x, y].Visited == true)
                    {

                        if (gameMine.Table.Table[x, y].Key == 0)
                        {

                            Image img = Image.FromFile(noMarcImg);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 1)
                        {
                            Image img = Image.FromFile(Img1);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 2)
                        {
                            Image img = Image.FromFile(Img2);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 3)
                        {
                            Image img = Image.FromFile(Img3);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 4)
                        {
                            Image img = Image.FromFile(Img4);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 5)
                        {
                            Image img = Image.FromFile(Img5);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 6)
                        {
                            Image img = Image.FromFile(Img6);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 7)
                        {
                            Image img = Image.FromFile(Img7);
                            btn[x][y].Image = img;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 8)
                        {
                            Image img = Image.FromFile(Img8);
                            btn[x][y].Image = img;
                        }


                    }
                }
            }

        }










        public void RunMinesweeperForms(int difficulty, String name)
        {



            // Game game = new Game("Player1", 7, 7);
            //MessageBox.Show("Nome/Tamanho:" + gameMine.Player1.Name + "/" + gameMine.Table.Rows + gameMine.Table.Columns);
            // MessageBox.Show(difficulty + name);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MinesweeperForm(difficulty, name));


            //      game.run();
        }

        private void onFormClosing(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            timeRemainingLabel.Text = timeRemaining.ToString();
            if (timeRemaining == 0){
                timer.Stop();
                timeRemainingLabel.Text = timeRemaining.ToString();
                MessageBox.Show("O Tempo acabou!!\nVocê Perdeu " + Player1NameLabel.Text, "Minesweeper");
                gameMine.Round = 1;
                showTableBombs();

            }

        }


        private void MainForm_KeyDown(object sender, KeyEventArgs k)
        {
            if(k.Control){
                switch (k.KeyCode){
                    case Keys.F:
                        facilToolStripMenuItem1_Click(sender, k);
                        break;
                        case Keys.M:
                        medioToolStripMenuItem1_Click(sender, k);
                        break;
                        case Keys.D:
                        dificilToolStripMenuItem1_Click(sender, k);
                        break;
                        case Keys.S:
                        break;
                        case Keys.F4:
                        break;
                        case Keys.T:
                        break;


                }


            }
        }
        void facilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MinesweeperForm(1, gameMine.Player1.Name).Show();
        }

        private void medioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MinesweeperForm(2, gameMine.Player1.Name).Show();
        }

        private void dificilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MinesweeperForm(3, gameMine.Player1.Name).Show();
        }



        public void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do jogo ?", "Minesweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                if (thread != null)
                    thread.Abort();
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.AboutForm().Show();

        }



    }
}
