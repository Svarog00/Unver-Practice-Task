using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeTask
{
    public static class Utilities
    {
        public static List<System.Windows.Point> FormListFromTable(this List<System.Windows.Point> points, DataGridView valuesTable)
        {
            points.Clear();
            double xi, yi;
            for (int i = 0; i < valuesTable.RowCount - 1; i++)
            {
                xi = Convert.ToDouble(valuesTable.Rows[i].Cells[0].Value);
                yi = Convert.ToDouble(valuesTable.Rows[i].Cells[1].Value);
                points.Add(new System.Windows.Point(xi, yi));
            }

            return points;
        }

        public static List<System.Windows.Point> FormListFromTable(this List<System.Windows.Point> points, DataGridView valuesTable, double leftBorder, double rightBorder)
        {
            points.Clear();
            double xi, yi;
            for (int i = 0; i < valuesTable.RowCount - 1; i++)
            {
                xi = Convert.ToDouble(valuesTable.Rows[i].Cells[0].Value);
                yi = Convert.ToDouble(valuesTable.Rows[i].Cells[1].Value);
                if (xi >= leftBorder && xi <= rightBorder)
                    points.Add(new System.Windows.Point(xi, yi));
            }

            return points;
        }
    }
}
