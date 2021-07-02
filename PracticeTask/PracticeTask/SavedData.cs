using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PointClassLibrary;

namespace PracticeTask
{
    [Serializable]
    public class SavedData
    {
        List<DependentPoint> _points;
        byte _r;
        byte _g;
        byte _b;
        bool _useBorders;
        double _leftBorder;
        double _rightBorder;

        public List<DependentPoint> Points
        {
            get => _points;
        }

        public byte R
        {
            get => _r;
        }

        public byte G
        {
            get => _g;
        }

        public byte B
        {
            get => _b;
        }

        public bool UseBorders
        {
            get => _useBorders;
        }

        public double LeftBorder
        {
            get => _leftBorder;
        }

        public double RightBorder
        {
            get => _rightBorder;
        }

        public SavedData()
        {

        }

        public SavedData(List<DependentPoint> points, byte r, byte g, byte b, bool useBorders, double leftBorder, double rightBorder)
        {
            _points = points;
            _r = r;
            _g = g;
            _b = b;
            _useBorders = useBorders;
            _leftBorder = leftBorder;
            _rightBorder = rightBorder;
        }
    }

}
