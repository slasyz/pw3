using System;

namespace forms
{
	public class GameClass
	{
		int attempts = 0;
		int number;

		public GameClass ()
		{
			Random rnd = new Random ();
			this.number = Random.Next (0, 11);
		}
	}
}

