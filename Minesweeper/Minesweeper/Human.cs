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
            Position lastPosition = LastPosition;
            //Random random = new Random ();
            //Position pos = new Position (random.Next(0,8), random.Next(0,8));
            //   Console.WriteLine("Human jogou:" + lastPosition.X + lastPosition.Y);

            return lastPosition;
        }
    }
}
