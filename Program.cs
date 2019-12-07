using System;

namespace Snake {
	class Program {
		static void Main(string[] args) {
			// init Console setup
			GameArea gameArea = new GameArea(15,15);
			gameArea.SetConsoleSize();

			gameArea.UpdateSnakeLocation();

			// check area around snake's head
			Matrix3x3 matrix3x3 = new Matrix3x3();
			matrix3x3.GetNeighbors(gameArea, 0, 10);
			Tuple<bool, bool, bool, bool> x = matrix3x3.CheckWalls(gameArea);

			// move snake
			Movement movement = new Movement(matrix3x3);
			movement.ReadPressedKey(1000);
			if (!movement.IsValidPath(gameArea, matrix3x3)) {
				Console.WriteLine("Game Over");
			}

			//gameArea.ShowEveryXSeconds(1);
		}
	}
}
