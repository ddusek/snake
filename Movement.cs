using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake {
	class Movement {
		public int Mstime = 1000;
		public ConsoleKey PressedKey { get; set; }

		// set direction to right from beginning
		public Movement(Matrix3x3 matrix3x3) {
			PressedKey = ConsoleKey.RightArrow;
		}

		// wait x seconds before next movement happens, if not valid key is pressed, PressedKey is set to the last pressed key
		public void ReadPressedKey(int mstime) {
			Thread.Sleep(mstime);
			if (!Console.KeyAvailable) {
				
			} else {
				var keyPressed = Console.ReadKey(true).Key;
				PressedKey = keyPressed;
			}
		}
		// check if candy is on target location
		private bool IsValidPathCandy(GameArea gameArea, int x, int y) {
			if(gameArea.Matrix[x,y] == gameArea.Candy) {
				gameArea.Score += 1;
				if (gameArea.speedMs >= 100){
					gameArea.speedMs -= 50;
				}
				return true;
			}
			return false;
		}

		// check is selected direction is valid
		public bool IsValidPath(GameArea gameArea, Matrix3x3 matrix3X3) { 
			if (PressedKey == ConsoleKey.DownArrow) {
				if (matrix3X3.Matrix[1,2] == gameArea.Empty || matrix3X3.Matrix[1,2] == gameArea.Candy) {
					return true;
				}
				return false;
			} else if (PressedKey == ConsoleKey.UpArrow) {
				if (matrix3X3.Matrix[1, 0] == gameArea.Empty || matrix3X3.Matrix[1, 0] == gameArea.Candy) {
					return true;
				}
				return false;
			} else if (PressedKey == ConsoleKey.LeftArrow) {
				if (matrix3X3.Matrix[0, 1] == gameArea.Empty || matrix3X3.Matrix[0, 1] == gameArea.Candy) {
					return true;
				}
				return false;
			} else {
				if (matrix3X3.Matrix[2, 1] == gameArea.Empty || matrix3X3.Matrix[2, 1] == gameArea.Candy) {
					return true;
				}
				return false;
			}
		}
		// move whole gameArea matrix
		public void Move(GameArea gameArea, Matrix3x3 matrix3x3) {
			int headX = gameArea.SnakeHeadLocation.Item1;
			int headY = gameArea.SnakeHeadLocation.Item2;
			int tailX = gameArea.SnakeTailLocation.Item1;
			int tailY = gameArea.SnakeTailLocation.Item2;
			//if down arrow
			if (PressedKey == ConsoleKey.DownArrow) {
				if (IsValidPathCandy(gameArea, headX, headY + 1)) {
					gameArea.CreateCandy();
				} else {
					MoveTail(gameArea, tailX, tailY);
				}
				// move head and change old head position to body
				gameArea.Matrix[headX, headY + 1] = gameArea.SnakeHead;
				gameArea.Matrix[headX, headY] = gameArea.SnakeBody;
			}
			//if up arrow
			if (PressedKey == ConsoleKey.UpArrow) {
				if (IsValidPathCandy(gameArea, headX, headY - 1)) {
					gameArea.CreateCandy();
				}
				else {
					MoveTail(gameArea, tailX, tailY);
				}
				gameArea.Matrix[headX, headY - 1] = gameArea.SnakeHead;
				gameArea.Matrix[headX, headY] = gameArea.SnakeBody;
			}
			//if left arrow
			if (PressedKey == ConsoleKey.LeftArrow) {
				if (IsValidPathCandy(gameArea, headX -1, headY)) {
					gameArea.CreateCandy();
				}
				else {
					MoveTail(gameArea, tailX, tailY);
				}
				gameArea.Matrix[headX -1, headY] = gameArea.SnakeHead;
				gameArea.Matrix[headX, headY] = gameArea.SnakeBody;
			}
			//if right arrow
			if (PressedKey == ConsoleKey.RightArrow) {
				if (IsValidPathCandy(gameArea, headX +1, headY)) {
					gameArea.CreateCandy();
				}
				else {
					MoveTail(gameArea, tailX, tailY);
				}
				gameArea.Matrix[headX +1, headY] = gameArea.SnakeHead;
				gameArea.Matrix[headX, headY] = gameArea.SnakeBody;
			}
		}
		//move tail part to last body part position
		private void MoveTail(GameArea gameArea, int tailX, int tailY) {
			// if body part is down from tail, move tail part there
			if (gameArea.Matrix[tailX, tailY + 1] == gameArea.SnakeBody) {
				gameArea.Matrix[tailX, tailY] = gameArea.Empty;
				gameArea.Matrix[tailX, tailY + 1] = gameArea.SnakeTail;
			}
			// if body part is up
			else if (gameArea.Matrix[tailX, tailY - 1] == gameArea.SnakeBody) {
				gameArea.Matrix[tailX, tailY] = gameArea.Empty;
				gameArea.Matrix[tailX, tailY - 1] = gameArea.SnakeTail;
			}
			// if body part is left
			else if (gameArea.Matrix[tailX - 1, tailY] == gameArea.SnakeBody) {
				gameArea.Matrix[tailX, tailY] = gameArea.Empty;
				gameArea.Matrix[tailX - 1, tailY] = gameArea.SnakeTail;
			}
			// if body part is right
			else if (gameArea.Matrix[tailX + 1, tailY] == gameArea.SnakeBody) {
				gameArea.Matrix[tailX, tailY] = gameArea.Empty;
				gameArea.Matrix[tailX + 1, tailY] = gameArea.SnakeTail;
			}
		}
	}
}
