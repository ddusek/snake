using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake {
	class GameArea {
		public int lenX { get; private set; }
		public int lenY { get; private set; }
		public string[,] matrix { get; set; }
		public string empty = "##";
		public string snakeBody = "()";
		public string snakeHead = "<>";
		public string candy = "*";

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
					if (y == lenY/2 && x == lenX / 2) {
						matrix[x, y] = snakeHead;
						continue;
					}
					matrix[x, y] = empty;
				}
			}
		}
		public void ChangeMatrix() {
			for (int x = 0; x < lenX; x++) {
				for (int y = 0; y < lenY; y++) {

				}
			}
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
