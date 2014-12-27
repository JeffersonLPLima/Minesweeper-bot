using System;

namespace Minesweeper{
	public class Human : Player{
		public Human (String name,int rows, int columns) : base(name, rows, columns){
		}

		public override Position play (GameTable table){
			Console.Write ("Linha: ");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.Write ("Coluna: ");
			int y = Convert.ToInt32(Console.ReadLine());

			Position pos = new Position (x, y);

			return pos;
		}
	}
}

