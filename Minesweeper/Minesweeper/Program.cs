using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper{
    class Program{
        static void Main(string[] args){
			Game game = new Game ("Player1",7,7);
			game.run ();
        }
    }
}
