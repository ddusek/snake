using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake {
	class GameArea {
		int lenX;
		int lenY;
		int[,] matrix;
		string box = "[ ]";
		string boxFilled = "[o]";

		public GameArea(int lenX, int lenY) {
			this.lenX = lenX;
			this.lenY = lenY;
			this.matrix = new int[lenX, lenY];
		}

		public void ShowMatrix() {
			int s = 0;
			for (int y = 0; y < lenY; y++) {
				for (int x = 0; x < lenX; x++) {
					Console.Write(box);
				}
				s++;
				Console.WriteLine();
			}
		}
	}
}
