using System;

namespace Minesweeper{
    public class Human : Player{
        public Human(String name, int rows, int columns): base(name, rows, columns){
        }

        public override Position play(GameTable table){
            Position lastPosition = LastPosition;
            return lastPosition;
        }
    }
}
