using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper{
    public abstract class Player{
        private String name;
		protected int bombsFound;
        protected GameTable gameTableBombsFound;

		public Player(String name, int rows, int columns){
			this.name = name;
            this.gameTableBombsFound = new GameTable(rows, columns);
		}

		public String Name{
            get { return name; }
            set { name = value; }
        }

		abstract public Position play (GameTable table);
    }
}
