using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Game
    {
        private GameTable table;
        private Player player1, player2;
        private int round;
        private int[] lastRound;
        
        public GameTable Table
        {
            get { return table; }
            set { table = value; }
        }

        public Player Player1
        {
            get { return player1; }
            set { player1 = value; }
        }

        public Player Player2
        {
            get { return player2; }
            set { player2 = value; }
        }

        public int Round
        {
            get { return round; }
            set { round = value; }
        }
        public int[] LastRound
        {
            get { return lastRound; }
            set { lastRound = value; }
        }

        public Game(String player1, int tableRows, int tableColumns){
            this.player1 = new Player(player1);
            this.table = new GameTable(tableRows, tableColumns);
            this.lastRound = new int[2];

        }
        

        public bool toPlay(int x, int y){
            if ((x >= 0 && x<this.table.Rows) && (y>=0 && y<this.table.Columns)){
                if (!this.table.Table[x, y].Visited) { 
                    if (this.table.Table[x, y].Key != 10) {
                       this.Table.expand(this.table.Table[x,y]);
                    }else{
                       this.Table.showBombs();
                       
                    }
                    this.round+=1;
                    this.lastRound[0]= x;
                    this.lastRound[1]= y;  
                }
            }
            return false;
        }

        public void Update(){
            //Player1
            if (this.round%2==0){
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                this.toPlay(x, y);
            }
            else { 
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
               
                this.toPlay(x, y);
                
            }
        }
   

        

    }
}

