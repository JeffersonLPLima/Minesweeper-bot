using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            
            InitializeComponent();
            
        }
        public static void runAboutForms(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AboutForm());
        }
    }
}
