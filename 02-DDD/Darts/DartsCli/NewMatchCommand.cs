using System;
using System.Linq;
using Darts.Domain.Models;
using Darts.Domain.Repositories;

namespace Darts.App
{
	public class NewMatchCommand : IConsoleCommand
	{
		private readonly IMatchRepository repo;
		private readonly ConsoleUi ui = new ConsoleUi();

		public NewMatchCommand(IMatchRepository repo)
		{
			this.repo = repo;
		}
		public string Title => "New match";
		public char Symbol => 'N';

		public void Execute()
		{
			var players1 = ui.Prompt("Enter player 1 name");
			var players2 = ui.Prompt("Enter player 2 name");
			var initialScore = ui.PromptInt("Enter initial score", "301");
			var legsCount = ui.PromptInt("Enter legs count", "3");
			var match = new Match(DateTime.Now.Ticks.ToString(), new[] { players1, players2 }, initialScore, legsCount);
			EnterMatch(match);
			repo.SaveOrUpdate(match);
		}
	
		private void EnterMatch(Match match)
		{
			while (!match.Finished)
			{
				ShowCurrentLegDetails(match);
				var throwResult = ui.Prompt("Enter next throw result", ThrowResult.IsValid, ThrowResult.Parse, "");
				match.AddThrow(throwResult);
			}
			Console.WriteLine("Match is finished! Player {0} wins!", match.Winner);
			MatchSummaryView.Show(match);
			Console.WriteLine();
		}

		private void ShowCurrentLegDetails(Match match)
		{
			var leg = match.CurrentLeg;
			var legIndex = match.Legs.Count - 1;
			foreach (var name in match.PlayerNames)
			{
				var legPlayerIndex = match.GetLegPlayerIndex(name, legIndex);
				var scores = new[] { match.InitialScore }.Concat(leg.GetPlayerTurns(legPlayerIndex).Select(t => t.ScoreAfter));
				Console.WriteLine(name.PadLeft(10) + " " + string.Join(" ", scores.Select(s => s.ToString().PadLeft(3))));
			}
			if (!leg.Finished)
				Console.WriteLine("Current player: " + match.GetPlayerName(legIndex, leg.CurrentPlayerIndex) + ", score: " +
				                  leg.CurrentPlayer.Score);
			else
			{
				Console.WriteLine("Finished");
			}
		}
	}
}