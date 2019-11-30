using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleSnake {
	class GameArea {
		public int lenX;
		int lenY;
		string[,] matrix;
		string empty = "XX";
		string snakeBody = "()";
		string snakeHead = ".<>";

		public void SetConsoleSize() {
			Console.SetWindowSize(lenX*2, lenY+1);
		}
		public GameArea(int lenX, int lenY) {
			this.lenX = lenX;
			this.lenY = lenY;
			matrix = new string[lenX, lenY];
			InitMatrix();
		}

		public void InitMatrix() {
			for (int x = 0; x < lenX; x++) {
				for (int y = 0; y < lenY; y++) {
					matrix[x, y] = empty;
				}
			}
		}
		public void ChangeMatrix() {
			
		}

		public void ShowMatrix() {
			for (int y = 0; y < lenY; y++) {
				for (int x = 0; x < lenX; x++) {
					Console.Write(matrix[x, y]);
				}
				Console.WriteLine();
			}
		}

		public void ClearConsole() {
			Console.Clear();
		}
		
		public void ShowEveryXSeconds(int seconds) {
			while (true) {
				ClearConsole();
				ShowMatrix();
				Thread.Sleep(seconds * 1000);
			}

		}

		public int GetSnakeLocation() {
			return 0;
		}
	}
}
