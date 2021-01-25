using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ESILV_DesignProject
{
	public class Dice
	{
		private int[] values = new int[2];
		private Random rnd = new Random();

		public Dice()
		{
			roll();
		}

		public void roll()
		{
			values[0] = rnd.Next(1, 7);
			values[1] = rnd.Next(1, 7);
		}

		public int[] Values
		{
			get { return values; }
		}
	}
}
