using System;

namespace Minesweeper{
    public class Human : Player{
        public Human(String name, int rows, int columns): base(name, rows, columns){
        }
        /// <summary>
        /// get Play
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public override Position play(GameTable table){
            bool flag = false;

            do{
                if (!table.Table[LastPosition.X, LastPosition.Y].Visited)
                    flag = true;
            }while (!flag);

            return LastPosition;
        }
    }
}

