using System;

namespace Darts.App
{
	public class QuitCommand : IConsoleCommand
	{
		public void Execute()
		{
			Environment.Exit(0);
		}

		public string Title => "Quit";
		public char Symbol => 'Q';
	}
}