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
					points.Add(new DependentPoint(xi, yi));
			}

			if(points.Count > 0)
            {
				points.Sort();

				#region add until left border
				while (leftBorder < points[0].X)
				{
					points.Add(new DependentPoint(leftBorder, 0));
					leftBorder++;
				}
				#endregion
				points.Sort();

				#region add until right border
				int c = points.Count - 1;
				while (Math.Abs(rightBorder) > Math.Abs(points[c].X))
				{
					points.Add(new DependentPoint(rightBorder, 0));
					rightBorder--;
				}
				#endregion
				points.Sort();
			}

			return points;
		}
	}
}
