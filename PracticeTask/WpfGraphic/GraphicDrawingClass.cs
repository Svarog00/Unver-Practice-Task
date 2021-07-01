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
	public partial class DrawingClass
	{
		private List<DependentPoint> _points = new List<DependentPoint>();

		private Canvas _canvasForGraph;

		private double _yAxis;
		private double _xAxis;

		private float _scale;

		private Color _graphicColor = Colors.Black;

		public double Xaxis
        {
			get => _xAxis;
			set => _xAxis = value;
        }

		public double Yaxis
		{
			get => _yAxis;
			set => _yAxis = value;
		}

		public List<DependentPoint> Points
        {
			get => _points;
			private set => _points = value;
        }

		public void SetData(List<DependentPoint> points, byte r, byte g, byte b, bool toCentre = false, double xAxisStart = 0, double yAxisStart = 0)
		{
			_points = points;
			_graphicColor = Color.FromRgb(r, g, b);
			if(toCentre)
            {
				_xAxis = xAxisStart;
				_yAxis = yAxisStart;
			}
		}

		public void Draw(Canvas canvasToDraw, float scale)
		{
			_canvasForGraph = canvasToDraw;
			_scale = scale;
			_canvasForGraph.Children.Clear();
			DrawAxles();
			DrawNet();
			DrawPoints();
		}

		private void DrawNet()
		{
			double delta = _scale;
			//Y axis
			double width = 0;
			while (width < _canvasForGraph.Width)
			{
				Line yAxis = new Line();
				yAxis.Y1 = 0;
				yAxis.Y2 = _canvasForGraph.Height;
				yAxis.X1 = _xAxis + width;
				yAxis.X2 = _xAxis + width;
				yAxis.Stroke = new SolidColorBrush(Colors.Gray);
				yAxis.StrokeThickness = 0.25 * (_scale/25);
				_canvasForGraph.Children.Add(yAxis);

				yAxis = new Line();
				yAxis.Y1 = 0;
				yAxis.Y2 = _canvasForGraph.Height;
				yAxis.X1 = _xAxis - width;
				yAxis.X2 = _xAxis - width;
				yAxis.Stroke = new SolidColorBrush(Colors.Gray);
				yAxis.StrokeThickness = 0.25 * (_scale / 25);
				_canvasForGraph.Children.Add(yAxis);
				width += delta;
			}
			//X axis
			double height = 0;
			while (height < _canvasForGraph.Height)
			{
				Line xAxis = new Line();
				xAxis.Y1 = _yAxis + height;
				xAxis.Y2 = _yAxis + height;
				xAxis.X1 = 0;
				xAxis.X2 = _canvasForGraph.Width;
				xAxis.Stroke = new SolidColorBrush(Colors.Gray);
				xAxis.StrokeThickness = 0.25 * (_scale / 25);
				_canvasForGraph.Children.Add(xAxis);

				xAxis = new Line();
				xAxis.Y1 = _yAxis - height;
				xAxis.Y2 = _yAxis - height;
				xAxis.X1 = 0;
				xAxis.X2 = _canvasForGraph.Width;
				xAxis.Stroke = new SolidColorBrush(Colors.Gray);
				xAxis.StrokeThickness = 0.25 * (_scale / 25);
				_canvasForGraph.Children.Add(xAxis);

				height += delta;
			}
		}

		private void DrawAxles()
		{
			//Y axis
			Line yAxis = new Line();
			yAxis.Y1 = 0;
			yAxis.Y2 = _canvasForGraph.Height;
			yAxis.X1 = _canvasForGraph.Width / 2;
			yAxis.X2 = _canvasForGraph.Width / 2;
			yAxis.StrokeThickness = 1;
			yAxis.Stroke = new SolidColorBrush(Colors.Black);
			_canvasForGraph.Children.Add(yAxis);
			//X axis
			Line xAxis = new Line();
			xAxis.Y1 = _canvasForGraph.Height / 2;
			xAxis.Y2 = _canvasForGraph.Height / 2;
			xAxis.X1 = 0;
			xAxis.X2 = _canvasForGraph.Width;
			xAxis.StrokeThickness = 1;
			xAxis.Stroke = new SolidColorBrush(Colors.Black);
			_canvasForGraph.Children.Add(xAxis);
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
				_canvasForGraph.Children.Add(elipse);

				Label label = new Label();
				label.Content = _points[i].X + " " + _points[i].Y;
				label.Margin = new Thickness(_xAxis + _points[i].X * _scale, _yAxis - _points[i].Y * _scale, 0, 0);
				_canvasForGraph.Children.Add(label);
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
				_canvasForGraph.Children.Add(line);
			}
		}
	}
}
