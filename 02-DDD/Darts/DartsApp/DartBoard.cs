using System;
using System.Drawing;
using System.Windows.Forms;
using Darts.Domain.Model;
using Darts.Domain.Model.Dartboard;

namespace DartsApp
{
	public sealed class DartBoard : Panel
	{
		private readonly Dartboard board = new Dartboard();

		private float Scale
		{
			get
			{
				var minDimension = Math.Min(ClientSize.Width, ClientSize.Height);
				return (float) (minDimension / 2f / board.DoubleOuterRadius / 1.2);
			}
		}

		public event Action<ThrowResult> OnSectorClick;

		public DartBoard()
		{
			ResizeRedraw = true;
			DoubleBuffered = true;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			var x = (e.X - ClientSize.Width/2f) / Scale;
			var y = - (e.Y - ClientSize.Height/2f) / Scale;
			var result = board.GetResult(x, y);
			if (OnSectorClick != null)
			{
				OnSectorClick(result);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			var g = e.Graphics;
			g.FillRectangle(Brushes.Gray, 0, 0, ClientSize.Width, ClientSize.Height);
			g.TranslateTransform(ClientSize.Width / 2f, ClientSize.Height / 2f);
			g.ScaleTransform(Scale, Scale);
			new DartsPainter().PaintDartsBoard(board, g);
		}
	}
}