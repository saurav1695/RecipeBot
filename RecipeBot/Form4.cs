using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
namespace RecipeBot
{
    public partial class Form4 : Form
    {
        OracleConnection con = new OracleConnection(@"Data Source=MSI;User ID=system;Password=user");
        public Form4()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            }
            catch (Exception ex1)
            {

            }
            OracleCommand cmd = new OracleCommand("drop trigger trig", con);
            OracleCommand cmd1 = new OracleCommand("delete  from temp1", con);
            OracleCommand cmd2 = new OracleCommand("delete  from temp2", con);
            OracleCommand cmd3 = new OracleCommand("delete  from temp3", con);
            OracleCommand cmd4 = new OracleCommand("delete  from temp4", con);
            OracleCommand cmd5 = new OracleCommand("delete  from protein", con);
            OracleCommand cmd6 = new OracleCommand("delete  from fats", con);
            OracleCommand cmd7 = new OracleCommand("delete  from carbs", con);
            OracleCommand cmd8 = new OracleCommand("delete  from calories", con);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            cmd6.ExecuteNonQuery();
            cmd7.ExecuteNonQuery();
            cmd8.ExecuteNonQuery();
            con.Close();
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
