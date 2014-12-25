using System;

namespace Minesweeper{
	public class Bot: Player{
	
		public Bot (String name) : base(name){
		}

		public override Position play (){
			Position pos = new Position (RandomUtil.GetRandomNumber(0,8), RandomUtil.GetRandomNumber(0,8));
			Console.ReadLine ();
			return pos;
		}
	}
}

