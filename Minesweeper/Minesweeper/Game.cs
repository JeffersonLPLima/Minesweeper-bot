using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper{

	/// <summary>
	/// Class to control the game
	/// </summary>
	public class Game{

		private GameTable table;
        private Player player1, player2;
        private int round;
        private int[] lastRound;
		private bool active;
        
        public GameTable Table{
            get { return table; }
            set { table = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Minesweeper.Game"/> class.
        /// </summary>
        /// <param name="player1">Player name</param>
        /// <param name="tableRows">Table rows.</param>
        /// <param name="tableColumns">Table columns.</param>
        public Game(String player1, int tableRows, int tableColumns){
			this.player1 = new Human(player1, tableRows, tableColumns);
			this.player2 = new Bot ("B0T M4sT3R", tableRows, tableColumns);

            this.table = new GameTable(tableRows, tableColumns);
            this.lastRound = new int[2];
        }

		public void update2(){
			Player player = getTurnPlayer(); //Current player

			Position pos = move(player);

			if (this.table.setPos (pos.X, pos.Y)) {
				Console.Clear ();
				Console.WriteLine ("Ultima posicao jogada = X: "+pos.X+" Y: "+pos.Y);
				this.Table.printMatrix ();

				if(table.NodesRemaining == 0){
					Console.WriteLine ("Empate");
					Console.WriteLine ("Pressione qualquer tecla para continuar");
					Console.ReadLine ();

					this.Table.showBombs ();

					active = false;
				}
			} else {
				Console.Clear ();
				this.Table.showBombs ();
				Console.WriteLine ("Voce perdeu "+player.Name+"!");
				active = false;
			}
		}

		public void initialize(){
			//Initial table
			table.printMatrix();

			//First move
			Position pos = move (getTurnPlayer());

			Console.Clear();

			table.bombFields (pos.Y,pos.Y);
			table.setNodeKeys ();
			table.expand(table.Table[pos.X, pos.Y]);

			table.printMatrix();
		}

		public void run(){
			active = true;
			initialize ();

			while (active) {
				Console.WriteLine ("Bombas: "+this.table.Bombs);
				Console.WriteLine ("Casas restantes: "+this.table.NodesRemaining);
				update2 ();

			}
		}

		public Player getTurnPlayer(){
			if (round % 2 == 0) {
				return player1;	
			} else {
				return player2;
			}
		}

		private Position move(Player player){
			bool flag = false;
			Position pos;

			do {
				pos = player.play (this.table);
				Console.Write ("Linha: "+pos.X);
				Console.Write ("Coluna: "+pos.Y);
				Console.WriteLine("");

				if (((pos.X >= 0 && pos.X < this.table.Rows) && (pos.Y >= 0 && pos.Y < this.table.Columns)) && 
				    (!this.table.Table [pos.X, pos.Y].Visited)) {
					flag = true;
				}
			} while(!flag);

			this.round += 1;
			this.lastRound[0] = pos.X;
			this.lastRound [1] = pos.Y;

			return pos;
		}
    }
}

