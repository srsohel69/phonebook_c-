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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);

            try
            {
                string sql = "INSERT INTO register (First_Name,Last_Name,Username,Password,Type) values ('" + txtFname.Text + "','" + txtLname.Text + "','" + txtUname.Text + "','"+txtPassword.Text+"','"+txtType.Text+"')";
                SqlCommand exesql = new SqlCommand(sql, cn);
                cn.Open();
                exesql.ExecuteNonQuery();
                MessageBox.Show("Add new record done !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
