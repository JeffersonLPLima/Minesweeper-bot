using System;

namespace Minesweeper{
	public class Human : Player{
		public Human (String name) : base(name){
		}

		public override Position play (){
			Console.Write ("Linha: ");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.Write ("Coluna: ");
			int y = Convert.ToInt32(Console.ReadLine());

			Position pos = new Position (x, y);

			//Random random = new Random ();
			//Position pos = new Position (random.Next(0,8), random.Next(0,8));

			return pos;
		}
	}
}

