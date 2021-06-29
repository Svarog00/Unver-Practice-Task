using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointClassLibrary;

namespace PracticeTask
{
    public partial class Form1 : Form
    {
        //private Form2 _graphForm;

        private bool _formulaInput;
        private bool _tableInput;
        private bool _graphicDrawn = false;

        private double _leftBorder = double.NaN;
        private double _rightBorder = double.NaN;

        private List<DependentPoint> _points = new List<DependentPoint>();

        public Form1()
        {
            InitializeComponent();
            //_graphForm = new Form2();
            Text = "Форма ввода";
            valuesTable.Columns.Add("-", "x");
            valuesTable.Columns.Add("-", "y");

            _formulaInput = formulaRadioButton.Checked;
            _tableInput = tableRadioButton.Checked;

            SwitchVisibility();
        }

        private void tableRadioButton_CheckedChanged(object sender, EventArgs e) //Переключение видимости таблицы
        {
            SwitchVisibility();
        }

        private void formulaRadioButton_CheckedChanged(object sender, EventArgs e) //Переключение видимости поля ввода формулы
        {
            SwitchVisibility();
        }


        private void buildButton_Click(object sender, EventArgs e)
        {
            Build();
        }

        //Событие вызываемое при изменении значений в таблице
        private void valuesTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Rebuild();
            CheckXs(e.RowIndex);
        }

        //Удаление пар значений из таблицы
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (valuesTable.RowCount > 1)
            {
                valuesTable.Rows.RemoveAt(valuesTable.RowCount-2);
            }

            Rebuild();
        }

        private void leftBorderTextBox_TextChanged(object sender, EventArgs e)
        {
            if(rightBorderTextBox.Text.Length > 0)
                Rebuild();
        }

        private void rightBorderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (leftBorderTextBox.Text.Length > 0)
                Rebuild();
        }
        
        private void borderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightBorderTextBox.Text.Length > 0 && leftBorderTextBox.Text.Length > 0)
                Rebuild();
        }
    }
}
