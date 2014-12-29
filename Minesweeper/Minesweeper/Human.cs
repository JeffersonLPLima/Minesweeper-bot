using System;

namespace Minesweeper
{
    public class Human : Player
    {
        public Human(String name, int rows, int columns)
            : base(name, rows, columns)
        {
        }

        public override Position play(GameTable table)
        {

            /*
            Console.Write ("Linha: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write ("Coluna: ");
            int y = Convert.ToInt32(Console.ReadLine());

            Position lastPosition = LastPosition;
            //Random random = new Random ();
            //Position pos = new Position (random.Next(0,8), random.Next(0,8));
            //Console.WriteLine("Human jogou:" + lastPosition.X + lastPosition.Y);

            Position pos = new Position (x, y);
            return pos;
            */

            Position lastPosition = LastPosition;
            return lastPosition;
        }
    }
}
