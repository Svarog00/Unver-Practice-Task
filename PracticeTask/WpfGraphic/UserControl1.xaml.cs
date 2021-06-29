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
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private double _horizontalOffset = 1;
        private double _verticalOffset = 1;

        private bool _isMouseButtonPressed;

        private Point _scrollMousePoint = new Point();

        public UserControl1()
        {
            InitializeComponent();
            _yAxis = canvasForGraph.Height / 2;
            _xAxis = canvasForGraph.Width / 2;
            _scale = 20; //100% = 25; 1% = 0.25
        }

        public void SetData(List<Point> points, float scale = 20)
        {
            _points = points;
            _scale = scale;
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
            if(_isMouseButtonPressed)
            {
                scroll.ScrollToHorizontalOffset(_horizontalOffset + (_scrollMousePoint.X - e.GetPosition(scroll).X));
                scroll.ScrollToVerticalOffset(_verticalOffset + (_scrollMousePoint.Y - e.GetPosition(scroll).Y));
            }
        }
        #endregion

        private void slider_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            slider.Value += e.Delta / 100;
        }
    }
}
