using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper{
    class Game{

        private GameTable table;
        private Player player1, player2;
        private int round;
        private int[] lastRound;
		private bool active;
        
        public GameTable Table{
            get { return table; }
            set { table = value; }
        }

        public Player Player1{
            get { return player1; }
            set { player1 = value; }
        }

        public Player Player2{
            get { return player2; }
            set { player2 = value; }
        }

        public int Round{
            get { return round; }
            set { round = value; }
        }

        public int[] LastRound{
            get { return lastRound; }
            set { lastRound = value; }
        }

		public bool Active{
			get { return active; }
			set { active = value; }
		}

        public Game(String player1, int tableRows, int tableColumns){
            this.player1 = new Human(player1);
			this.player2 = new Bot ("B0T M4sT3R");

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

        public void update(){
			int x, y;
			bool flag=false;

			do {
				Console.Write ("Linha: ");
				x = Convert.ToInt32(Console.ReadLine());
				Console.Write ("Coluna: ");
				y = Convert.ToInt32(Console.ReadLine());

				if (((x >= 0 && x < this.table.Rows) && (y >= 0 && y < this.table.Columns)) && 
					(!this.table.Table [x, y].Visited)) {
					flag = true;
				}else{
					Console.WriteLine("Posicao inválida! Por favor, informe outra");
				}
			} while(!flag);

			if (this.table.setPos (x, y)) {
				this.round+=1;
				this.lastRound[0]= x;
				this.lastRound[1]= y;

				Console.Clear ();
				this.Table.printMatrix ();

				if(table.NodesRemaining == 0){
					Console.WriteLine ("Voce ganhou!");
					Console.WriteLine ("Pressione qualquer tecla para continuar");
					Console.ReadLine ();
	
					this.Table.showBombs ();

					active = false;
				}
			} else {
				Console.Clear ();
				this.Table.showBombs ();
				Console.WriteLine ("Voce perdeu!");
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
			//unload ();
		}

		public Player getTurnPlayer(){
			if (round % 2 == 0) {
				return player1;	
			} else {
				return player2;
			}
		}

		private Position move(Player player){
			//Player player = getTurnPlayer(); //Current player

			bool flag = false;
			Position pos;
			do {
				pos = player.play ();
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

