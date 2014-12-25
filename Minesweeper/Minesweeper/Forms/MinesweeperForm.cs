using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
       /// <summary>
       /// Image Locations
       /// </summary>
       private static String noDesmImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/casaInativa.JPG";
       private static String noMarcImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/casaAtiva.JPG";
       private static String Img1 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/1.JPG";
       private static String Img2 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/2.JPG";
       private static String Img3= "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/3.JPG";
       private static String Img4 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/4.JPG";
       private static String Img5 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/5.JPG";
       private static String Img6 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/6.JPG";
       private static String Img7 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/7.JPG";
       private static String Img8 = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/8.JPG";
       private static String mineImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/mina.jpg";
       private static String flagImg = "C:/Users/Jefferson Luiz/Desktop/Rep-Minesweeper/minesweeper-plp/Minesweeper/Minesweeper/Forms/Images/flag.JPG";

       Game gameMine;
        
        public MinesweeperForm()
        {
            gameMine = new Game("Player1", 7, 7);
            gameMine.run();
            InitializeComponent();
        }

       

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do jogo ?", "Minesweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void botao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do jogo ?", "Minesweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Name); // imprime no Console o nome do botão clicado
        }

        private void MinesweeperForm_Load(object sender, EventArgs e)
        {
            int matrizX = gameMine.Table.Rows;
            int matrizY = gameMine.Table.Columns;
        //  int  matrizX = 32;
       // int matrizY = 32;
          Image img = Image.FromFile(noDesmImg);
            panelMatriz.Size = new Size(25 * matrizX, 25 * matrizY);
            panelMatriz.Visible = true;
            Button[][] btn = new Button[matrizX][];
            for (int x = 0; x < matrizX; x++)
            {
                btn[x] = new Button[matrizY];
                for (int y = 0; y < matrizY; y++)
                {
                    btn[x][y] = new Button();
                    btn[x][y].Name = Convert.ToString("casa" + x + "," + y);
                    btn[x][y].AccessibleName = "casa";
                    btn[x][y].Size = new Size(25, 25);
                 

                    btn[x][y].Image = img;
                  
                    btn[x][y].Visible = true;
                    btn[x][y].Location = new Point(x * 25, y * 25);
                    btn[x][y].Click += new EventHandler(this.btnEvent_Click);
                    panelMatriz.Controls.Add(btn[x][y]);
                    

                }
            }
        }




        static void Main(string[] args)
        {



           // Game game = new Game("Player1", 7, 7);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MinesweeperForm());
        
      //      game.run();
        }

        
     
        
    }
}
