namespace Darts.App
{
	public interface IConsoleCommand
	{
		void Execute();
		string Title { get; }
		char Symbol { get; }
	}
}