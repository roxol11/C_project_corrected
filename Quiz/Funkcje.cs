using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
	public static class Funkcje
	{


		public static int losuj(int a, int b) {
			Random r = new Random();
			int s = r.Next(a, b);
			return s;
		}

		public static bool search(int[] x, int s) //funkcja szukania
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (s == x[i])
				{
					return true;
				}
			}
			return false;
		}

	}
}
