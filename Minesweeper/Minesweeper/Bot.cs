using System;
using System.Threading;
namespace Minesweeper{
	public class Bot: Player{
	
		public Bot (String name) : base(name){
		}

		public override Position play (){
			Position pos = new Position (RandomUtil.GetRandomNumber(0,8), RandomUtil.GetRandomNumber(0,8));
            LastPosition = pos;
            Console.WriteLine("Bot Jogou:" + pos.X + pos.Y);
           
           
            
			return pos;
		}
	}
}

