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
using System.IO;



namespace project_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.data_test' table. You can move, or remove it, as needed.
            this.data_testTableAdapter1.Fill(this.database1DataSet2.data_test);
            // TODO: This line of code loads data into the 'database1DataSet.data_test' table. You can move, or remove it, as needed.
            //this.data_testTableAdapter.Fill(this.database1DataSet.data_test);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] imagebt = null;
            FileStream fstream = new FileStream(this.txtImage_path.Text,FileMode.Open,FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imagebt = br.ReadBytes((int)fstream.Length);



            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
            

            try
            {
                string sql = "INSERT INTO data_test (Id,Name,Mobile,Address,Email,Category,Image) values (" + txtId.Text + ",'" + txtName.Text + "','" + txtMobile.Text + "','"+txtAddress.Text+"','"+txtEmail.Text+"','"+ txtCategory.Text + "',@IMG)";
                SqlCommand exesql = new SqlCommand(sql, cn);
               
                cn.Open();
                exesql.Parameters.Add(new SqlParameter("@IMG", imagebt));
                exesql.ExecuteNonQuery();
                MessageBox.Show("Add new record done !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.data_testTableAdapter.Fill(this.database1DataSet.data_test);
                this.data_testTableAdapter1.Fill(this.database1DataSet2.data_test);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Clear();
            txtMobile.Text = "";
            txtAddress.Clear();
            txtEmail.Text = "";
            txtCategory.SelectedIndex=-1;
            pictureBox1.Image = null;
            

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            
            
            //this.data_testTableAdapter1.Fill(this.database1DataSet2.data_test);
           // txtId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMobile.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtAddress.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtCategory.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
            SqlCommand command;
            SqlDataAdapter da = new SqlDataAdapter() ;
            DataTable dt = new DataTable();
            string query = "Select Image From data_test Where Id=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";
            command = new SqlCommand(query, cn);
            da = new SqlDataAdapter(command);
            
            DataSet ds = new DataSet();
            byte[] img = new byte[0];
            da.Fill(ds,"data_test");
            DataRow myrow;
            myrow = ds.Tables["data_test"].Rows[0];
            img = (byte[])myrow["Image"]; 
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

           SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);

            try
            {
                string sql = "DELETE FROM data_test Where (Id=" + txtId.Text + ")" ;
                SqlCommand exesql = new SqlCommand(sql, cn);
                cn.Open();
                exesql.ExecuteNonQuery();
                MessageBox.Show("Remove successfully !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.data_testTableAdapter.Fill(this.database1DataSet.data_test);
                this.data_testTableAdapter1.Fill(this.database1DataSet2.data_test);
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

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] imagebt = null;
            FileStream fstream = new FileStream(this.txtImage_path.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imagebt = br.ReadBytes((int)fstream.Length);

            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);

            try
            {
                string sql = "UPDATE  data_test SET Id=" + txtId.Text + ",Name='" + txtName.Text + "',Mobile='" + txtMobile.Text + "',Address='" + txtAddress.Text + "',Email='" + txtEmail.Text + "',Category='" + txtCategory.Text + "',Image=@IMG WHERE (Id=" + txtId.Text+")";
                SqlCommand exesql = new SqlCommand(sql, cn);
                cn.Open();
                exesql.Parameters.Add(new SqlParameter("@IMG", imagebt));
                exesql.ExecuteNonQuery();
                MessageBox.Show("Update successfully !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.data_testTableAdapter.Fill(this.database1DataSet.data_test);
                this.data_testTableAdapter1.Fill(this.database1DataSet2.data_test);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog()==DialogResult.OK)

            {
                String picpath = dlg.FileName.ToString();
                txtImage_path.Text = picpath;
                pictureBox1.ImageLocation = picpath;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::project_demo.Properties.Settings.Default.Database1ConnectionString);
            SqlCommand command;
            SqlDataAdapter da;
            string query = "Select * From data_test Where Id=" + txtId.Text + "";
            command = new SqlCommand(query, cn);
            da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtId.Text = dt.Rows[0][0].ToString();
            txtName.Text = dt.Rows[0][1].ToString();
            txtMobile.Text = dt.Rows[0][2].ToString();
            txtAddress.Text = dt.Rows[0][3].ToString();
            txtEmail.Text = dt.Rows[0][4].ToString();
            txtCategory.Text = dt.Rows[0][5].ToString();

            byte[] img = (byte[])dt.Rows[0][6];
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            da.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }
    }
}
