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
        private double _horizontalOffset = 1;
        private double _verticalOffset = 1;

        private bool _isMouseButtonPressed = false;
        private bool _isPointSelected = false;
        private int _selectedPointIndex = -1;

        private int _scrollerK = 120;

        private Point _scrollMousePoint = new Point();

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
                SetPointPosition(_points[_selectedPointIndex], e.GetPosition(canvasForGraph));
                Draw();
            }
        }
        #endregion


        #region PointMoving
        private void GetCanvasPosition(DependentPoint point, out double x, out double y)
        {
            x = _xAxis + point.X * _scale;
            y = _yAxis - point.Y * _scale;
        }

        private void GetLogicPosition(Point point, out double x, out double y)
        {
            x = (point.X - _xAxis) / _scale;
            y = (point.Y - _yAxis) / _scale;
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

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            double tmpX, tmpY;
            for (int i = 0; i < _points.Count; i++)
            {
                GetCanvasPosition(_points[i], out tmpX, out tmpY);
                if (Math.Abs(e.GetPosition(canvasForGraph).X - tmpX) <= 5
                    && Math.Abs(e.GetPosition(canvasForGraph).Y - tmpY) <= 5)
                {
                    _selectedPointIndex = i;
                    _isPointSelected = true;
                }
            }
        }

        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _selectedPointIndex = -1;
            _isPointSelected = false;
        }

        #endregion
    }
}
