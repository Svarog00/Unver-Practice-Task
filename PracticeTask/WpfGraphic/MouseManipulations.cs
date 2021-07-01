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
        private const int NOPOINTSELECTED = -1;

        private double _horizontalOffset = 1;
        private double _verticalOffset = 1;

        private bool _isMouseButtonPressed = false;
        private bool _isPointSelected = false;
        private bool _mouseMove = false;

        private int _selectedPointIndex = -1;

        private int _scrollerK = 120;

        private Point _scrollMousePoint = new Point();
        private Point _mousePoint = new Point();

        public event EventHandler<OnPointPositionCorrectedEventArgs> OnPointPositionCorrected;

        public class OnPointPositionCorrectedEventArgs : EventArgs
        {
            public int index;
            public double newX;
            public double newY;
        }

        private void slider_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (_scale + e.Delta / _scrollerK >= 2)
            {
                _scale += e.Delta / _scrollerK;
            }
            Draw();
        }

        #region MovingByMouse
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseButtonPressed = true;
            _horizontalOffset = scroll.HorizontalOffset;
            _verticalOffset = scroll.VerticalOffset;
            _scrollMousePoint = e.GetPosition(scroll);
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseButtonPressed = false;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseButtonPressed)
            {
                scroll.ScrollToHorizontalOffset(_horizontalOffset + (_scrollMousePoint.X - e.GetPosition(scroll).X));
                scroll.ScrollToVerticalOffset(_verticalOffset + (_scrollMousePoint.Y - e.GetPosition(scroll).Y));
            }

            if (_isPointSelected)
            {
                SetPointPosition(_drawingClass.Points[_selectedPointIndex], e.GetPosition(canvasForGraph));
                Draw();
            }

            if(_mouseMove)
            {
                _drawingClass.Xaxis -= (_mousePoint.X - e.GetPosition(canvasForGraph).X) / 50;
                _drawingClass.Yaxis -= (_mousePoint.Y - e.GetPosition(canvasForGraph).Y)/50;
                Draw();
            }
        }
        #endregion


        #region PointMoving
        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            GetPointOnMousePosition(e.GetPosition(canvasForGraph));

            if(_selectedPointIndex == NOPOINTSELECTED)
            {
                _mouseMove = true;
                _mousePoint = e.GetPosition(canvasForGraph);
            }
        }

        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _selectedPointIndex = -1;
            _isPointSelected = false;
            _mouseMove = false;
        }

        private void GetPointOnMousePosition(Point mousePosition)
        {
            double tmpX, tmpY;
            for (int i = 0; i < _drawingClass.Points.Count; i++)
            {
                GetCanvasPosition(_drawingClass.Points[i], out tmpX, out tmpY);
                if (Math.Abs(mousePosition.X - tmpX) <= 5
                    && Math.Abs(mousePosition.Y - tmpY) <= 5)
                {
                    _selectedPointIndex = i;
                    _isPointSelected = true;
                }
            }
        }

        private void GetCanvasPosition<T>(T point, out double x, out double y) where T : DependentPoint
        {
            x = _drawingClass.Xaxis + point.X * _scale;
            y = _drawingClass.Yaxis - point.Y * _scale;
        }

        private void GetLogicPosition(Point point, out double x, out double y)
        {
            x = (point.X - _drawingClass.Xaxis) / _scale;
            y = (point.Y - _drawingClass.Yaxis) / _scale;
        }

        private void SetPointPosition(DependentPoint pointToMove, Point newPosition)
        {
            double tmpX;
            double tmpY;

            GetLogicPosition(newPosition, out tmpX, out tmpY);

            double deltaX = pointToMove.X - tmpX;
            double deltaY = pointToMove.Y + tmpY;
            pointToMove.X -= deltaX;
            pointToMove.Y -= deltaY;

            OnPointPositionCorrected?.Invoke(this, new OnPointPositionCorrectedEventArgs
            {
                index = _selectedPointIndex,
                newX = pointToMove.X,
                newY = pointToMove.Y
            });
        }


        #endregion
    }
}
