using System;
using Darts.Domain.Repositories;

namespace Darts.App
{
	public class ListMatchesCommand : IConsoleCommand
	{
		private readonly IMatchRepository repo;

		public ListMatchesCommand(IMatchRepository repo)
		{
			this.repo = repo;
		}

		public void Execute()
		{
			Console.WriteLine();
			Console.WriteLine("List of matches:");
			foreach (var match in repo.GetMatches())
				Console.WriteLine("Id: {0}, Players: {1}", match.Id, string.Join(", ", match.PlayerNames));
			Console.WriteLine();
		}

		public string Title => "List of stored matches";
		public char Symbol => 'L';
	}
}