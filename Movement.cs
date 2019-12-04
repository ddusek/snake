using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Snake {
	class Movement {
		string[,] neighbors;
		string wall = "[]";

		public ConsoleKey GetKey() {
			var keyinfo = Console.ReadKey();
			return keyinfo.Key;
		}

		//move everything needed in gamearea
		public void Move(GameArea gameArea) {
			ConsoleKey pressedKey = GetKey();
			for (int x = 0; x < gameArea.lenX; x++) {
				for (int y = 0; y < gameArea.lenY; y++) {
					string symbol = gameArea.matrix[x, y];

					// only if box isn't empty
					if (symbol != gameArea.empty) {
						// change head to body
						if (symbol == gameArea.snakeHead) {
							gameArea.matrix[x, y] = gameArea.snakeBody;
						}
						// remove last body box
						else if (gameArea.matrix[x,y] == gameArea.snakeBody) {
							MoveBodyBox(gameArea.matrix, x ,y);
						}
					}
				}
			}
		}

		// return matrix of neighbors (3x3)
		// borders (walls) = "[]", no walls are returned as in gameArea.matrix
		public void GetNeighbors(GameArea gameArea, int x, int y) {
			string[,] neighbors = new string[3,3];
			for (int NX = 0; NX < 3; NX++) {
				for (int NY = 0; NY < 3; NY++) {
					if ((NX == 0 && x == 0) || (NX == 2 && x == gameArea.lenX-1)) {
						neighbors[NX, NY] = wall;
					}
					else if ((NY == 0 && y == 0) || (NY == 2 && y == gameArea.lenY - 1)) {
						neighbors[NX, NY] = wall;
					}
					else {
						neighbors[NX, NY] = gameArea.matrix[x + NX - 1, y + NY - 1];
					}
				}
			}
			this.neighbors = neighbors;

		}
		public void MoveBodyBox(string[,] matrix, int x, int y) {

		}

		//return bools if there are walls in order - top, bot, left, right
		public Tuple<bool, bool, bool, bool> CheckWalls() {
			bool top = IsWallTop();
			bool bot = IsWallBot();
			bool left = IsWallLeft();
			bool right = IsWallRight();
			return Tuple.Create(top, bot, left, right);
			


		}

		public bool IsWallTop() {
			if (neighbors[1, 0] == wall) {return true;}
			return false;
		}

		public bool IsWallBot() {
			if (neighbors[1, 2] == wall) { return true; }
			return false;
		}

		public bool IsWallLeft() {
				if (neighbors[0, 1] == wall) { return true; }
			return false;
		}

		public bool IsWallRight() {
				if (neighbors[2, 1] == wall) { return true; }
			return false;
		}
	}
}
