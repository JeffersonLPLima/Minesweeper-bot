﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper{
    public abstract class Player{
        private String name;
        private Position lastPosition;
		protected int bombsFound;
        protected GameTable tableBombsFound;

        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="name">Player name </param>
        /// <param name="rows"> number of rows of the table </param>
        /// <param name="columns">number of columns of the table</param>
		public Player(String name, int rows, int columns){
            LastPosition = new Position(0, 0);
			this.name = name;
            this.tableBombsFound = new GameTable(rows, columns);
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

        /// <summary>
        /// Performs a move in a random position
        /// </summary>
        /// <param name="table">Table.</param>
        public void randomPlay(GameTable table){
            Position pos;
            bool flag = false;
            while (!flag){
                pos = new Position(RandomUtil.getRandomNumber(0, table.Rows), RandomUtil.getRandomNumber(0, table.Columns));
                if (!table.Table[pos.X, pos.Y].Visited){
                    // Position not yet visited
                    LastPosition = pos;

                    play(table);
                    flag = true;
                }
            }
        }
    }
}
