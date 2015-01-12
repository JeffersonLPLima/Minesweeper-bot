using System;

namespace Minesweeper{
	public class Position{

		private int x;
		private int y;
        public int X{
			get { return x; }
			set { x = value; }
		}

		public int Y{
			get { return y; }
			set { y = value; }
		}
        /// <summary>
        /// Builder of Position
        /// </summary>
        /// <param name="x"> position X</param>
        /// <param name="y"> position Y</param>
		public Position (int x, int y){
			this.x = x;
			this.y = y;
		}
	}
}
