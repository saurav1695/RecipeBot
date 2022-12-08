
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Data.SqlClient;

namespace RecipeBot
{
    public partial class Form1 : Form
    {
        OracleConnection con = new OracleConnection(@"Data Source=MSI;User ID=system;Password=user");
        public Form1()
        {
          
            InitializeComponent();
        }
       
        private void login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.ForeColor=Color.White;
                panel5.Visible = false;
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.ForeColor = Color.White;
                panel7.Visible = false;
            }
            catch
            {

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text=="Enter UserName")
            {
                panel5.Visible = true;
                return;
                textBox1.Focus();
            }
            if (textBox2.Text == "Enter Password")
            {
                panel7.Visible = true;
                return;
                textBox2.Focus();
            }


            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                con.Open();
                string qry = "select * from login where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter(qry,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form3 f3 = new Form3();
                    f3.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid details");
                    textBox1.Clear();
                    textBox2.Clear();

                }
                
            }
            catch
            {
                MessageBox.Show("Invalid details");
                
            }
            finally
            {
                con.Close();
            }









        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            fm5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=M5JS3PulBPo");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();    
            fm2.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}