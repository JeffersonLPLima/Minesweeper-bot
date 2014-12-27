using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        /// <summary>
        /// Image Locations
        /// </summary>
      
        static bool click;
             /// </summary>
    
        private static String noDesmImg = "Forms/Images/casaInativa.JPG";
       	
       	private static String noMarcImg = "Forms/Images/casaAtiva.JPG";
		private static String Img1 = "Forms/Images/1.JPG";
		private static String Img2 = "Forms/Images/2.JPG";
		private static String Img3= "Forms/Images/3.JPG";
		private static String Img4 = "Forms/Images/4.JPG";
		private static String Img5 = "Forms/Images/5.JPG";
		private static String Img6 = "Forms/Images/6.JPG";
		private static String Img7 = "Forms/Images/7.JPG";
		private static String Img8 = "Forms/Images/8.JPG";
		private static String mineImg = "Forms/Images/mina.jpg";
		private static String flagImg = "Forms/Images/flag.JPG";

        /*
private static String noDesmImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/casaInativa.JPG";

private static String noMarcImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/casaAtiva.JPG";
private static String Img1 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/1.JPG";
private static String Img2 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/2.JPG";
private static String Img3 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/3.JPG";
private static String Img4 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/4.JPG";
private static String Img5 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/5.JPG";
private static String Img6 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/6.JPG";
private static String Img7 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/7.JPG";
private static String Img8 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/8.JPG";
private static String mineImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/mina.jpg";
private static String flagImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/flag.JPG";
* */
        static Game gameMine;
        static Button[][] btn;
        Thread thread;
        public MinesweeperForm(int difficulty, String name)
        {
            if (difficulty == 1) gameMine = new Game(name, 8, 8);
            else if (difficulty == 2) gameMine = new Game(name, 16, 16);
            else gameMine = new Game(name, 24, 24);
            click = true;
           
            gameMine.Player1.Name = name;


            InitializeComponent();
        }



        private void sairToolStripMenuItem_Click(object sender, EventArgs e){
            if (MessageBox.Show("Deseja sair do jogo ?", "Minesweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){

                Application.Exit();
            }
        }

        

        public void btnEvent_Click(object sender, MouseEventArgs e)
        {
            String[] pos = ((Button)sender).Name.Split(',');
            int posx = Convert.ToInt32(pos[0]);

            int posy = Convert.ToInt32(pos[1]);
            Console.WriteLine("Posição X:" + posx);
            Console.WriteLine("Posição Y:" + posy);
            MouseEventArgs me = (MouseEventArgs)e;
            //HandledMouseEventArgs me = (HandledMouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (!gameMine.Table.Table[posx,posy].Flaged) 
                { 
                    Image imgFlag= Image.FromFile(flagImg);
                    btn[posy][posx].Image = imgFlag;
                    gameMine.Table.Bombs -= 1;
                    RemaingBombs.Text = gameMine.Table.Bombs.ToString();
                    gameMine.Table.Table[posx, posy].Flaged = true;
                }
                else
                {
                    Image imgFlag = Image.FromFile(noDesmImg);
                    btn[posy][posx].Image = imgFlag;
                    gameMine.Table.Bombs += 1;
                    RemaingBombs.Text = gameMine.Table.Bombs.ToString();
                    gameMine.Table.Table[posx, posy].Flaged = false;
                } 

     
            }
            else
            {   
                Console.WriteLine(((Button)sender).Name);
                
                Position positionClicked = new Position(posx, posy);

                gameMine.Player1.LastPosition = positionClicked;
                gameMine.Player1.play(gameMine.Table);

                if (click)
                {
                    click = false;
 
                    thread = new Thread(new ThreadStart(gameMine.run));
                    thread.Start();
                }
            }
        }
        
        
        private void MinesweeperForm_Load(object sender, EventArgs e){
            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;

			//string dir = Path.Combine (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), noDesmImg);

			//Console.WriteLine ("Dir: " + dir);
			Image img = Image.FromFile(noDesmImg);
            panelMatriz.Size = new Size(25 * matrizX, 25 * matrizY);
            panelMatriz.Visible = true;
            Button[][] btn = new Button[matrizX][];
            
			for (int x = 0; x < matrizX; x++){
                btn[x] = new Button[matrizY];
                for (int y = 0; y < matrizY; y++){
                    btn[x][y] = new Button();
                    btn[x][y].Name = Convert.ToString(y + "," + x);


                    btn[x][y].AccessibleName = "casa";
                    btn[x][y].Size = new Size(25, 25);


                    btn[x][y].Image = img;

                    btn[x][y].Visible = true;
                    btn[x][y].Location = new Point(x * 25, y * 25);
                  //  btn[x][y].Click += new System.Windows.Forms.MouseEventHandler(this.btnEvent_Click);
                    btn[x][y].MouseUp += new MouseEventHandler(this.btnEvent_Click);
               //     btn[x][y].MouseUp += System.Windows.FoMouseEventArgs;
                    panelMatriz.Controls.Add(btn[x][y]);

                }
            }

        }
        public static void showTableBombs()
        {
            //Image img = Image.FromFile(noDesmImg);
            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
            //  int matrizX = gameTable.Rows;
            // int matrizY = gameTable.Columns;
            // panelMatriz.Size = new Size(25 * matrizX, 25 * matrizY);
            //   panelMatriz.Visible = true;

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
                        btn[y][x].Image = img;
                      
                    }

                }
            }
            MessageBox.Show(gameMine.getTurnPlayer().Name + " Ganhou!!", "Minesweeper");  
        }
        /// <summary>
        /// Update Rendered Table
        /// 
        /// </summary>
        public static void updateTable()
        {
           
            //Image img = Image.FromFile(noDesmImg);
            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
            //  int matrizX = gameTable.Rows;
            // int matrizY = gameTable.Columns;
            // panelMatriz.Size = new Size(25 * matrizX, 25 * matrizY);
            //   panelMatriz.Visible = true;
            Image img;
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

                            img = Image.FromFile(noMarcImg);
                            btn[y][x].Image = img;
                       
                            //     btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 1)
                        {
                            img = Image.FromFile(Img1);
                            btn[y][x].Image = img;
                            //     btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 2)
                        {
                            img = Image.FromFile(Img2);
                            btn[y][x].Image = img;
                            //     btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 3)
                        {
                            img = Image.FromFile(Img3);
                            btn[y][x].Image = img;
                            //   btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 4)
                        {
                            img = Image.FromFile(Img4);
                            btn[y][x].Image = img;
                            //    btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 5)
                        {
                             img = Image.FromFile(Img5);
                            btn[y][x].Image = img;
                            //     btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 6)
                        {
                             img = Image.FromFile(Img6);
                            btn[y][x].Image = img;
                            //    btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 7)
                        {
                             img = Image.FromFile(Img7);
                            btn[y][x].Image = img;
                            //    btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 8)
                        {
                             img = Image.FromFile(Img8);
                            btn[y][x].Image = img;
                            //     btn[y][x].Enabled = false;
                        }
                        else if (gameMine.Table.Table[x, y].Key == 10)
                        {
                             img = Image.FromFile(mineImg);
                            btn[y][x].Image = img;
                            //   btn[y][x].Enabled = false;
                        }

                    }
                }
            }

        }



        private void fácilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MinesweeperForm(1, gameMine.Player1.Name).Show();
        }

        private void médioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MinesweeperForm(2, gameMine.Player1.Name).Show();
        }

        private void difícilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MinesweeperForm(3, gameMine.Player1.Name).Show();
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

    }
}
