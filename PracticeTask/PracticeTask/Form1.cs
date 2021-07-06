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
        private List<DependentPoint> _points = new List<DependentPoint>();

        private Color _color = Color.Black;

        private Serialization _serializator;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            Text = "Форма ввода";
            valuesTable.Columns.Add("-", "x");
            valuesTable.Columns.Add("-", "y");

            _formulaInput = formulaRadioButton.Checked;
            _tableInput = tableRadioButton.Checked;

            SwitchVisibility();
            _graphicCanvas.OnPointPositionCorrected += _graphicCanvas_OnPointPositionCorrected;

            _serializator = new Serialization();
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
            if(rightBorderTextBox.Text.Length > 0 && leftBorderTextBox.Text.Length > 0 && leftBorderTextBox.Text != "-")
                Rebuild();
        }

        private void rightBorderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rightBorderTextBox.Text.Length > 0 && leftBorderTextBox.Text.Length > 0 && rightBorderTextBox.Text != "-")
                Rebuild();
            
        }

        private void RightBorderTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != 8) //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true;// то событие не обрабатывается. ch!=8 (8 - это Backspace)
            }
        }

        private void LeftBorderTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != 8) //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true;// то событие не обрабатывается. ch!=8 (8 - это Backspace)
            }
        }

        private void borderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightBorderTextBox.Text.Length > 0 && leftBorderTextBox.Text.Length > 0 && rightBorderTextBox.Text != "-" && leftBorderTextBox.Text != "-")
            {
                Rebuild();
            }
        }

        private void colorChangeButton_Click(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReference();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            ResetGraphic();
        }
    }
}
