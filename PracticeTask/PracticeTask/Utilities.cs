using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointClassLibrary;

namespace PracticeTask
{
    public static class Utilities
    {
        public static List<DependentPoint> FormListFromTable(this List<DependentPoint> points, DataGridView valuesTable)
        {
            points.Clear();
            double xi, yi;
            for (int i = 0; i < valuesTable.RowCount - 1; i++)
            {
                xi = Convert.ToDouble(valuesTable.Rows[i].Cells[0].Value);
                yi = Convert.ToDouble(valuesTable.Rows[i].Cells[1].Value);
                //points.Add(new System.Windows.Point(xi, yi));
                points.Add(new DependentPoint(xi, yi));
            }

            return points;
        }

        public static List<DependentPoint> FormListFromTable(this List<DependentPoint> points, DataGridView valuesTable, double leftBorder, double rightBorder)
        {
            points.Clear();
            double xi, yi;
            for (int i = 0; i < valuesTable.RowCount - 1; i++)
            {
                xi = Convert.ToDouble(valuesTable.Rows[i].Cells[0].Value);
                yi = Convert.ToDouble(valuesTable.Rows[i].Cells[1].Value);
                if (xi >= leftBorder && xi <= rightBorder)
                    //points.Add(new System.Windows.Point(xi, yi));
                    points.Add(new DependentPoint(xi, yi));
            }

            return points;
        }
    }
}
