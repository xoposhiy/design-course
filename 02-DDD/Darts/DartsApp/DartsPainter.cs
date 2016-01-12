using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Darts.Domain.Model;
using Darts.Domain.Model.Dartboard;

namespace DartsApp
{
	public class DartsPainter
	{
		public DartsPainter()
		{
			DarkColor = Brushes.Black;
			LightColor = Brushes.Beige;
			GreenColor = Brushes.ForestGreen;
			RedColor = Brushes.Red;
		}

		private Brush GetBrush(DartboardColor color)
		{
			if (color == DartboardColor.Light) return LightColor;
			if (color == DartboardColor.Dark) return DarkColor;
			if (color == DartboardColor.Green) return GreenColor;
			if (color == DartboardColor.Red) return RedColor;
			throw new ArgumentException(color.ToString());
		}

		public Brush DarkColor { get; private set; }
		public Brush LightColor { get; private set; }
		public Brush GreenColor { get; private set; }
		public Brush RedColor { get; private set; }

		public void PaintDartsBoard(Dartboard board, Graphics graphics)
		{
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			FillEllipse(graphics, DartboardColor.Dark, board.DoubleOuterRadius * 1.3);
			foreach (var sector in board.Sectors)
				PaintSector(board, graphics, sector);
			FillEllipse(graphics, DartboardColor.Green, board.OuterBullRadius);
			FillEllipse(graphics, DartboardColor.Red, board.InnerBullRadius);
		}

		private void PaintSector(Dartboard board, Graphics graphics, Section section)
		{
			FillPie(graphics, section.DoubleColor, board.DoubleOuterRadius, section.StartAngle, section.SweepAngle);
			FillPie(graphics, section.SectorColor, board.DoubleInnerRadius, section.StartAngle, section.SweepAngle);
			FillPie(graphics, section.DoubleColor, board.TripleOuterRadius, section.StartAngle, section.SweepAngle);
			FillPie(graphics, section.SectorColor, board.TripleInnerRadius, section.StartAngle, section.SweepAngle);
			var cx = board.DoubleOuterRadius*1.1*Math.Cos(section.StartAngle + section.SweepAngle/2);
			var cy = -board.DoubleOuterRadius*1.1*Math.Sin(section.StartAngle + section.SweepAngle/2);
			var font = new Font(new FontFamily("Arial"),14, FontStyle.Regular);
			var text = section.Value.ToString();
			var size = graphics.MeasureString(text, font);
			graphics.DrawString(text, font, Brushes.White, (float) cx - size.Width/2, (float)cy - size.Height/2);
		}

		private void FillEllipse(Graphics g, DartboardColor color, double radius)
		{
			g.FillEllipse(GetBrush(color), (float)-radius, (float)-radius, 2 * (float)radius, 2 * (float)radius);
		}

		private void FillPie(Graphics g, DartboardColor color, double radius, double startAngle, double sweepAngle)
		{
			g.FillPie(
				GetBrush(color), (float)-radius, (float)-radius, 2 * (float)radius, 2 * (float)radius, 
				(float)(-startAngle * 180 / Math.PI), (float)(-sweepAngle * 180 / Math.PI));
		}
	}
}