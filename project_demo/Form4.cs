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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.emergency' table. You can move, or remove it, as needed.
            this.emergencyTableAdapter.Fill(this.database1DataSet3.emergency);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * FROM emergency ;", cn);
           // cn.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("Select * FROM emergency ;", cn);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;
                dataGridView1.DataSource = bsource;
                sda.Update(dt);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //DataTable dt = new DataTable();
           // sda.Fill(dt);
           // dataGridView1.DataSource = dt;
            //cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
