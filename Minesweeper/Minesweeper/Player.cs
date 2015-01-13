using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper{
    public abstract class Player{
        private String name;
        private Position lastPosition;
		protected int bombsFound;
        protected GameTable gameTableBombsFound;

        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="name">Player name </param>
        /// <param name="rows"> number of rows of the table </param>
        /// <param name="columns">number of columns of the table</param>
		public Player(String name, int rows, int columns){
            LastPosition = new Position(0, 0);
			this.name = name;
            this.gameTableBombsFound = new GameTable(rows, columns);
		}

        public Position LastPosition{
            get { return lastPosition; }
            set { lastPosition = value; }
        }

		public String Name{
            get { return name; }
            set { name = value; }
        }

		abstract public Position play (GameTable gameTable);
    }
}
