using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Minesweeper.Forms
{
    public partial class Forms : Form
    {
        
        String name;

        public Forms()
        {
            InitializeComponent();
        }

        public static void RunForms()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Forms());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do jogo ?", "Minesweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte difficulty;
            if (radioButtonFacil.Checked) difficulty = 1;
            
            else if (radioButtonNormal.Checked) difficulty = 2;
            
            else if (radioButtonDificil.Checked) difficulty = 3;
            
            else difficulty = 1;

            if (textBox1.Text != "")
            {

               byte whoBegins = (byte)RandomUtil.GetRandomNumber(0, 2);
                this.Hide();
                MinesweeperForm frm = new MinesweeperForm(difficulty, name, whoBegins);

                frm.Show();

            }
            else
            {
               byte whoBegins = (byte)RandomUtil.GetRandomNumber(0, 2);

                this.Hide();
                MinesweeperForm frm = new MinesweeperForm(difficulty, "unnamed", whoBegins);
                frm.Show();
            }
       }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }
    }
}
