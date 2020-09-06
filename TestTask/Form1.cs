using System;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        APIreader Apireader;
        MSSQL Mssql = new MSSQL();

        public Form1()
        {
            InitializeComponent();
            Viewer.DataSource = Mssql.Load();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            ListBox.Items.Clear();
            if (Apireader == null || Apireader.CheckNewCountry(TextBox.Text))
            {

                Apireader = new APIreader(TextBox.Text);
            }
            ListBox.Items.AddRange(Apireader.All);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Apireader.Country != null)//Если страна не найдена или поиск не проводился, то выдаем ошибку
            {
                SaveLabel.Text = Mssql.Save(Apireader);
                SaveLabel.Visible = true;
                SaveLabelTimer.Enabled = true;
                Viewer.DataSource = Mssql.Load();
            }
            else
            {
                ListBox.Items.Clear();
                ListBox.Items.Add("Вы не выбрали страну");
            }
        }

        private void SaveLabelTimerTick(object sender, EventArgs e)
        {
            SaveLabel.Visible = false;
            SaveLabelTimer.Enabled = false;

        }
    }
}
