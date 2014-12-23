using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Node{
        private List<Node> vizinhanca;
        //private Node[] vizinhanca;
        private bool visited;
        private int key;

        public List<Node> Vizinhanca
        {
            get { return vizinhanca; }
            set { vizinhanca = value; }
        }
        /*public Node[] Vizinhanca
        {
            get { return vizinhanca; }
            set { vizinhanca = value; }
        }*/
        
        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
        public Node()
        {
            this.key = -1;
            this.vizinhanca = new List<Node>();
        }

        public void countBombs(){
            int count = 0;
            for (int i = 0; i < 8; i++){
                if (this.vizinhanca[i] != null && this.vizinhanca[i].key==10) {
                    count += 1;
                }
            }
            if (this.key != 10) {
                this.key = count;
            }
        }//no.countBombs()
        /*public Node()
        {
            this.key = -1;
            this.vizinhanca = new Node[8];

            for (int i = 0; i < this.vizinhanca.Length; i++)
            
                this.vizinhanca[i] = new Node();
            }
        }
        public Node(int key)
        {
            this.key = key;
            this.vizinhanca = new Node[8];

            for (int i = 0; i < this.vizinhanca.Length; i++)
            {
                this.vizinhanca[i] = new Node();
            }
        }*/
    }
}
