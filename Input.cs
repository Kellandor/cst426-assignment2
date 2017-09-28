using System;
using System.IO;

namespace ASCIIGameEngine
{
	public class Input
	{
		char key;

		public void readInput(){
			if (Console.KeyAvailable) {
				key = (char)Console.In.Read ();
				MessageBus.getInstance ().AddEvent (new InputEvent (key));
			}
		}
	}
}

