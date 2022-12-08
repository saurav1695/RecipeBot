using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeBot
{
    public partial class Form2 : Form
    {
        OracleConnection con = new OracleConnection(@"Data Source = MSI; User ID = system; Password=user");
        public Form2()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {   if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Incomplete Details!");

            }

            else
            {

                if (textBox4.Text != textBox5.Text)
                {
                    label8.Visible = true;
                }
                else
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("insert into login values('" + textBox2.Text + "','" + textBox4.Text + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    OracleCommand cmd1 = new OracleCommand("create or replace trigger trig1\r\nbefore insert on login\r\nfor each row\r\nbegin \r\ndelete from  login where username=:new.username;\r\nend;",con);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Inserted");
                    con.Close();
                    Form1 fm1 = new Form1();
                    fm1.Show();
                    this.Hide();
                }
            }
            
        }
    }
}
