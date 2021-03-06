﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace Minesweeper{
    public partial class MinesweeperForm : Form{
        /// <summary>
        /// Image Locations
        /// </summary>
        private const String noDesmImg = "Forms/Images/casaInativa.JPG";
        private const String noMarcImg = "Forms/Images/casaAtiva.JPG";
        private const String Img1 = "Forms/Images/1.JPG";
        private const String Img2 = "Forms/Images/2.JPG";
        private const String Img3 = "Forms/Images/3.JPG";
        private const String Img4 = "Forms/Images/4.JPG";
        private const String Img5 = "Forms/Images/5.JPG";
        private const String Img6 = "Forms/Images/6.JPG";
        private const String Img7 = "Forms/Images/7.JPG";
        private const String Img8 = "Forms/Images/8.JPG";
        private const String mineImg = "Forms/Images/mine.JPG";
        private const String flagImg = "Forms/Images/flag.JPG";

        private static int timeRemaining;
        private static bool firstClick;
        private static Game gameMine;
        public static Thread thread;
        private static int initialTime;
        public static int userBombsRemaining;
       
        /// <summary>
        /// MinesweeperForm Constructor
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="name"></param>
        /// <param name="whoBegins"></param>
        public MinesweeperForm(byte difficulty, String name, byte whoBegins){
            CheckForIllegalCrossThreadCalls = false;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(this.timer1_Tick);

            firstClick = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            gameMine = new Game(name, difficulty, whoBegins);
           
            initialTime = 10;
            timeRemaining = initialTime;
           
            if (gameMine.Round == 1){
                MessageBox.Show(gameMine.Player2.Name + " começa!", " Minesweeper ");
                firstClick = false;
                thread = new Thread(new ThreadStart(gameMine.run));
                thread.Start();
                timer.Start();
            }else{
                MessageBox.Show(gameMine.Player1.Name+" começa!", " Minesweeper ");
            }
           
            userBombsRemaining = gameMine.Table.Bombs;
            gameMine.Player1.Name = name;

            InitializeComponent();
        }

        /// <summary>
        /// get event - left and right - click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnEvent_Click(object sender, MouseEventArgs e){

            if (gameMine.Round % 2 == 0 && gameMine.Active){

                String[] pos = ((Button)sender).Name.Split(',');
                int posx = Convert.ToInt32(pos[0]);

                int posy = Convert.ToInt32(pos[1]);

                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right){
                    if (!gameMine.Table.Table[posx, posy].IsFlagged && userBombsRemaining!=0){
                        if (!gameMine.Table.Table[posx, posy].Visited){
                            Image imgFlag = Image.FromFile(flagImg);
                            btn[posx][posy].Image = imgFlag;
                            userBombsRemaining -= 1;
                            RemainingBombs.Text = userBombsRemaining.ToString();
                            gameMine.Table.Table[posx, posy].IsFlagged = true;
                        }
                    }else if (gameMine.Table.Table[posx, posy].IsFlagged){
                        if (!gameMine.Table.Table[posx, posy].Visited){
                            Image imgFlag = Image.FromFile(noDesmImg);
                            btn[posx][posy].Image = imgFlag;
                            userBombsRemaining += 1;
                            RemainingBombs.Text = userBombsRemaining.ToString();
                            gameMine.Table.Table[posx, posy].IsFlagged = false;
                        }
                    }
                }

                else{
                    if (!gameMine.Table.Table[posx, posy].Visited && !gameMine.Table.Table[posx, posy].IsFlagged){
                        Console.WriteLine(((Button)sender).Name);
                        Position positionClicked = new Position(posx, posy);
                        gameMine.Player1.LastPosition = positionClicked;
                    }

                    if (firstClick){
                        firstClick = false;
                        thread = new Thread(new ThreadStart(gameMine.run));

                        thread.Start();
                        timer.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Load Table Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MinesweeperForm_Load(object sender, EventArgs e){
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
            for (int y = 0; y< matrizX; y++){
                btn[y] = new Button[matrizY];
                for (int x = 0;x  < matrizY; x++){
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
        public static void showTableBombs(){
            timer.Stop();

            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
           
            gameMine.Table.showBombs();
            Image img;

            for (int x = 0; x < matrizX; x++){
                for (int y = 0; y < matrizY; y++){
                    if (gameMine.Table.Table[x, y].Key == 10){
                        img = Image.FromFile(mineImg);
                        btn[x][y].Image = img;
                    }
                }
            }
            
            if (gameMine.Table.NodesRemaining != 0){
                if (gameMine.Round % 2 == 0){
                    pictureBoxSmille.Image = Properties.Resources.smilleCoroa1;
                }else{
                    pictureBoxMeme.Image = Properties.Resources.memeCoroa;
                }

                timer.Stop();
                MessageBox.Show(gameMine.getTurnPlayer().Name + " Ganhou!!", "Minesweeper");
            }
        }

        /// <summary>
        /// Update Rendered Table
        /// </summary>
        public static void updateTable(){
            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;

            Console.WriteLine("Tabuleiro no MinesweeperForms");
            gameMine.Table.printMatrix();
            Console.WriteLine("=======================");

            for (int x = 0; x < matrizX; x++){
                for (int y = 0; y < matrizY; y++){
                    if (gameMine.Table.Table[x, y].Visited == true){
                        if (gameMine.Table.Table[x, y].IsFlagged){
                            userBombsRemaining += 1;
                            gameMine.Table.Table[x, y].IsFlagged = false;
                            RemainingBombs.Text = userBombsRemaining.ToString();
                        }
                        if (gameMine.Table.Table[x, y].Key == 0){
                            Image img = Image.FromFile(noMarcImg);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 1){
                            Image img = Image.FromFile(Img1);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 2){
                            Image img = Image.FromFile(Img2);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 3){
                            Image img = Image.FromFile(Img3);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 4){
                            Image img = Image.FromFile(Img4);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 5){
                            Image img = Image.FromFile(Img5);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 6){
                            Image img = Image.FromFile(Img6);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 7){
                            Image img = Image.FromFile(Img7);
                            btn[x][y].Image = img;
                        }else if (gameMine.Table.Table[x, y].Key == 8){
                            Image img = Image.FromFile(Img8);
                            btn[x][y].Image = img;
                        }
                    }
                }
                timeRemaining = initialTime;
                timeRemainingLabel.Text = initialTime.ToString();
                        
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
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="name"></param>
        public void RunMinesweeperForms(byte difficulty, String name){
            byte whoBegins=(byte) RandomUtil.getRandomNumber(0, 2);
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MinesweeperForm(difficulty, name, whoBegins));
        }

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onFormClosing(object sender, FormClosedEventArgs e){
            Environment.Exit(0);
        }

        /// <summary>
        /// Timer Countdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer1_Tick(object sender, EventArgs e){
            timeRemaining--;
            timeRemainingLabel.Text = timeRemaining.ToString();

            if (timeRemaining == 0){
                timer.Stop();
                timeRemaining = initialTime;
                timeRemainingLabel.Text = timeRemaining.ToString();
                gameMine.Player1.randomPlay(gameMine.Table);
                timer.Start();
            }
        }

        /// <summary>
        /// Begins a new easy game with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void facilToolStripMenuItem1_Click(object sender, EventArgs e){
            byte whoBegins = (byte)RandomUtil.getRandomNumber(0, 2);
            timer.Stop();
            this.Hide();
            new MinesweeperForm(1, gameMine.Player1.Name, whoBegins).Show();
        }

        /// <summary>
        /// Begins a new medium game with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void medioToolStripMenuItem1_Click(object sender, EventArgs e){
            timer.Stop();
            byte whoBegins=(byte) RandomUtil.getRandomNumber(0, 2);
            this.Hide();
            new MinesweeperForm(2, gameMine.Player1.Name, whoBegins).Show();
        }

        /// <summary>
        /// Begins a new hard game with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dificilToolStripMenuItem1_Click(object sender, EventArgs e){
            timer.Stop();
            byte whoBegins=(byte) RandomUtil.getRandomNumber(0, 2);
            this.Hide();
            new MinesweeperForm(3, gameMine.Player1.Name, whoBegins).Show();
        }

        /// <summary>
        /// Finish the game/application with menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void sairToolStripMenuItem_Click(object sender, EventArgs e){
            if (MessageBox.Show("Deseja sair do jogo ?", "Minesweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
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
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e){
            new Forms.AboutForm().Show();
        }
    }
}
