using System;

namespace Srp
{
	class Shape
	{

		public double GetDistanceTo(double x, double y)
		{
			if (y < 0) return GetDistanceTo(x, -y);
			var d1 = DistaceToDiagonalSegment(x, y);
			var d2 = DistaceToVerticalSegment(x, y);
			var d3 = DistaceToHorizontalSegment(x, y);
			return Math.Min(d1, Math.Min(d2, d3));
		}

		private double DistaceToHorizontalSegment(double x, double y)
		{
			if (Math.Abs(x) <= 10) return Math.Abs(y - 10);
			return Len(x + 10, y - 10);
		}

		private double DistaceToVerticalSegment(double x, double y)
		{
			if (Math.Abs(y) <= 10) return Math.Abs(x + 10);
			return Len(x + 10, y - 10);
		}

		private double DistaceToDiagonalSegment(double x, double y)
		{
			if (y <= x && y + 20 >= x) return Math.Abs(x + y - 20) / Math.Sqrt(2);
			else return Math.Min(Len(x - 10, y - 10), Len(x - 20, y));
		}

		private double Len(double dx, double dy)
		{
			return Math.Sqrt(dx * dx + dy * dy);
		}
	}
}