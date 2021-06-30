using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointClassLibrary
{
    [Serializable]
    //Y depends on X that's why it is equatable by X
    public class DependentPoint : IEquatable<DependentPoint>, IComparable<DependentPoint>
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set => _x = value;
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public DependentPoint(double x, double y)
        {
            _x = x; _y = y;
        }

        public int CompareTo(DependentPoint other)
        {
            if (other == null)
                return 1;
            else
                return _x.CompareTo(other.X);
        }

        public bool Equals(DependentPoint other)
        {
            if (other == null)
                return false;
            else
                return other.X == _x;
        }

        public override string ToString()
        {
            return $"{_x}; {_y}";
        }
    }
}
