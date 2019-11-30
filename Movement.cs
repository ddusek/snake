using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
	class Movement {

		public ConsoleKey GetKey() {
			var keyinfo = Console.ReadKey();
			return keyinfo.Key;
		}

		public void Move(ConsoleKey keyPressed) {
			

		}
	}
}
