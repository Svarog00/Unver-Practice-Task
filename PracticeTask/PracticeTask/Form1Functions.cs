using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointClassLibrary;


namespace PracticeTask
{
    partial class Form1 : Form
    {
        private bool _formulaInput;
        private bool _tableInput;
        private bool _graphicDrawn = false;

        private double _leftBorder = double.NaN;
        private double _rightBorder = double.NaN;

        //Включение\отключение видимости полей для ввода графика
        private void SwitchVisibility()
        {
            _tableInput = tableRadioButton.Checked;
            _formulaInput = formulaRadioButton.Checked;

            valuesTable.Visible = _tableInput;
            formulaTextBox.Visible = _formulaInput;
            paceLabel.Visible = _formulaInput;
            paceTextBox.Visible = _formulaInput;
        }

        //Создание графика на основе таблицы или введенной формулы
        private void Build()
        {
            try
            {
                if (_formulaInput)
                {
                    //Call parser instance to parse formula
                }
                else if (_tableInput)
                {
                    TableInput();
                }
                _graphicCanvas.SetData(_points, _color.R, _color.G, _color.B);
                _graphicCanvas.Draw();
                _graphicDrawn = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //Перерисовка графика на основе изменений таблицы
        private void Rebuild()
        {
            try
            {
                if (_graphicDrawn)
                {
                    if (_tableInput)
                    {
                        TableInput();
                    }
                    _graphicCanvas.SetData(_points, _color.R, _color.G, _color.B);
                    _graphicCanvas.Draw();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //Сохранение введенных значений границ графика в отдельных переменных
        private void AdjustBorders()
        {
            try
            {
                _leftBorder = Convert.ToDouble(leftBorderTextBox.Text);
                _rightBorder = Convert.ToDouble(rightBorderTextBox.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //Функция для получения значений из таблицы для постройки графика
        private void TableInput()
        {
            if (!borderCheckBox.Checked)
                _points.FormListFromTable(valuesTable);
            else
            {
                AdjustBorders();
                _points.FormListFromTable(valuesTable, _leftBorder, _rightBorder);
            }

            _points.Sort();
        }
        //Проверка на то, чтобы не было несколько иксов. На вход получает индекс строки, в которой происходит изменение
        private void CheckXs(int index)
        {
            try
            {
                double newValue = Convert.ToDouble(valuesTable.Rows[index].Cells[0].Value);
                double xi;
                for (int i = 0; i < valuesTable.RowCount - 1; i++)
                {
                    xi = Convert.ToDouble(valuesTable.Rows[i].Cells[0].Value);
                    if (i == index)
                    {
                        continue;
                    }
                    if (newValue == xi)
                    {
                        valuesTable.Rows[index].Cells[0].Value = null;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        
        private void _graphicCanvas_OnPointPositionCorrected(object sender, WpfGraphic.UserControl1.OnPointPositionCorrectedEventArgs e)
        {
            _points[e.index].X = e.newX;
            _points[e.index].Y = e.newY;
            ReloadTable();
        }

        private void ChangeColor()
        {
            colorDialog1.ShowDialog();
            _color = colorDialog1.Color;
            Rebuild();
        }

        private void ReloadTable()
        {
            try
            {
                for (int i = 0; i < _points.Count; i++)
                {
                    if (i == valuesTable.RowCount-1)
                    {
                        valuesTable.Rows.Add();
                    }
                    valuesTable.Rows[i].Cells[0].Value = _points[i].X.ToString();
                    valuesTable.Rows[i].Cells[1].Value = _points[i].Y.ToString();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SaveFile()
        {
            try
            {
                TableInput();
                saveFileDialog1.ShowDialog();
                string path = saveFileDialog1.FileName;
                _serializator.SaveData(_points, path);
                ReloadTable();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void LoadFromFile()
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            _points = _serializator.LoadData(path);
            ReloadTable();
        }

        private void ShowReference()
        {
            //MessageBox.Show();
        }
    }
}
