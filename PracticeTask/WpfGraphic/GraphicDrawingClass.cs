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

		private double _yAxis; //centre for Y axis
		private double _xAxis; //centre for X axis

		private double _xAxisBordered; //centre for bordered X axis

		private double _leftBorder;
		private double _rightBorder;

		private double _scale;

		private bool _useBorders;

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
        }

		public void SetData(List<DependentPoint> points, byte r, byte g, byte b, bool toCentre = false, bool useBorders = false, double leftBorder = 0, double rightBorder = 0, double xAxisStart = 0, double yAxisStart = 0)
		{
			_points = points;
			_graphicColor = Color.FromRgb(r, g, b);
			if(toCentre)
            {
				_xAxis = xAxisStart; 
				_yAxis = yAxisStart;
			}
			_leftBorder = leftBorder;
			_rightBorder = rightBorder;
			_useBorders = useBorders;
		}

		public void Draw(Canvas canvasToDraw, float scale)
		{
			_canvasForGraph = canvasToDraw;
			if (_useBorders)
            {
				_scale = _canvasForGraph.Width / Math.Abs(_rightBorder - _leftBorder + 2);
				_scale *= Math.Abs(scale/_scale);
				if (_leftBorder < 0)
					_xAxisBordered = Math.Abs(_leftBorder * _scale) + 5;
				else
					_xAxisBordered = -_leftBorder * _scale + 5;
				_xAxis = _xAxisBordered;
			}
			else
            {
				_scale = scale;
            }
			_canvasForGraph.Children.Clear();
			DrawNet();
			DrawAxles();
			DrawPoints();
		}

		private void DrawNet()
		{
			double delta = _scale;

			double width = 0;
			double height = 0;
			Line yAxis;
			Line xAxis;

			double xRightShift;
			double xLeftShift;
			double yUpShift;
			double yDownShift;

			#region use borders
			if (_useBorders)
            {
				while (width < _canvasForGraph.Width*3 && height < _canvasForGraph.Height*3)
				{
					xRightShift = _xAxisBordered + width;
					xLeftShift = _xAxisBordered - width;

					//right direction
					if (width <= _rightBorder * _scale && width >= _leftBorder * _scale)
					{
						yAxis = new Line();
						yAxis.Y1 = 0;
						yAxis.Y2 = _canvasForGraph.Height;
						yAxis.X1 = xRightShift;
						yAxis.X2 = xRightShift;
						yAxis.Stroke = new SolidColorBrush(Colors.Gray);
						yAxis.StrokeThickness = 0.25 * (_scale / 25);
						_canvasForGraph.Children.Add(yAxis);
					}

					//left direction
					if (-width >= _leftBorder * _scale && -width <= _rightBorder * _scale)
					{
						yAxis = new Line();
						yAxis.Y1 = 0;
						yAxis.Y2 = _canvasForGraph.Height;
						yAxis.X1 = xLeftShift;
						yAxis.X2 = xLeftShift;
						yAxis.Stroke = new SolidColorBrush(Colors.Gray);
						yAxis.StrokeThickness = 0.25 * (_scale / 25);
						_canvasForGraph.Children.Add(yAxis);
					}

					width += delta;

					yUpShift = _canvasForGraph.Height + height;
					yDownShift = _canvasForGraph.Height - height;

					//up direction
					xAxis = new Line();
					xAxis.Y1 = yUpShift;
					xAxis.Y2 = yUpShift;
					xAxis.X1 = _xAxisBordered + _leftBorder * _scale;
					xAxis.X2 = _xAxisBordered + _rightBorder * _scale;
					xAxis.Stroke = new SolidColorBrush(Colors.Gray);
					xAxis.StrokeThickness = 0.25 * (_scale / 25);
					_canvasForGraph.Children.Add(xAxis);

					//down direction
					xAxis = new Line();
					xAxis.Y1 = yDownShift;
					xAxis.Y2 = yDownShift;
					xAxis.X1 = _xAxisBordered + _leftBorder * _scale;
					xAxis.X2 = _xAxisBordered + _rightBorder * _scale;
					xAxis.Stroke = new SolidColorBrush(Colors.Gray);
					xAxis.StrokeThickness = 0.25 * (_scale / 25);
					_canvasForGraph.Children.Add(xAxis);

					height += delta;
				}
			}
			#endregion

			#region dont use borders
			else
            {
				while (width < _canvasForGraph.Width*2 && height < _canvasForGraph.Height*2)
				{
					xRightShift = _xAxis + width;
					xLeftShift = _xAxis - width;

					yAxis = new Line();
					yAxis.Y1 = 0;
					yAxis.Y2 = _canvasForGraph.Height;
					yAxis.X1 = xRightShift;
					yAxis.X2 = xRightShift;
					yAxis.Stroke = new SolidColorBrush(Colors.Gray);
					yAxis.StrokeThickness = 0.25 * (_scale / 25);
					_canvasForGraph.Children.Add(yAxis);

					yAxis = new Line();
					yAxis.Y1 = 0;
					yAxis.Y2 = _canvasForGraph.Height;
					yAxis.X1 = xLeftShift;
					yAxis.X2 = xLeftShift;
					yAxis.Stroke = new SolidColorBrush(Colors.Gray);
					yAxis.StrokeThickness = 0.25 * (_scale / 25);
					_canvasForGraph.Children.Add(yAxis);

					width += delta;

					yUpShift = _yAxis + height;
					yDownShift = _yAxis - height;

					xAxis = new Line();
					xAxis.Y1 = yUpShift;
					xAxis.Y2 = yUpShift;
					xAxis.X1 = 0;
					xAxis.X2 = _canvasForGraph.Width;
					xAxis.Stroke = new SolidColorBrush(Colors.Gray);
					xAxis.StrokeThickness = 0.25 * (_scale / 25);
					_canvasForGraph.Children.Add(xAxis);

					xAxis = new Line();
					xAxis.Y1 = yDownShift;
					xAxis.Y2 = yDownShift;
					xAxis.X1 = 0;
					xAxis.X2 = _canvasForGraph.Width;
					xAxis.Stroke = new SolidColorBrush(Colors.Gray);
					xAxis.StrokeThickness = 0.25 * (_scale / 25);
					_canvasForGraph.Children.Add(xAxis);

					height += delta;
				}

			}
			#endregion

		}

        private void DrawAxles()
		{
			Line yAxis;
			Line xAxis;
			//Y axis
			yAxis = new Line();
			yAxis.Y1 = 0;
			yAxis.Y2 = _canvasForGraph.Height;
			yAxis.X1 = 0;
			yAxis.X2 = 0;
			yAxis.StrokeThickness = 1;
			yAxis.Stroke = new SolidColorBrush(Colors.Black);
			_canvasForGraph.Children.Add(yAxis);
			//X axis
			xAxis = new Line();
			xAxis.Y1 = _canvasForGraph.Height;
			xAxis.Y2 = _canvasForGraph.Height;
			xAxis.X1 = 0;
			xAxis.X2 = _canvasForGraph.Width;
			xAxis.StrokeThickness = 1;
			xAxis.Stroke = new SolidColorBrush(Colors.Black);
			_canvasForGraph.Children.Add(xAxis);

			#region notching
			Label number = new Label();

			double delta = _scale;
			double width = 0;
			double height = 0;
			double xRightShift;
			double xLeftShift;
			double yUpShift;
			double yDownShift;

			while (width < _canvasForGraph.Width*2 && height < _canvasForGraph.Height*2)
			{
				xRightShift = _xAxis + width;
				xLeftShift = _xAxis - width;
				yUpShift = _yAxis + height;
				yDownShift = _yAxis - height;

				//Notching on X axis
				if(_useBorders)
                {
					DrawBorderedXNotching(xRightShift, xLeftShift, width);
				}
				else
                {
					DrawXNotching(xRightShift, xLeftShift, width);
                }

				//Notching on Y axis
				xAxis = new Line();
				xAxis.Y1 = yUpShift;
				xAxis.Y2 = yUpShift;
				xAxis.X1 = 0;
				xAxis.X2 = 10;
				xAxis.Stroke = new SolidColorBrush(Colors.Black);
				xAxis.StrokeThickness = 0.5 * (_scale / 25);
				_canvasForGraph.Children.Add(xAxis);
				number = new Label();
				number.Content = (height / _scale).ToString();
				number.Margin = new Thickness(10, yDownShift-10, 0, 0);
				_canvasForGraph.Children.Add(number);

				xAxis = new Line();
				xAxis.Y1 = yDownShift;
				xAxis.Y2 = yDownShift;
				xAxis.X1 = 0;
				xAxis.X2 = 10;
				xAxis.Stroke = new SolidColorBrush(Colors.Black);
				xAxis.StrokeThickness = 0.5 * (_scale / 25);
				_canvasForGraph.Children.Add(xAxis);
				number = new Label();
				number.Content = (-height / _scale).ToString();
				number.Margin = new Thickness(10, yUpShift-10, 0, 0);
				_canvasForGraph.Children.Add(number);

				width += delta;
				height += delta;
			}
			#endregion
		}

		private void DrawXNotching(double xRightShift, double xLeftShift, double width)
        {
			Line yAxis;
			Label number;
			yAxis = new Line();
			yAxis.Y1 = _canvasForGraph.Height - 10;
			yAxis.Y2 = _canvasForGraph.Height;
			yAxis.X1 = xRightShift;
			yAxis.X2 = xRightShift;
			yAxis.Stroke = new SolidColorBrush(Colors.Black);
			yAxis.StrokeThickness = 0.5 * (_scale / 25);
			_canvasForGraph.Children.Add(yAxis);
			number = new Label();
			number.Content = (width / _scale).ToString();
			number.Margin = new Thickness(xRightShift - 10, _canvasForGraph.Height - 30, 0, 0);
			_canvasForGraph.Children.Add(number);

			yAxis = new Line();
			yAxis.Y1 = _canvasForGraph.Height - 10;
			yAxis.Y2 = _canvasForGraph.Height;
			yAxis.X1 = xLeftShift;
			yAxis.X2 = xLeftShift;
			yAxis.Stroke = new SolidColorBrush(Colors.Black);
			yAxis.StrokeThickness = 0.5 * (_scale / 25);
			_canvasForGraph.Children.Add(yAxis);
			number = new Label();
			number.Content = (-width / _scale).ToString();
			number.Margin = new Thickness(xLeftShift - 10, _canvasForGraph.Height - 30, 0, 0);
			_canvasForGraph.Children.Add(number);
		}

		private void DrawBorderedXNotching(double xRightShift, double xLeftShift, double width)
		{
			Line yAxis;
			Label number;
			if ((width / _scale) <= _rightBorder)
			{
				yAxis = new Line();
				yAxis.Y1 = _canvasForGraph.Height - 10;
				yAxis.Y2 = _canvasForGraph.Height;
				yAxis.X1 = xRightShift;
				yAxis.X2 = xRightShift;
				yAxis.Stroke = new SolidColorBrush(Colors.Black);
				yAxis.StrokeThickness = 0.5 * (_scale / 25);
				_canvasForGraph.Children.Add(yAxis);
				number = new Label();
				number.Content = (width / _scale).ToString();
				number.Margin = new Thickness(xRightShift - 10, _canvasForGraph.Height - 30, 0, 0);
				_canvasForGraph.Children.Add(number);
			}
			if((-width / _scale) >= _leftBorder)
			{ 
				yAxis = new Line();
				yAxis.Y1 = _canvasForGraph.Height - 10;
				yAxis.Y2 = _canvasForGraph.Height;
				yAxis.X1 = xLeftShift;
				yAxis.X2 = xLeftShift;
				yAxis.Stroke = new SolidColorBrush(Colors.Black);
				yAxis.StrokeThickness = 0.5 * (_scale / 25);
				_canvasForGraph.Children.Add(yAxis);
				number = new Label();
				number.Content = (-width / _scale).ToString();
				number.Margin = new Thickness(xLeftShift - 10, _canvasForGraph.Height - 30, 0, 0);
				_canvasForGraph.Children.Add(number);
			}
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
