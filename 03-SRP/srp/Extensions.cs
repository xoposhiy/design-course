using System;
using System.Collections.Generic;
using System.Linq;

namespace Srp
{
	public static class Extensions
	{
		public static bool InRange(this int x, int min, int max)
		{
			return min <= x && x <= max;
		}

		public static IEnumerable<int> Indices<T>(this List<T> collection)
		{
			return Enumerable.Range(0, collection.Count);
		}
		public static IEnumerable<int> Indices<T>(this IReadOnlyCollection<T> collection)
		{
			return Enumerable.Range(0, collection.Count);
		}
		public static IEnumerable<int> Indices<T>(this IEnumerable<T> collection)
		{
			return Enumerable.Range(0, collection.Count());
		}
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, Random random = null)
		{
			random = random ?? new Random();
			var copy = items.ToList();
			for (int i = 0; i < copy.Count; i++)
			{
				var nextIndex = random.Next(i, copy.Count);
				yield return copy[nextIndex];
				copy[nextIndex] = copy[i];
			}
		}
	}
}