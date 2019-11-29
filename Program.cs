using System;

namespace ConsoleSnake {
	class Program {
		static void Main(string[] args) {
			GameArea gameArea = new GameArea(15,15);
			gameArea.ShowMatrix();
		}
	}
}
