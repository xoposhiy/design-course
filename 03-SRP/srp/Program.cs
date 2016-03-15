using System;
using Srp.Refactored;

namespace Srp
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int x=-100; x<=100; x++)
				for (int y=-100; y<=100; y++)
				{
					var d1 = new Shape().GetDistanceTo(x, y);
					var d2 = new Shape_v2().GetDistanceTo(new Point(x, y));
					if (Math.Abs(d1 - d2) > 0.0001)
						Console.WriteLine(x + " " + y + " " + d1 + " " + d2);
				}
		}

	}
}