using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;


namespace Minesweeper{

    ///<summary>
	/// Class to control the game
	/// </summary>
	public class Game{

		private GameTable table;
        private Player player1, player2;
        private int round;
        private byte difficulty;
        
		private bool active;
        
        public GameTable Table{
            get { return table; }
            set { table = value; }
        }

        public byte Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
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

        public int Round{
            get { return round; }
            set { round = value; }
        }

		public bool Active{
			get { return active; }
			set { active = value; }
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="Minesweeper.Game"/> class.
        /// </summary>
        /// <param name="player1">Player name</param>
        /// <param name="tableRows">Table rows.</param>
        /// <param name="tableColumns">Table columns.</param>
        public Game(String player1, byte difficulty, byte whoBegins)
        {

            int tableRows ;
            int tableColumns;
            if (whoBegins == 0)
                this.round= 1;
           
            if (difficulty == 1)
            {
                tableRows = 8;
                tableColumns = 8;
            }
            else if (difficulty == 2)
            {
                tableRows = 16;
                tableColumns = 16;
            }
            else
            {
                tableRows = 16;
                tableColumns = 30;
            }
			this.player1 = new Human(player1, tableRows, tableColumns);
			this.player2 = new Bot ("The B0T", tableRows, tableColumns);
            this.difficulty = difficulty;
            this.table = new GameTable(tableRows, tableColumns);
           

        }

		public void update(){
			Player player = getTurnPlayer(); //Current player

			Position pos = getPlayerMove(player);
           
			if (this.table.setPos (pos.X, pos.Y)) {
				//Console.Clear ();
				Console.WriteLine ("Ultima posicao jogada = X: "+pos.X+" Y: "+pos.Y);
                

                //this.Table.printMatrix ();
                MinesweeperForm.updateTable();

                //Console.WriteLine("Update 2");
                

				if(table.NodesRemaining == 0){
					Console.WriteLine ("Empate");
					Console.WriteLine ("Pressione qualquer tecla para continuar");
					//Console.ReadLine ();

					this.Table.showBombs ();
                    MinesweeperForm.showTableBombs();
                    active = false;
				}
			} else {
				//Console.Clear ();

//              MinesweeperForm.playWav();
                this.Table.showBombs ();
           
                MinesweeperForm.showTableBombs();
                //Console.WriteLine("Atualiza");
               // Console.Read();
               // MinesweeperForm.updateTable();
				Console.WriteLine ("Voce perdeu "+player.Name+"!");
				active = false;
			}

		}

		public void initialize(){
			//Initial table
			table.printMatrix();

			//First move
			Position pos = getPlayerMove (getTurnPlayer());

			//Console.Clear();
            table.bombFields (pos.Y,pos.Y);
			table.setNodeKeys ();
			table.expand(table.Table[pos.X, pos.Y]);

			table.printMatrix();
            //Console.WriteLine("Novo Tabuleiro");

            MinesweeperForm.updateTable();
           
			
		}

		public void run(){
         
          
            active = true;
			initialize ();
            
			while (active) {

                this.table.printMatrix();
                Console.WriteLine ("Bombas: "+this.table.Bombs);
		        Console.WriteLine ("Casas restantes: "+this.table.NodesRemaining);
				update ();
	}
		}

		public Player getTurnPlayer(){
			if (round % 2 == 0) {
				return player1;	
			} else {
				return player2;
			}
		}

        private Position getPlayerMove(Player player){

			Position pos;
            pos = player.play (this.Table);
            if (round % 2 != 0)
                Thread.Sleep(1000);
            this.round += 1;
			

			return pos;
		}
        
    }
}

