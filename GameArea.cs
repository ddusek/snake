using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake {
	class GameArea {
		public int LenX { get; private set; }
		public int LenY { get; private set; }
		public string[,] Matrix { get; set; }

		public string Empty { get; }
		public string SnakeBody { get; }
		public string SnakeTail { get; }
		public string SnakeHead { get; }
		public string Candy { get; }
		public string Wall { get; }

		public int speedMs { get; }
		
		public Tuple<int, int> SnakeHeadLocation { get; private set; }
		public Tuple<int, int> SnakeTailLocation { get; private set; }

		public void SetConsoleSize() {
			Console.SetWindowSize(LenX*2, LenY+1);
		}

		public GameArea(int lenX, int lenY) {
			this.LenX = lenX;
			this.LenY = lenY;
			Matrix = new string[lenX, lenY];
			Empty = "##";
			SnakeBody = "()";
			SnakeHead = "<>";
			SnakeTail = "{}";
			Candy = "*";
			Wall = "[]";
			speedMs = 1000;
			InitMatrix();
		}

		public void InitMatrix() {
			for (int x = 0; x < LenX; x++) {
				for (int y = 0; y < LenY; y++) {
					if (y == LenY/2 && x == LenX / 2) {
						Matrix[x, y] = SnakeHead;
						continue;
					}
					Matrix[x, y] = Empty;
				}
			}
		}

		//show matrix in console
		public void ShowMatrix() {
			for (int y = 0; y < LenY; y++) {
				for (int x = 0; x < LenX; x++) {
					Console.Write(Matrix[x, y]);
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
		//update head and tail locations
		public void UpdateSnakeLocation() {
			for (int x = 0; x < LenX; x++) {
				for (int y = 0; y < LenY; y++) {
					if(Matrix[x,y] == SnakeHead) {
						SnakeHeadLocation = Tuple.Create(x, y);
					}
					if(Matrix[x,y] == SnakeTail) {
						SnakeTailLocation = Tuple.Create(x, y);
					}
				}
			}
		}
	}
}
