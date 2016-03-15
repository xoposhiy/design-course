using System;
using System.IO;
using System.Linq;

namespace Srp
{
	class Map
	{
		public Map(string filename)
		{
			var lines = File.ReadAllLines(filename);
			var heroPos = lines[0].Split().Select(int.Parse).ToArray();
			Hero = new Location(heroPos[0], heroPos[1]);
			cells = new CellType[lines.Length, lines[0].Length];
			foreach (var y in lines.Indices())
				foreach (var x in lines[0])
				{
					CellType cellType;
					switch (lines[y][x])
					{
						case '.':
							cellType = CellType.Empty;
							break;
						case '#':
							cellType = CellType.Wall;
							break;
						case '@':
							cellType = CellType.Swamp;
							break;
						default:
							throw new NotSupportedException(lines[y][x].ToString());
					}
					cells[y, x] = cellType;
				}
		}

		public Location Hero { get; private set; }

		private readonly CellType[,] cells;
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
			return pos.X >= 0 && pos.X < cells.GetLength(0)
				   && pos.Y >= 0 && pos.Y < cells.GetLength(1);
		}
	}
}