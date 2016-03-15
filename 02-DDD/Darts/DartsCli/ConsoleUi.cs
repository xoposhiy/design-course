using System;
using System.Linq;

namespace Darts.App
{
	public class ConsoleUi
	{
		public IConsoleCommand PromptCommand(params IConsoleCommand[] menuItems)
		{
			do
			{
				foreach (var item in menuItems)
				{
					Console.WriteLine($"{item.Symbol}. {item.Title}");
				}
				var key = Console.ReadKey(true);
				var cmd = menuItems.FirstOrDefault(c => c.Symbol == char.ToUpper(key.KeyChar));
				if (cmd != null)
					return cmd;
			} while (true);
		}

		public bool IsValidInt(string text)
		{
			int v;
			return int.TryParse(text, out v);
		}

		public string Prompt(string userPrompt)
		{
			return Prompt(userPrompt, s => true, s => s, "");
		}

		public int PromptInt(string userPrompt, string defaultValue)
		{
			return Prompt(userPrompt, IsValidInt, int.Parse, defaultValue);
		}

		public T Prompt<T>(string userPrompt, Func<string, bool> isValid, Func<string, T> parse, string defaultValue)
		{
			while (true)
			{
				Console.Write(userPrompt + (defaultValue != "" ? " (" + defaultValue + ")" : "") + ": ");
				var text = Console.ReadLine();
				if (string.IsNullOrEmpty(text)) text = defaultValue;
				if (isValid(text)) return parse(text);
			}
		}
	}
}