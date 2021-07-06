
namespace PracticeTask
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.valuesTable = new System.Windows.Forms.DataGridView();
            this.buildButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.formulaTextBox = new System.Windows.Forms.TextBox();
            this.tableRadioButton = new System.Windows.Forms.RadioButton();
            this.formulaRadioButton = new System.Windows.Forms.RadioButton();
            this.leftBorderTextBox = new System.Windows.Forms.TextBox();
            this.rightBorderTextBox = new System.Windows.Forms.TextBox();
            this.borderCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paceTextBox = new System.Windows.Forms.TextBox();
            this.paceLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorChangeButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnButton = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this._graphicCanvas = new WpfGraphic.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.valuesTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // valuesTable
            // 
            this.valuesTable.AllowUserToDeleteRows = false;
            this.valuesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.valuesTable.Location = new System.Drawing.Point(13, 51);
            this.valuesTable.Name = "valuesTable";
            this.valuesTable.Size = new System.Drawing.Size(242, 532);
            this.valuesTable.TabIndex = 0;
            this.valuesTable.TabStop = false;
            this.valuesTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.valuesTable_CellEndEdit);
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(261, 127);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(96, 44);
            this.buildButton.TabIndex = 1;
            this.buildButton.TabStop = false;
            this.buildButton.Text = "Построить";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(363, 127);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(96, 44);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.TabStop = false;
            this.deleteButton.Text = "Удалить пару";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // formulaTextBox
            // 
            this.formulaTextBox.Location = new System.Drawing.Point(12, 27);
            this.formulaTextBox.Name = "formulaTextBox";
            this.formulaTextBox.Size = new System.Drawing.Size(349, 20);
            this.formulaTextBox.TabIndex = 3;
            this.formulaTextBox.Visible = false;
            // 
            // tableRadioButton
            // 
            this.tableRadioButton.AutoSize = true;
            this.tableRadioButton.Checked = true;
            this.tableRadioButton.Location = new System.Drawing.Point(261, 53);
            this.tableRadioButton.Name = "tableRadioButton";
            this.tableRadioButton.Size = new System.Drawing.Size(68, 17);
            this.tableRadioButton.TabIndex = 4;
            this.tableRadioButton.TabStop = true;
            this.tableRadioButton.Text = "Таблица";
            this.tableRadioButton.UseVisualStyleBackColor = true;
            this.tableRadioButton.Visible = false;
            this.tableRadioButton.CheckedChanged += new System.EventHandler(this.tableRadioButton_CheckedChanged);
            // 
            // formulaRadioButton
            // 
            this.formulaRadioButton.AutoSize = true;
            this.formulaRadioButton.Location = new System.Drawing.Point(261, 76);
            this.formulaRadioButton.Name = "formulaRadioButton";
            this.formulaRadioButton.Size = new System.Drawing.Size(73, 17);
            this.formulaRadioButton.TabIndex = 5;
            this.formulaRadioButton.Text = "Формула";
            this.formulaRadioButton.UseVisualStyleBackColor = true;
            this.formulaRadioButton.Visible = false;
            this.formulaRadioButton.CheckedChanged += new System.EventHandler(this.formulaRadioButton_CheckedChanged);
            // 
            // leftBorderTextBox
            // 
            this.leftBorderTextBox.Location = new System.Drawing.Point(261, 50);
            this.leftBorderTextBox.Name = "leftBorderTextBox";
            this.leftBorderTextBox.Size = new System.Drawing.Size(100, 20);
            this.leftBorderTextBox.TabIndex = 6;
            this.leftBorderTextBox.TabStop = false;
            this.leftBorderTextBox.TextChanged += new System.EventHandler(this.leftBorderTextBox_TextChanged);
            // 
            // rightBorderTextBox
            // 
            this.rightBorderTextBox.Location = new System.Drawing.Point(261, 77);
            this.rightBorderTextBox.Name = "rightBorderTextBox";
            this.rightBorderTextBox.Size = new System.Drawing.Size(100, 20);
            this.rightBorderTextBox.TabIndex = 7;
            this.rightBorderTextBox.TabStop = false;
            this.rightBorderTextBox.TextChanged += new System.EventHandler(this.rightBorderTextBox_TextChanged);
            // 
            // borderCheckBox
            // 
            this.borderCheckBox.AutoSize = true;
            this.borderCheckBox.Location = new System.Drawing.Point(262, 104);
            this.borderCheckBox.Name = "borderCheckBox";
            this.borderCheckBox.Size = new System.Drawing.Size(164, 17);
            this.borderCheckBox.TabIndex = 8;
            this.borderCheckBox.TabStop = false;
            this.borderCheckBox.Text = "Использовать промежуток";
            this.borderCheckBox.UseVisualStyleBackColor = true;
            this.borderCheckBox.CheckedChanged += new System.EventHandler(this.borderCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Левая граница";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Правая граница";
            // 
            // paceTextBox
            // 
            this.paceTextBox.Location = new System.Drawing.Point(13, 54);
            this.paceTextBox.Name = "paceTextBox";
            this.paceTextBox.Size = new System.Drawing.Size(100, 20);
            this.paceTextBox.TabIndex = 11;
            this.paceTextBox.Text = "1";
            this.paceTextBox.Visible = false;
            // 
            // paceLabel
            // 
            this.paceLabel.AutoSize = true;
            this.paceLabel.Location = new System.Drawing.Point(13, 77);
            this.paceLabel.Name = "paceLabel";
            this.paceLabel.Size = new System.Drawing.Size(73, 13);
            this.paceLabel.TabIndex = 12;
            this.paceLabel.Text = "Шаг графика";
            this.paceLabel.Visible = false;
            // 
            // colorChangeButton
            // 
            this.colorChangeButton.Location = new System.Drawing.Point(262, 177);
            this.colorChangeButton.Name = "colorChangeButton";
            this.colorChangeButton.Size = new System.Drawing.Size(96, 45);
            this.colorChangeButton.TabIndex = 14;
            this.colorChangeButton.TabStop = false;
            this.colorChangeButton.Text = "Изменить цвет графика";
            this.colorChangeButton.UseVisualStyleBackColor = true;
            this.colorChangeButton.Click += new System.EventHandler(this.colorChangeButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.referenceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1255, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // referenceToolStripMenuItem
            // 
            this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
            this.referenceToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.referenceToolStripMenuItem.Text = "Справка";
            this.referenceToolStripMenuItem.Click += new System.EventHandler(this.referenceToolStripMenuItem_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(364, 177);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(96, 45);
            this.returnButton.TabIndex = 17;
            this.returnButton.TabStop = false;
            this.returnButton.Text = "Вернуть график в центр";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(464, 27);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(779, 605);
            this.elementHost1.TabIndex = 13;
            this.elementHost1.TabStop = false;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this._graphicCanvas;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 646);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.colorChangeButton);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.paceLabel);
            this.Controls.Add(this.paceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.borderCheckBox);
            this.Controls.Add(this.rightBorderTextBox);
            this.Controls.Add(this.leftBorderTextBox);
            this.Controls.Add(this.formulaRadioButton);
            this.Controls.Add(this.tableRadioButton);
            this.Controls.Add(this.formulaTextBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.valuesTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.valuesTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView valuesTable;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox formulaTextBox;
        private System.Windows.Forms.RadioButton tableRadioButton;
        private System.Windows.Forms.RadioButton formulaRadioButton;
        private System.Windows.Forms.TextBox leftBorderTextBox;
        private System.Windows.Forms.TextBox rightBorderTextBox;
        private System.Windows.Forms.CheckBox borderCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox paceTextBox;
        private System.Windows.Forms.Label paceLabel;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorChangeButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private WpfGraphic.UserControl1 _graphicCanvas;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;
        private System.Windows.Forms.Button returnButton;
    }
}

