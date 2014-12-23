using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args){
            Node teste = new Node();
            int parada = teste.Key;
            Console.WriteLine(parada);
            GameTable test = new GameTable(7, 7);
            test.printMatrix();
            //Console.ReadLine();
            test.bombFields();
            test.printMatrix();
            //Console.ReadLine();
            //test.expandClickpoint(test.Table[3,3]);
            test.printMatrix();
            //Console.WriteLine("Vizinho: "+test.Table[8,0].Vizinhanca[2].Key);
            //Console.WriteLine("Vizinho2: " + test.Table[4, 4].Vizinhanca[2].Key);
            //Console.WriteLine("Vizinho2: " + test.Table[0, 0].Vizinhanca.Count);
            //Console.ReadLine();
            test.setNodeKeys();
            test.printMatrix();
            //Console.ReadLine();
            //Console.Clear();
            while (true){
                
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                test.expand(test.Table[a, b]);
                test.printMatrix();
            }
            

       
        }
    }
}
