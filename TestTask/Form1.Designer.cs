namespace TestTask
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.search = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.Button();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.save = new System.Windows.Forms.Button();
            this.countryidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capitalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viewer = new System.Windows.Forms.DataGridView();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.SaveLabelTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Viewer)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(275, 10);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(104, 23);
            this.search.TabIndex = 0;
            this.search.Text = "Найти страну";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.Search_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(12, 12);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(257, 20);
            this.TextBox.TabIndex = 1;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(601, 294);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Location = new System.Drawing.Point(12, 39);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(664, 95);
            this.ListBox.TabIndex = 8;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(564, 9);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(112, 23);
            this.save.TabIndex = 10;
            this.save.Text = "Сохранить страну";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // countryidDataGridViewTextBoxColumn
            // 
            this.countryidDataGridViewTextBoxColumn.Name = "countryidDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // codeNameDataGridViewTextBoxColumn
            // 
            this.codeNameDataGridViewTextBoxColumn.Name = "codeNameDataGridViewTextBoxColumn";
            // 
            // capitalDataGridViewTextBoxColumn
            // 
            this.capitalDataGridViewTextBoxColumn.Name = "capitalDataGridViewTextBoxColumn";
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            // 
            // populationDataGridViewTextBoxColumn
            // 
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            // 
            // regionDataGridViewTextBoxColumn
            // 
            this.regionDataGridViewTextBoxColumn.Name = "regionDataGridViewTextBoxColumn";
            // 
            // Viewer
            // 
            this.Viewer.AllowUserToAddRows = false;
            this.Viewer.AllowUserToDeleteRows = false;
            this.Viewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Viewer.Location = new System.Drawing.Point(12, 140);
            this.Viewer.Name = "Viewer";
            this.Viewer.ReadOnly = true;
            this.Viewer.Size = new System.Drawing.Size(664, 150);
            this.Viewer.TabIndex = 11;
            // 
            // SaveLabel
            // 
            this.SaveLabel.AutoSize = true;
            this.SaveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SaveLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.SaveLabel.Location = new System.Drawing.Point(12, 299);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(63, 15);
            this.SaveLabel.TabIndex = 12;
            this.SaveLabel.Text = "SomeText";
            this.SaveLabel.Visible = false;
            // 
            // SaveLabelTimer
            // 
            this.SaveLabelTimer.Interval = 1500;
            this.SaveLabelTimer.Tick += new System.EventHandler(this.SaveLabelTimerTick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 329);
            this.Controls.Add(this.SaveLabel);
            this.Controls.Add(this.Viewer);
            this.Controls.Add(this.save);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "TestTask";
            ((System.ComponentModel.ISupportInitialize)(this.Viewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capitalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView Viewer;
        private System.Windows.Forms.Label SaveLabel;
        private System.Windows.Forms.Timer SaveLabelTimer;
    }
}

