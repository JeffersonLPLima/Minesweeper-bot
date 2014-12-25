using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper{
    public abstract class Player{
        private String name;
		private bool[,]tableBombsFound;
		private int bombsFound;

		public Player(String name){
			this.name = name;
		}

		public String Name{
            get { return name; }
            set { name = value; }
        }
        
		public bool[,] TableBombsFound{
			get { return tableBombsFound; }
			set { tableBombsFound = value; }
		}

		public int BombsFound{
			get { return bombsFound; }
			set { bombsFound = value; }
		}

		abstract public Position play ();
    }
}
