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
            this.player1 = new Player(player1);
            this.table = new GameTable(tableRows, tableColumns);
            this.lastRound = new int[2];
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
			Console.Write ("Linha: ");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.Write ("Coluna: ");
			int y = Convert.ToInt32(Console.ReadLine());

			Console.Clear();

			table.bombFields (x,y);
			table.setNodeKeys ();
			table.expand(table.Table[x, y]);

			table.printMatrix();
		}

		public void run(){
			active = true;
			initialize ();

			while (active) {
				Console.WriteLine ("Bombas: "+this.table.Bombs);
				Console.WriteLine ("Casas restantes: "+this.table.NodesRemaining);
				update ();

			}
			//unload ();
		}
    }
}

