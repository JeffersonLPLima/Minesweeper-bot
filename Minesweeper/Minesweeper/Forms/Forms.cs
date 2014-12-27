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
        int difficulty;
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
            if (radioButtonFacil.Checked) difficulty = 1;
            
            else if (radioButtonNormal.Checked) difficulty = 2;
            
            else if (radioButtonDificil.Checked) difficulty = 3;
            
            else difficulty = 1;

            if (textBox1.Text != "")
            {
                this.Hide();
                MinesweeperForm frm = new MinesweeperForm(difficulty, name);
                frm.Show();

            }
            else
            {
                this.Hide();
                MinesweeperForm frm = new MinesweeperForm(difficulty, "unnamed");
                frm.Show();
            }
       }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }
    }
}
