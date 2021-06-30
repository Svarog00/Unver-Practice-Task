using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PointClassLibrary;

namespace WpfGraphic
{
	public partial class UserControl1 : UserControl
	{
		private List<DependentPoint> _points = new List<DependentPoint>();

		private double _yAxis;
		private double _xAxis;

		private float _scale;

		private Color _graphicColor = Colors.Black;

		public void SetData(List<DependentPoint> points)
		{
			_points = points;
			_graphicColor = Colors.Black;
			/*_yAxis = canvasForGraph.Width / 2;
			_xAxis = canvasForGraph.Height / 2;*/
		}

		public void SetData(List<DependentPoint> points, byte r, byte g, byte b)
		{
			_points = points;
			_graphicColor = Color.FromRgb(r, g, b);
			/*_yAxis = canvasForGraph.Width / 2;
			_xAxis = canvasForGraph.Height / 2;*/
		}

		public void Draw()
		{
			canvasForGraph.Children.Clear();
			DrawAxles();
			DrawNet();
			DrawPoints();
		}

		private void DrawNet()
		{
			double delta = _scale;
			//Y axis
			double width = 0;
			while (width < canvasForGraph.Width)
			{
				Line yAxis = new Line();
				yAxis.Y1 = 0;
				yAxis.Y2 = canvasForGraph.Height;
				yAxis.X1 = width;
				yAxis.X2 = width;
				yAxis.Stroke = new SolidColorBrush(Colors.Gray);
				yAxis.StrokeThickness = 0.25;
				width += delta;
				canvasForGraph.Children.Add(yAxis);
			}
			//X axis
			double height = 0;
			while (height < canvasForGraph.Height)
			{
				Line xAxis = new Line();
				xAxis.Y1 = height;
				xAxis.Y2 = height;
				
				xAxis.X1 = 0;
				xAxis.X2 = canvasForGraph.Width;
				xAxis.Stroke = new SolidColorBrush(Colors.Gray);
				xAxis.StrokeThickness = 0.25;
				height += delta;
				canvasForGraph.Children.Add(xAxis);
			}
		}

		private void DrawAxles()
		{
			//Y axis
			Line yAxis = new Line();
			yAxis.Y1 = 0;
			yAxis.Y2 = canvasForGraph.Height;
			yAxis.X1 = canvasForGraph.Width / 2;
			yAxis.X2 = canvasForGraph.Width / 2;
			yAxis.StrokeThickness = 1;
			yAxis.Stroke = new SolidColorBrush(Colors.Black);
			canvasForGraph.Children.Add(yAxis);
			//X axis
			Line xAxis = new Line();
			xAxis.Y1 = canvasForGraph.Height / 2;
			xAxis.Y2 = canvasForGraph.Height / 2;
			xAxis.X1 = 0;
			xAxis.X2 = canvasForGraph.Width;
			xAxis.StrokeThickness = 1;
			xAxis.Stroke = new SolidColorBrush(Colors.Black);
			canvasForGraph.Children.Add(xAxis);
		}

		private void DrawPoints()
		{
			Point[] pointsToDraw = new Point[_points.Count];
			for (int i = 0; i < pointsToDraw.Length; i++)
			{
				pointsToDraw[i] = new Point(_xAxis + _points[i].X * _scale, _yAxis - _points[i].Y * _scale);

				Ellipse elipse = new Ellipse();

				elipse.Width = _scale / 5;
				elipse.Height = _scale / 5;

				elipse.StrokeThickness = 2;
				elipse.Stroke = new SolidColorBrush(_graphicColor);
				elipse.Margin = new Thickness(pointsToDraw[i].X - elipse.Width/2, pointsToDraw[i].Y - elipse.Height/2, 0, 0);
				canvasForGraph.Children.Add(elipse);

				Label label = new Label();
				label.Content = _points[i].X + " " + _points[i].Y;
				label.Margin = new Thickness(_xAxis + _points[i].X * _scale, _yAxis - _points[i].Y * _scale, 0, 0);
				canvasForGraph.Children.Add(label);
			}

			//Связать каждую точку со своим соседом
			for (int i = 0; i < _points.Count - 1; i++)
			{
				Line line = new Line();
				line.X1 = pointsToDraw[i].X;
				line.Y1 = pointsToDraw[i].Y;
				line.X2 = pointsToDraw[i + 1].X;
				line.Y2 = pointsToDraw[i + 1].Y;
				line.Stroke = new SolidColorBrush(_graphicColor);
				line.StrokeThickness = 1;
				canvasForGraph.Children.Add(line);
			}
		}
	}
}
