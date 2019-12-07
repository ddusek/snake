using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Snake {
	class Matrix3x3 {
		public string[,] Matrix;

		// return matrix of neighbors (3x3)
		// borders (walls) = "[]", no walls are returned as in gameArea.matrix
		public void GetNeighbors(GameArea gameArea, int x, int y) {
			string[,] neighbors = new string[3,3];
			for (int NX = 0; NX < 3; NX++) {
				for (int NY = 0; NY < 3; NY++) {
					if ((NX == 0 && x == 0) || (NX == 2 && x == gameArea.LenX-1)) {
						neighbors[NX, NY] = gameArea.Wall;
					}
					else if ((NY == 0 && y == 0) || (NY == 2 && y == gameArea.LenY - 1)) {
						neighbors[NX, NY] = gameArea.Wall;
					}
					else {
						neighbors[NX, NY] = gameArea.Matrix[x + NX - 1, y + NY - 1];
					}
				}
			}
			this.Matrix = neighbors;
		}

		//return bools if there are walls in order - top, bot, left, right
		public Tuple<bool, bool, bool, bool> CheckWalls(GameArea gameArea) {
			bool top = IsWallTop(gameArea);
			bool bot = IsWallBot(gameArea);
			bool left = IsWallLeft(gameArea);
			bool right = IsWallRight(gameArea);
			return Tuple.Create(top, bot, left, right);
		}

		public bool IsWallTop(GameArea gameArea) {
			if (Matrix[1, 0] != gameArea.Empty || Matrix[1,0] != gameArea.Candy) {return true;}
			return false;
		}

		public bool IsWallBot(GameArea gameArea) {
			if (Matrix[1, 2] != gameArea.Empty || Matrix[1,2] != gameArea.Candy) { return true; }
			return false;
		}

		public bool IsWallLeft(GameArea gameArea) {
				if (Matrix[0, 1] != gameArea.Empty || Matrix[0,1] != gameArea.Candy) { return true; }
			return false;
		}

		public bool IsWallRight(GameArea gameArea) {
				if (Matrix[2, 1] != gameArea.Empty || Matrix[2, 1] != gameArea.Candy) { return true; }
			return false;
		}
	}
}
