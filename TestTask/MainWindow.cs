using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestTask
{
    public partial class MainWindow : Form
    {
        APIreader apireader;
        MSSQL mssql = new MSSQL();

        public MainWindow()
        {
            InitializeComponent();
            Viewer.DataSource = mssql.Load();
        }

        private void SearchClick(object sender, EventArgs e)
        {
            ListBox.Items.Clear();
            if (apireader == null || apireader.CheckNewCountry(TextBox.Text))
            {
                apireader = new APIreader(TextBox.Text);
            }
            ListBox.Items.AddRange(apireader.allData);
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (mssql.Save(apireader))
            {
                SaveLabel.ForeColor = Color.DarkGreen;
                SaveLabel.Text = "Успешно сохранено";
            }
            else
            {
                SaveLabel.ForeColor = Color.DarkRed;
                SaveLabel.Text = "Ошибка, попробуйте повторно найти страну";
            }
            SaveLabel.Visible = true;
            SaveLabelTimer.Enabled = true;
            Viewer.DataSource = mssql.Load();
        }

        private void SaveLabelTimerTick(object sender, EventArgs e)
        {
            SaveLabel.Visible = false;
            SaveLabelTimer.Enabled = false;

        }
    }
}
