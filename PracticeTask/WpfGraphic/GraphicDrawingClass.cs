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

namespace WpfGraphic
{
    public partial class UserControl1 : UserControl
    {
        private List<Point> _points;

        private double _yAxis;
        private double _xAxis;

        private float _scale;

        public void Draw()
        {
            canvasForGraph.Children.Clear();
            DrawAxles();
            DrawPoints();
        }

        private void DrawAxles()
        {
            //Y axis
            Line yAxis = new Line();
            yAxis.Y1 = 0;
            yAxis.Y2 = canvasForGraph.Height;
            yAxis.X1 = canvasForGraph.Width / 2;
            yAxis.X2 = canvasForGraph.Width / 2;
            yAxis.Stroke = new SolidColorBrush(Colors.Black);
            yAxis.StrokeThickness = 1;
            //X axis
            Line xAxis = new Line();
            xAxis.Y1 = canvasForGraph.Height / 2;
            xAxis.Y2 = canvasForGraph.Height / 2;
            xAxis.X1 = 0;
            xAxis.X2 = canvasForGraph.Width;
            xAxis.Stroke = new SolidColorBrush(Colors.Black);
            xAxis.StrokeThickness = 1;

            canvasForGraph.Children.Add(xAxis);
            canvasForGraph.Children.Add(yAxis);
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
                elipse.Stroke = Brushes.Black;
                elipse.Margin = new Thickness(pointsToDraw[i].X, pointsToDraw[i].Y, 0, 0);
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
                line.Stroke = new SolidColorBrush(Colors.Black);
                line.StrokeThickness = 1;
                canvasForGraph.Children.Add(line);
            }
        }
    }
}
