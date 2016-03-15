using System;
using System.Linq;
using Darts.Domain.Models;

namespace Darts.App
{
	public class MatchSummaryView
	{
		public static void Show(Match match)
		{
			Console.WriteLine("Total".PadLeft(20) + " | " + string.Join("  ", match.Legs.Select((leg, i) => i + 1)));
			var playerIndex = 0;
			foreach (var player in match.PlayerNames)
			{
				var winsCount = match.Legs.Count(l => l.Finished && l.WinnerIndex == playerIndex);
				// ReSharper disable once AccessToModifiedClosure (playerIndex)
				var legsScores = string.Join("  ", match.Legs.Select(l => l.Finished && l.WinnerIndex == playerIndex ? "1" : "0"));
				Console.WriteLine(player.PadLeft(10) + " " + winsCount.ToString().PadLeft(9) + " | " + legsScores);
				playerIndex++;
			}
		}
		
	}
}