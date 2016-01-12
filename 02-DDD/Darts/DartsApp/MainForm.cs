using System;
using System.Windows.Forms;
using Darts.Domain.Model;

namespace DartsApp
{
	public class MainForm : Form
	{
		private Match match;

		public MainForm()
		{
			var board = new DartBoard { Dock = DockStyle.Fill };
			Controls.Add(board);
			match = new Match("1", new[] { "John", "Elis" }, 501, 5);
			board.OnSectorClick += result => Text = result.ToString();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			DoubleBuffered = true;
		}
	}
}
