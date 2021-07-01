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
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private double _yAxisStart;
        private double _xAxisStart;
        private float _scale;

        private DrawingClass _drawingClass;

        public UserControl1()
        {
            InitializeComponent();
            _yAxisStart = canvasForGraph.Height / 2;
            _xAxisStart = canvasForGraph.Width / 2;
            _scale = 10;

            _drawingClass = new DrawingClass();
        }

        public void SetData(List<DependentPoint> points, byte r, byte g, byte b, bool toCentre = false)
        {
            _drawingClass.SetData(points, r, g, b, toCentre, _xAxisStart, _yAxisStart);
        }

        public void Draw()
        {
            _drawingClass.Draw(canvasForGraph, _scale);
        }
    }
}
