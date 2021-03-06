﻿using System;
using System.Collections.Generic;

namespace Minesweeper{
    public class Node{
        private List<Node> neighborhood;
        private bool visited;
        private int key;
        private bool isFlagged;
        private float probBomb;
        
        public List<Node> Neighborhood{
            get { return neighborhood; }
            set { neighborhood = value; }
        }

        public bool IsFlagged{
            get { return isFlagged; }
            set { isFlagged = value; }
        }

        public int Key{
            get { return key; }
            set { key = value; }
        }

        public bool Visited{
            get { return visited; }
            set { visited = value; }
        }

        public float ProbBomb{
            get { return probBomb; }
            set { probBomb = value; }
        }

        public Node(){
            this.isFlagged = false;
            this.key = -1;
            this.neighborhood = new List<Node>();
        }

        /// <summary>
        /// Counts the adjacent bombs to this node
        /// </summary>
        public void countBombs(){
            int bombs = 0;

			if (this.key != 10) {
                for (int i = 0; i < neighborhood.Count; i++){
	                if (this.neighborhood[i] != null && this.neighborhood[i].key==10) {
	                    bombs += 1;
	                }
	            }
 
                this.key = bombs;
            }
        }

        /// <summary>
        /// Gets a list of not yet visited Nodes
        /// </summary>
        /// <returns>The neighborhood visible.</returns>
		public List<Node> getVisibleNeighborhood(){
			List<Node> neighborhoodVisible = new List<Node>();

			for (int i = 0; i < this.neighborhood.Count; i++) {
				if(this.neighborhood[i]!=null && !this.neighborhood[i].Visited){
					neighborhoodVisible.Add(this.neighborhood[i]);
				}
			}
			return neighborhoodVisible;
		}

        /// <summary>
        /// Gets the adjacent node position.
        /// </summary>
        /// <returns>The neighborhood position.</returns>
        /// <param name="adjacent">Adjacent.</param>
        /// <param name="pos">Position.</param>
        public Position getNeighborhoodPosition(Node adjacent, Position pos){
            if (this.neighborhood [0] != null && this.neighborhood[0].Equals (adjacent)) {
                return new Position (pos.X - 1, pos.Y - 1);
            } else if (this.neighborhood [1] != null && this.neighborhood [1].Equals (adjacent)) {
                return new Position (pos.X - 1, pos.Y);
            } else if (this.neighborhood [2] != null && this.neighborhood [2].Equals (adjacent)) {
                return new Position (pos.X - 1, pos.Y + 1);
            } else if (this.neighborhood [3] != null && this.neighborhood [3].Equals (adjacent)) {
                return new Position (pos.X, pos.Y - 1);
            } else if (this.neighborhood [4] != null && this.neighborhood [4].Equals (adjacent)) {
                return new Position (pos.X, pos.Y + 1);
            } else if (this.neighborhood [5] != null && this.neighborhood [5].Equals (adjacent)) {
                return new Position (pos.X + 1, pos.Y - 1);
            } else if (this.neighborhood [6] != null && this.neighborhood [6].Equals (adjacent)) {
                return new Position (pos.X + 1, pos.Y);
            } else if (this.neighborhood [7] != null && this.neighborhood [7].Equals (adjacent)) {
                return new Position (pos.X + 1, pos.Y + 1);
            } else {
                return null;
            }
        }
    }
}
