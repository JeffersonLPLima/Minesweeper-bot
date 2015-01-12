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
        public static int userBombsRemaining;
       
        /// <summary>
        /// builder
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="name"></param>
        /// <param name="whoBegins"></param>
        public MinesweeperForm(int difficulty, String name, byte whoBegins)
        {
            CheckForIllegalCrossThreadCalls = false;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(this.timer1_Tick);
            click = true;
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
                gameMine = new Game(name, 16, 30);
                initialTime = 10;
                timeRemaining = initialTime;

            }
           
            if (whoBegins == 0)
            {
                MessageBox.Show("The B0T começa!", " Minesweeper ");
                click = false;
                thread = new Thread(new ThreadStart(gameMine.run));
                thread.Start();
                gameMine.Round = 1;
                timer.Start();
                
            }
            else
            {
                MessageBox.Show(name+" começa!", " Minesweeper ");
                
            }

           
            userBombsRemaining = gameMine.Table.Bombs;
            gameMine.Player1.Name = name;

            InitializeComponent();
        }





        /// <summary>
        /// get button event - left and right - click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnEvent_Click(object sender, MouseEventArgs e)
        {

            if (gameMine.Round % 2 == 0 && gameMine.Active)

            {

                String[] pos = ((Button)sender).Name.Split(',');
                int posx = Convert.ToInt32(pos[0]);

                int posy = Convert.ToInt32(pos[1]);

                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (!gameMine.Table.Table[posx, posy].Flaged && userBombsRemaining!=0)
                    {
                        if (!gameMine.Table.Table[posx, posy].Visited)
                        {

                            Image imgFlag = Image.FromFile(flagImg);
                            btn[posx][posy].Image = imgFlag;
                            userBombsRemaining -= 1;
                            RemainingBombs.Text = userBombsRemaining.ToString();
                            gameMine.Table.Table[posx, posy].Flaged = true;
                        }
                    }
                    else if (gameMine.Table.Table[posx, posy].Flaged)
                    {
                        if (!gameMine.Table.Table[posx, posy].Visited)
                        {
                            Image imgFlag = Image.FromFile(noDesmImg);
                            btn[posx][posy].Image = imgFlag;
                            userBombsRemaining += 1;
                            RemainingBombs.Text = userBombsRemaining.ToString();
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
        /// <summary>
        /// Loag Table Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MinesweeperForm_Load(object sender, EventArgs e)
        {
            
            timeRemainingLabel.Text = timeRemaining.ToString();

            RemainingBombs.Text = userBombsRemaining.ToString(); ;
            Player1NameLabel.Text = gameMine.Player1.Name;
            Player2NameLabel.Text = gameMine.Player2.Name;
            gameMine.Active = true;

            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
            Image img = Image.FromFile(noDesmImg);
            panelMatriz.Size = new Size(25 * matrizY, 25 * matrizX);
      

            btn = new Button[matrizX][];
            for (int y = 0; y< matrizX; y++)
            {
                btn[y] = new Button[matrizY];
                for (int x = 0;x  < matrizY; x++)
                {
                    btn[y][x] = new Button();
                    btn[y][x].Name = Convert.ToString(y + "," + x);


                    btn[y][x].AccessibleName = "casa";
                    btn[y][x].Size = new Size(25, 25);

                    btn[y][x].Image = img;

                    btn[y][x].Visible = true;
                    btn[y][x].Location = new Point(x * 25, y* 25);
                    btn[y][x].MouseUp += new MouseEventHandler(this.btnEvent_Click);
                    panelMatriz.Controls.Add(btn[y][x]);


                }
            }
            this.panelMatriz.Location = new System.Drawing.Point(this.Size.Width / 2 - this.panelMatriz.Size.Width / 2, 171);
        }

        /// <summary>
        /// Show Bombs in the Table
        /// </summary>
        public static void showTableBombs()
        {
            timer.Stop();

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

          
            

            
            if (gameMine.Table.NodesRemaining != 0){

                if (gameMine.Round % 2 == 0)
                {
                    pictureBoxSmille.Image = Properties.Resources.smilleCoroa1;
                }
                else
                {
                    pictureBoxMeme.Image = Properties.Resources.memeCoroa;
                }
                timer.Stop();
                MessageBox.Show(gameMine.getTurnPlayer().Name + " Ganhou!!", "Minesweeper");
                
            }

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

                        if (gameMine.Table.Table[x, y].Flaged)
                        {
                            userBombsRemaining += 1;
                            gameMine.Table.Table[x, y].Flaged = false;
                            RemainingBombs.Text = userBombsRemaining.ToString();


                        }
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
           
            if (gameMine.Table.NodesRemaining == 0){
                timer.Stop();
                MessageBox.Show(" Empate!!", "Minesweeper");
                showTableBombs();
                gameMine.Active = false;
                
            }
            
        }




        /// <summary>
        /// Run MinesweeperForms
        /// Enable Visual Styles
        /// 
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="name"></param>

        public void RunMinesweeperForms(int difficulty, String name)
        {


            byte whoBegins=(byte) RandomUtil.GetRandomNumber(0, 2);

           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MinesweeperForm(difficulty, name, whoBegins));




          
        }
        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onFormClosing(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void randomPlay()
        {
            Position pos;
            bool flag = false;
            while (!flag)
            {
                pos = new Position(RandomUtil.GetRandomNumber(0, gameMine.Table.Rows), RandomUtil.GetRandomNumber(0, gameMine.Table.Columns));
                Console.WriteLine("Posição sorteada = X: " + pos.X + " Y: " + pos.Y);
                if (!gameMine.Table.Table[pos.X, pos.Y].Visited)
                {
                    timeRemaining = initialTime;
                    timeRemainingLabel.Text = timeRemaining.ToString();
                    timer.Start();
                    gameMine.Player1.LastPosition = pos;
                    gameMine.Player1.play(gameMine.Table);
                    flag = true;
                }
            }

        }

        /// <summary>
        /// Timer Countdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer1_Tick(object sender, EventArgs e)
        {
            
            timeRemaining--;
            timeRemainingLabel.Text = timeRemaining.ToString();
            if (timeRemaining == 0){

                timer.Stop();
                timeRemainingLabel.Text = 0.ToString();
                randomPlay();
             
               

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
        /// <summary>
        /// Begins a new easy game with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void facilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            byte whoBegins = (byte)RandomUtil.GetRandomNumber(0, 2);
            timer.Stop();
            this.Hide();
            new MinesweeperForm(1, gameMine.Player1.Name, whoBegins).Show();
        }

        /// <summary>
        /// Begins a new medium game with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void medioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            byte whoBegins=(byte) RandomUtil.GetRandomNumber(0, 2);
            this.Hide();
            new MinesweeperForm(2, gameMine.Player1.Name, whoBegins).Show();
        }
        /// <summary>
        /// Begins a new hard game with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dificilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            byte whoBegins=(byte) RandomUtil.GetRandomNumber(0, 2);
            this.Hide();

            new MinesweeperForm(3, gameMine.Player1.Name, whoBegins).Show();
        }


        /// <summary>
        /// Finish the game/application with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do jogo ?", "Minesweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                if (thread != null)
                    thread.Abort();
            }
        }
        /// <summary>
        /// About menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.AboutForm().Show();

        }



    }
}
