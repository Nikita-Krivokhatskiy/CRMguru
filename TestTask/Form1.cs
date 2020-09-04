using System;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = mssql.Load();
        }
        APIreader apireader;
        MSSQL mssql = new MSSQL();
        private void search_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (apireader == null || apireader.NewCountry(textBox1.Text))
            {

                apireader = new APIreader(textBox1.Text);
            }
            listBox1.Items.AddRange(apireader.All);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (apireader.Country != null)//Если страна не найдена или поиск не проводился, то выдаем ошибку
            {
                mssql.Save(apireader);
                dataGridView1.DataSource = mssql.Load();
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Вы не выбрали страну");
            }
        }
    }
}
