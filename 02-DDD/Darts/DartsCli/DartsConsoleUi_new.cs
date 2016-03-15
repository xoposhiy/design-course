using System.Collections.Generic;
using System.IO;
using System.Linq;
using Darts.Domain.Repositories;

namespace Darts.App
{
	public class DartsConsoleUi_new
	{
		private readonly ConsoleUi ui = new ConsoleUi();
		private readonly IConsoleCommand[] commands;

		public DartsConsoleUi_new()
		{
			var repo = new MatchRepository(new DirectoryInfo("matches"));
			commands = new IConsoleCommand[]
			{
				new NewMatchCommand(repo),
				new ListMatchesCommand(repo),
				new ShowMatchDetailsCommand(repo),
				new QuitCommand()
			};
		}

		public void Run()
		{
			while (true)
			{
				var cmd = ui.PromptCommand(commands);
				cmd.Execute();
			}
			// ReSharper disable once FunctionNeverReturns
		}
	}
}