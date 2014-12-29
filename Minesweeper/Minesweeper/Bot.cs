using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Bot : Player
    {

        public Bot(String name, int rows, int columns): base(name, rows, columns)
        {
        }

        public override Position play(GameTable table)
        {
            this.bombsVisible(table); //1-FN

            this.printMatrixBombs();

            Position pos = getInferredPosition(table); //2-FN

            if (pos == null)
            {
                /*Console.WriteLine("Nao encontrou!");
                bool flag = false;
                while (!flag)
                {
                    pos = new Position(RandomUtil.GetRandomNumber(0, table.Rows), RandomUtil.GetRandomNumber(0, table.Columns));
                    Console.WriteLine("Posição sorteada = X: " + pos.X + " Y: " + pos.Y);
                    if (this.gameTableBombsFound.Table[pos.X, pos.Y].Key != 10){
                        flag = true;
                    }
                }*/
                
                return getBestGuess(table);
            }

            Console.WriteLine ("Bot Jogou na posicao X:"+pos.X+", Y: "+pos.Y);

            return pos;
        }

        public void printMatrixBombs()
        {
            Console.WriteLine("======== Campo Minado ========");
            Console.Write("  ]");
            for (int j = 0; j < this.gameTableBombsFound.Columns; j++)
            {
                Console.Write("| " + (j%10) + " |");
            }
            Console.WriteLine();

            for (int i = 0; i < this.gameTableBombsFound.Rows; i++)
            {   
                if(i<10){
                    Console.Write ("0");
                }
                Console.Write(i + "]");
                for (int j = 0; j < this.gameTableBombsFound.Columns; j++)
                {
                    if (this.gameTableBombsFound.Table[i, j].Key == 10)
                    {
                        Console.Write("| * |");
                    }
                    else
                    {
                        Console.Write("|   |");
                    }
                }
                Console.WriteLine();
            }
        }

        //1FN
        private void bombsVisible(GameTable table){

            for (int i = 0; i < table.Rows; i++){
                for (int j = 0; j < table.Columns; j++){
                     
                    if (table.Table[i, j].Visited && table.Table[i, j].Key != 0){

                        // Get a list of visible adjacents nodes  (neighborhood)
                        List<Node> neighborhoodVisible = table.Table[i, j].getNeighborhoodVisible();

                        // There is at least one adjacent node
                        if (neighborhoodVisible.Count > 0){
                            if (table.Table[i, j].Key == neighborhoodVisible.Count){
                                for (int k = 0; k < neighborhoodVisible.Count; k++){

                                    //Get neighborhood position
                                    Position posBomb = table.Table[i, j].getNeighborhoodPosition(neighborhoodVisible[k], new Position(i, j));

                                    if (posBomb != null){
                                        //Bomb found
                                        this.gameTableBombsFound.Table[posBomb.X, posBomb.Y].Key = 10;
                                        this.bombsFound += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private int getMarkedBombs(Position pos)
        {
            Node node = this.gameTableBombsFound.Table[pos.X, pos.Y];
            int bombs = 0;

            for (int i = 0; i < node.Neighborhood.Count; i++)
            {
                if (node.Neighborhood[i] != null && node.Neighborhood[i].Key == 10)
                {
                    bombs += 1;
                }
            }

            return bombs;
        }

        //2FN
        private Position getInferredPosition(GameTable table)
        {
            for (int i = 0; i < table.Rows; i++)
            {
                for (int j = 0; j < table.Columns; j++)
                {
                    if (table.Table[i, j].Visited && table.Table[i, j].Key != 0)
                    {

                        // Get the amount of bombs marked on the neighborhood
                        int markedBombs = getMarkedBombs(new Position(i, j));

                        if (markedBombs >= table.Table[i, j].Key)
                        {
                            Node node = this.gameTableBombsFound.Table[i, j];

                            for (int k = 0; k < node.Neighborhood.Count; k++)
                            {

                                // Get neighborhood position 
                                Position pos = this.gameTableBombsFound.Table[i, j].getNeighborhoodPosition(node.Neighborhood[k], new Position(i, j));

                                if ((pos != null) && (!table.Table[pos.X, pos.Y].Visited && node.Neighborhood[k].Key != 10))
                                {
                                    // Found a safe position
                                    Console.WriteLine("Retornou posicao = X: " + pos.X + ", Y:" + pos.Y);

                                    return new Position(pos.X, pos.Y);
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        //3FN
        private Position getBestGuess(GameTable table){
            Console.WriteLine ("<< 3FN >>");

            // Position with lower probability
            Position bestPosBomb = null;

            // Lower probability to contain bombs
            float bestProbBomb = float.MaxValue;

            // Probability to have bombs for a general case
            float probBombGeneral = ((float)table.Bombs) / (table.NodesRemaining + table.Bombs);
            Console.WriteLine ("ProbBombGeneral: "+probBombGeneral);

            for (int i = 0; i < table.Rows; i++) {
                for (int j = 0; j < table.Columns; j++) {
                    // Get current node
                    Node node = table.Table [i, j];

                    // Probability to have bombs for a general case
                    float probBomb = ((float)table.Bombs) / (table.NodesRemaining + table.Bombs);

                    // Current position
                    Position posBomb = new Position (i, j);

                    //Marked position with bomb
                    if (this.gameTableBombsFound.Table [i, j].Key == 10) {
                        probBomb = 100;
                        node.ProbBomb = probBomb;
                    }else if (node.Visited) {
                        if (node.Key != 0) {
                            // Get a list of visible adjacents nodes  (neighborhood)
                            List<Node> neighborhoodVisible = node.getNeighborhoodVisible ();
                     
                            // There is at least one adjacent node
                            if (neighborhoodVisible.Count > 0) {

                                if (node.Key != neighborhoodVisible.Count) { // There is at least one node without bomb
                                    probBomb = (((float)node.Key) - getMarkedBombs (posBomb)) / neighborhoodVisible.Count;
                                }else { // All adjacent nodes are bombs
                                    probBomb = 100;
                                }

                                for (int k = 0; k < neighborhoodVisible.Count; k++) {
                                    //Get neighborhood position
                                    Position posN = node.getNeighborhoodPosition (neighborhoodVisible [k], posBomb);
                                    Console.Write ("Posicao X: "+posN.X+", Y: "+posN.Y);
                                    Console.WriteLine ("ProbBomb: "+probBomb);

                                    if (posN != null && table.Table [posN.X, posN.Y].ProbBomb != 100 && 
                                       (table.Table [posN.X, posN.Y].ProbBomb == 0 || probBomb == probBombGeneral ||
                                        probBomb < table.Table [posN.X, posN.Y].ProbBomb)) {

                                        // Updates the probability to contain a bomb
                                        table.Table [posN.X, posN.Y].ProbBomb = probBomb;

                                        if (table.Table [posN.X, posN.Y].ProbBomb < bestProbBomb) {
                                            bestPosBomb = posN; // Lower probability to contain bombs
                                            bestProbBomb = probBomb; // Position with lower probability
                                        }
                                    }
                                }
                            }
                        }
                    }else{ 
                        if (node.ProbBomb == 0) { // Not visited nodes 
                            node.ProbBomb = probBomb;
                        }
                        if (node.ProbBomb < bestProbBomb) { 
                            bestPosBomb = posBomb; // Position with lower probability
                            bestProbBomb = node.ProbBomb; // Lower probability to contain bombs 
                        }
                    }
                }
            }

            Console.WriteLine ("Menor probabilidade: "+bestProbBomb);
            Console.WriteLine ("3FN Retornou posicao X:"+bestPosBomb.X+", Y:"+bestPosBomb.Y);
            return bestPosBomb;
        }
    }
}
