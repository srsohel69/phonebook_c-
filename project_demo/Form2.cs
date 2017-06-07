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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From register where Username='"+txtUsername.Text+"' and Password='"+txtpassword.Text+"' ",cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlConnection cn1 = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
                SqlDataAdapter sda1 = new SqlDataAdapter("Select Type From register where Username='" + txtUsername.Text + "' and Password='" + txtpassword.Text + "' ", cn1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);


                 if (dt1.Rows[0][0].ToString() == "Admin")
                 {
                     this.Hide();
                     Form6 f6 = new Form6();
                     f6.ShowDialog();
                 }
                 if (dt1.Rows[0][0].ToString() == "Client")
                 {
                     this.Hide();
                     Form8 f8 = new Form8();
                     f8.ShowDialog();
                    //button2.Enabled = false;
                  // ( this.Owner as Form8).button2.Enabled = false;
                 }


            }
            else
            {
                 MessageBox.Show("please check your username & password");
               
            }
        }
          

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
