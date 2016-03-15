using System;

namespace Srp.Refactored
{
	public class Shape
	{
		private readonly Point[] shape = {
			new Point(-10, -10),
			new Point(-10, 10),
			new Point(10, 10),
			new Point(20, 0),
			new Point(10, -10),
			new Point(-10, -10)
		};

		public double GetDistanceTo(Point p)
		{
			return p.DistanceToShape(shape);
		}
	}

	public static class PointExtensions
	{
		public static double DistanceToShape(this Point point, Point[] shape)
		{
			var dist = double.MaxValue;
			for (var i = 1; i < shape.Length; i++)
			{
				var p1 = shape[i - 1];
				var p2 = shape[i];
				dist = Math.Min(dist, point.DistanceToSegment(p1, p2));
			}
			return dist;
		}

		public static double DistanceToSegment(this Point p, Point p1, Point p2)
		{
			var scalar1 = (p - p1).ScalarProd(p2 - p1);
			var scalar2 = (p - p2).ScalarProd(p1 - p2);
			if (scalar1 < 0) return (p1 - p).Length;
			if (scalar2 < 0) return (p2 - p).Length;
			return (p1 - p).AbsVectorProd(p2 - p) / (p1 - p2).Length;
		}

	}

}