using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace project_demo
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
                cn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * FROM data_test Where Name like '" + textBox1.Text + "%'", cn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                cn.Close();
            }
            else {
                SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
                cn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * FROM data_test Where Mobile like '" + textBox1.Text + "%'", cn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                cn.Close();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.data_test' table. You can move, or remove it, as needed.
            this.data_testTableAdapter.Fill(this.database1DataSet2.data_test);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
