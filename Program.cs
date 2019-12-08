using System;

namespace Snake {
	class Program {
		static void Main(string[] args) {
			// init setup console and game area
			GameArea gameArea = new GameArea(15,15);
			gameArea.SetConsoleSize();
			bool gameOver = false;
			Matrix3x3 matrix3x3 = new Matrix3x3();
			Movement movement = new Movement(matrix3x3);

			while (!gameOver) {
				gameArea.ShowMatrix();
				gameArea.UpdateSnakeLocation();

				// check area around snake's head
				matrix3x3.GetNeighbors(gameArea, gameArea.SnakeHeadLocation.Item1, gameArea.SnakeHeadLocation.Item2);

				// move snake
				movement.ReadPressedKey(1000);
				if (!movement.IsValidPath(gameArea, matrix3x3)) {
					gameOver = true;
					break;
				}
				movement.Move(gameArea, matrix3x3);
			}
			Console.WriteLine("Game over");
			Console.WriteLine("Score: " + gameArea.Score);
			Console.ReadLine();

		}
	}
}
