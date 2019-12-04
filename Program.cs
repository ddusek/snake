using System;

namespace Snake {
	class Program {
		static void Main(string[] args) {
			GameArea gameArea = new GameArea(15,15);
			gameArea.SetConsoleSize();
			Movement movement = new Movement();
			movement.GetNeighbors(gameArea, 0, 10);
			Tuple<bool, bool, bool, bool> x = movement.CheckWalls();
			Console.WriteLine(x);
			//gameArea.ShowEveryXSeconds(1);
		}
	}
}
