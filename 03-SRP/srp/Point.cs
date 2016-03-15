using System;

namespace Srp
{
	public class Point
	{
		public readonly double X, Y;

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static Point operator +(Point p1, Point p2) 
			=> new Point(p1.X + p2.X, p1.Y + p2.Y);
		public static Point operator -(Point p1, Point p2) 
			=> new Point(p1.X - p2.X, p1.Y - p2.Y);
		public double ScalarProd(Point p)
			=> X * p.X + Y * p.Y;
		public double AbsVectorProd(Point p)
			=> Math.Abs(p.X * Y - p.Y * X);
		public double Length 
			=> Math.Sqrt(X*X + Y*Y);

		public override string ToString() 
			=> $"X: {X}, Y: {Y}";

		protected bool Equals(Point other) 
			=> X.Equals(other.X) && Y.Equals(other.Y);

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Point) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X.GetHashCode()*397) ^ Y.GetHashCode();
			}
		}
	}
}