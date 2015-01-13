using System;
using System.Collections.Generic;

namespace Minesweeper{
    public class GameTable{
        private Node[,]table;
        private int bombs;
        private int rows;
        private int columns;
        private int nodesRemaining;       

        public Node[,] Table{
            get { return table; }
            set { table = value; }
        }
      
		public int Columns{
            get { return columns; }
            set { columns = value; }
        }

        public int Rows{
            get { return rows; }
            set { rows = value; }
        }
        
        public int Bombs { 
            get { return bombs; }
            set { bombs = value; }
        }

		public int NodesRemaining { 
			get { return nodesRemaining; }
			set { nodesRemaining = value; }
		}

        public GameTable(int rows, int columns){

            this.rows = rows;
            this.columns = columns;
            this.table = new Node[rows, columns];

            // Instantiates the node matrix
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < columns; j++){
                    this.table[i,j] = new Node();          
                }
            }


            for (int i = 0; i < rows; i++){
				for (int j = 0; j < columns; j++){
                    int k = 0;
                    for (int ii = i - 1; ii <= i + 1; ii++){
                        for (int jj = j - 1; jj <= j + 1; jj++){
                            if (!((jj == j)&(ii == i))) {
                                if ((ii == -1) || (ii == this.Rows) || (jj == -1) || (jj == this.Columns )){
                                    this.table[i, j].Neighborhood.Add(null);
                                }
                                else{
                                    this.table[i, j].Neighborhood.Add(this.table[ii, jj]);
                                }   
                            }

                            k += 1;
                        }
                    }
                }
            }
          
            this.bombs = (int)((rows * columns)*(15.0/100.0));
            this.nodesRemaining = (rows * columns) - this.bombs;

        }

        /// <summary>
        /// Sets key for each node at the matrix
        /// </summary>
        public void setNodeKeys() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    this.table[i, j].countBombs();
                }
            }
        }

        /// <summary>
        /// Prints the atual state of the matrix on the Console
        /// </summary>
        public void printMatrix(){
			Console.WriteLine ("======== Campo Minado ========");
			Console.Write ("  ]");
			for (int j = 0; j < columns; j++) {
				Console.Write ("| "+(j%10)+" |");	
			}
			Console.WriteLine ();

			for(int i = 0; i<rows; i++){
                if(i<10){
                    Console.Write ("0");
                }
                Console.Write(i + "]");
				for (int j = 0; j < columns; j++){
					if (table [i, j].Visited) { 
						Console.Write ("| " + table [i, j].Key + " |");
					} else {
						Console.Write ("|   |");
					}
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Fills the fields with bombs.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public void bombFields(int x, int y){
            int randomNumberRows;
            int randomNumberColumns;

            for(int i = 0; i<bombs; i++){
				bool flag = false;
				while(!flag){
					randomNumberRows = RandomUtil.GetRandomNumber (0, Rows);
					randomNumberColumns = RandomUtil.GetRandomNumber (0, Columns);

					if (this.table [randomNumberRows, randomNumberColumns].Key != 10 &&
					    (randomNumberRows != x && randomNumberColumns!=y)) {
						flag = true;
						this.table[randomNumberRows,randomNumberColumns].Key = 10;
					}
				}
            }
        }

        /// <summary>
        /// Expands the move on the board
        /// </summary>
        /// <param name="node">Node.</param>
        public void expand(Node node) {
            if (node != null && !node.Visited) {
                node.Visited = true;
				this.nodesRemaining -= 1;
                if(node.Key==0){
                    for (int i = 0; i < node.Neighborhood.Count; i++) {
                        expand(node.Neighborhood[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Shows the bombs on Console
        /// </summary>
        public void showBombs(){
			Console.WriteLine ("======== Campo Minado ========");
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < columns; j++){
                    if (table[i, j].Key == 10 || table[i,j].Visited){
						if (table [i, j].Key != 10) {
							Console.Write ("| " + table [i, j].Key + " |");
						} else {
							Console.Write("| * |");
						}
                    }
                    else{
                        Console.Write("|   |");
                    }

                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Sets the move position on the board
        /// </summary>
        /// <returns><c>true</c>, if position was set, <c>false</c> otherwise.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
		public bool setPos(int x, int y){
			if (this.table[x, y].Key != 10) {
				this.expand(this.table[x,y]);

				return true;
			}

			return false;
		}
    }   
}
