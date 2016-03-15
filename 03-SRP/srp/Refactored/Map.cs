using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Srp.Refactored
{
	public class MapParser
	{
		public static Map ParseMapFromFile(string filename)
		{
			return ParseMap(File.ReadAllLines(filename));
		}

		public static Map ParseMap(string[] lines)
		{
			var cells = new CellType[lines.Length, lines[0].Length];
			var heroPos = lines[0].Split().Select(int.Parse).ToArray();
			foreach (var y in lines.Skip(1).Indices())
				foreach (var x in lines[0].Indices())
				{
					cells[y, x] = ParseCell(lines[y][x]);
				}
			return new Map(cells, new Location(heroPos[0], heroPos[1]));
		}

		private static CellType ParseCell(char c)
		{
			switch (c)
			{
				case '.':
					return CellType.Empty;
				case '#':
					return CellType.Wall;
				case '@':
					return CellType.Swamp;
				default:
					throw new NotSupportedException(c.ToString());
			}
		}
	}

	public class Map
	{
		private readonly CellType[,] cells;

		public Map(CellType[,] cells, Location hero)
		{
			this.cells = cells;
			Hero = hero;
		}

		public Location Hero { get; private set; }

		public CellType this[int y, int x] => cells[y, x];
		public CellType this[Location pos] => cells[pos.Y, pos.X];

		public bool TryMoveHero(int dx, int dy)
		{
			var newHero = new Location(Hero.X + dx, Hero.Y + dy);
			if (!InsideMap(newHero)) return false;
			if (this[newHero] == CellType.Wall) return false;
			Hero = newHero;
			return true;
		}

		public bool InsideMap(Location pos)
		{
			return
				pos.X.InRange(0, cells.GetLength(0) - 1) &&
				pos.Y.InRange(0, cells.GetLength(1) - 1);
		}
	}
}