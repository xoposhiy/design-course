namespace Srp
{
	public class Location
	{
		public Location(int x, int y)
		{
			X = x;
			Y = y;
		}

		public readonly int X, Y;

		#region Equality members

		protected bool Equals(Location other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Location)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}

		#endregion

		public override string ToString()
		{
			return $"X: {X}, Y: {Y}";
		}
	}
}