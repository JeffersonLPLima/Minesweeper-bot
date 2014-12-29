using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper{
    class Program
    {

       public static void Main(string[] args)
        {
            //Console.WriteLine ("Pressione algo");
            //Console.ReadLine ();
            //Game game = new Game ("Player1",16,16);

            //game.run ();


            //Thread t = new Thread(new ThreadStart(Forms.Forms.RunForms));
            // t.Start();

            //MinesweeperForm frm = new MinesweeperForm(2, "Qwerty");
            //frm.RunMinesweeperForms (2, "Qwerty");
           
            Forms.Forms.RunForms();
           //Forms.AboutForm.runAboutForms();
        }
      

    }
}
