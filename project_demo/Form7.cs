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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

        private void clear()
        {
            txtName.Clear();
            txtMobile.Text = "";
            txtAddress.Clear();
            txtEmail.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);


            try
            {
                string sql = "INSERT INTO emergency (Name,Mobile,Address,Email) values ('" + txtName.Text + "','" + txtMobile.Text + "','" + txtAddress.Text + "','" + txtEmail.Text + "')";
                SqlCommand exesql = new SqlCommand(sql, cn);

                cn.Open();
                //exesql.Parameters.Add(new SqlParameter("@IMG", imagebt));
                exesql.ExecuteNonQuery();
                MessageBox.Show("Add new record done !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.data_testTableAdapter.Fill(this.database1DataSet.data_test);
                //this.data_testTableAdapter1.Fill(this.database1DataSet2.data_test);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally

            {
                cn.Close();
            }
        }
    }
}
