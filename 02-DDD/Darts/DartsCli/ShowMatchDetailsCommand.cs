using System;
using Darts.Domain.Repositories;

namespace Darts.App
{
	public class ShowMatchDetailsCommand : IConsoleCommand
	{
		private readonly IMatchRepository repo;
		private readonly ConsoleUi ui = new ConsoleUi();

		public ShowMatchDetailsCommand(IMatchRepository repo)
		{
			this.repo = repo;
		}
		public string Title => "Details of the specific match";
		public char Symbol => 'D';

		public void Execute()
		{
			ListMatches();
			var id = ui.Prompt("Enter match id");
			var match = repo.FindMatchById(id);
			if (match == null)
				Console.WriteLine("Unknown match with id " + id);
			else
				MatchSummaryView.Show(match);
		}
		private void ListMatches()
		{
			Console.WriteLine();
			Console.WriteLine("List of matches:");
			foreach (var match in repo.GetMatches())
				Console.WriteLine("Id: {0}, Players: {1}", match.Id, string.Join(", ", match.PlayerNames));
			Console.WriteLine();
		}

	}
}