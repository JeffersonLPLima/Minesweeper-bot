using System;

namespace Minesweeper{
	public class Position{

		private int x;
		private int y;
        private int numero;
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public int getNumero()
        {
            numero += 1;
            return numero;
        }
        public int quadrado(int x)
        {
            if (false)
            {
                Console.WriteLine("Numero: " + x);
            }
            return numero * numero;
        }
		public int X{
			get { return x; }
			set { x = value; }
		}

		public int Y{
			get { return y; }
			set { y = value; }
		}

		public Position (int x, int y){
			this.x = x;
			this.y = y;
		}
	}
}
