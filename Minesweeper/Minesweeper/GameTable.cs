using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace Minesweeper{
    class GameTable{
        private Node[,]table;
        private int bombs;
        private int bombs_Remaining;
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
            get { return Bombs; }
            set { Bombs = value; }
        }
      

        public GameTable(int rows, int columns){
            int k;
            this.rows = rows;
            this.columns = columns;
            this.table = new Node[rows, columns];
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < columns; j++){
                    this.table[i,j] = new Node();          
                }
            }

            for (int i = 0; i < rows; i++){
                //Console.WriteLine("i =  "+i);
				for (int j = 0; j < columns; j++){//para maior que um
                    // Console.WriteLine("j =  " + j);
                    k = 0;
                    for (int ii = i - 1; ii <= i + 1; ii++){
                        //Console.WriteLine("ii =  " + ii);
                        for (int jj = j - 1; jj <= j + 1; jj++){
                            Console.WriteLine("ii =  " + ii);
                            Console.WriteLine("jj =  " + jj);
                            //Console.ReadLine();
                            if (!((jj == j)&(ii == i))) {
                                if ((ii == -1) || (ii == this.Rows) || (jj == -1) || (jj == this.Columns )){
                                    this.table[i, j].Vizinhanca.Add(null);
                                }
                                else{
                                    Console.WriteLine("entrou");
                                    this.table[i, j].Vizinhanca.Add(this.table[ii, jj]);
                                    //Console.WriteLine(this.table[i, j].Vizinhanca.Count);
                                    //this.table[i,j].Vizinhanca[k] = this.table[ii,jj];
                                    //Console.WriteLine(this.table[i,j].Vizinhanca[k].Key);
                                }   
                            }

                            k += 1;
                            //Console.WriteLine(k);
                        }
                        //Console.WriteLine();
                    }
                }
            }
          
            this.bombs = (int)((rows * columns)*(15.0/100.0));
            this.nodesRemaining = (rows * columns) - this.bombs;

        }

        public void setNodeKeys() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    this.table[i, j].countBombs();
                }
            }
        }

        public void printMatrix(){
            for(int i = 0; i<rows; i++){
                for (int j = 0; j < columns; j++){
                    if (table[i, j].Visited) { 
                        Console.Write("| " + table[i, j].Key + " |");
                    }
                    else
                    {
                        Console.Write("|   |");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        public void bombFields(){
            Random random = new Random();
            int randomNumberRows;
            int randomNumberColumns;
            for(int i = 0; i<=bombs; i++){
                randomNumberRows = random.Next(0, Rows);
                randomNumberColumns = random.Next(0, Columns);
                this.table[randomNumberRows,randomNumberColumns].Key = 10;
            }
            this.table[5,5].Key = 10;
        }

        public void expand(Node node) {
            if (node != null && !node.Visited) {
                node.Visited = true;
                nodesRemaining -= 1;
                if(node.Key==0){
                    for (int i = 0; i < node.Vizinhanca.Count; i++) {
                        expand(node.Vizinhanca[i]);
                    }

                }
            }
        }

        public void showBombs(){
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < columns; j++){
                    if (table[i, j].Key == 10){
                        Console.Write("| " + table[i, j].Key + " |");
                    }
                    else{
                        Console.Write("|   |");
                    }

                }
                Console.WriteLine();
            }
        }



        /*public void expandClickpoint(Node point){
      
            if ((point != null && !point.Visited))
            {
                point.Visited = true;
                if (point.Key != 10)
                {
                    Console.WriteLine(point.Vizinhanca[1]);
                    for (int i = 1; i < 8; i++)
                    {
                        Console.WriteLine(point.Vizinhanca[i]);
                        if (point.Vizinhanca[i]!=null && point.Vizinhanca[i].Key < 10)
                        {
                            expandClickpoint(point.Vizinhanca[i]);
                            break;
                        }

                        Console.WriteLine(123);

                    }
                }
            }

        }*/
    }   
}


