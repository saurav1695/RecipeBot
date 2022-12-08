using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipeBot
{
    public partial class Form5 : Form
    {
        OracleConnection con = new OracleConnection(@"Data Source=MSI;User ID=system;Password=user");
        DataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        OracleCommand comm;
        int i = 1;
        public static string name;
        public static int dish_id ;

        public Form5()
        {
            InitializeComponent();
            fillcombo();
        }
        void fillcombo()
        {
            OracleConnection con = new OracleConnection(@"Data Source=MSI;User ID=system;Password=user");
            string query = "select dish_name from dish,temp4 where dish.dish_id=temp4.dish_id";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader myreader;

            try
            {
                con.Open();
                myreader=cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string name=myreader.GetString("dish_name");
                    comboBox1.Items.Add(name);

                }
            }
            catch(Exception ex)
            {
                  
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=M5JS3PulBPo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=M5JS3PulBPo");
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (Form3.idx == 1)
            {

                name = Form3.nameh;
                


                con.Open();
                OracleCommand com = new OracleCommand("select dish_name,recipe_link,video_link,time_to_cook,prefernce from dish where dish_name=:name", con);
                OracleParameter pa4 = new OracleParameter();
                pa4.ParameterName = "name";
                pa4.DbType = DbType.String;
                pa4.Value = name;
                com.Parameters.Add(pa4);
                OracleDataReader reader1;
                reader1 = com.ExecuteReader();
                if (reader1.Read())
                {
                    textBox1.Text = reader1["dish_name"].ToString();
                    textBox2.Text = reader1["recipe_link"].ToString();
                    textBox3.Text = reader1["video_link"].ToString();
                    textBox4.Text = reader1["time_to_cook"].ToString();
                    textBox6.Text = reader1["prefernce"].ToString();
                }
                if (textBox6.Text == "veg")
                {
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = false;
                }
                if (textBox6.Text == "non veg")
                {
                    pictureBox3.Visible = true;
                    pictureBox2.Visible = false;
                }
                if (name == "Veg Burger")
                {
                    pictureBox1.Image = Image.FromFile("7.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (name == "Chicken Biryani")
                {
                    pictureBox1.Image = Image.FromFile("8.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (name == "white cake")
                {
                    pictureBox1.Image = Image.FromFile("1.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (name == "banana nut oatmeal")
                {
                    pictureBox1.Image = Image.FromFile("2.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (name == "Galician pie")
                {
                    pictureBox1.Image = Image.FromFile("3.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (name == "Paneer Butter Masala")
                {
                    pictureBox1.Image = Image.FromFile("5.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             name = comboBox1.Text.ToString();
            try { con.Open(); }
            catch (Exception ex)
            {

            }
            
            OracleCommand com = new OracleCommand("select dish_name,recipe_link,video_link,time_to_cook,prefernce from dish where dish_name=:name",con);
            OracleParameter pa4 = new OracleParameter();
            pa4.ParameterName = "name";
            pa4.DbType = DbType.String;
            pa4.Value = name;
            com.Parameters.Add(pa4);
            OracleDataReader reader1;
            reader1 = com.ExecuteReader();
            if (reader1.Read())
            {
                textBox1.Text = reader1["dish_name"].ToString();
                textBox2.Text = reader1["recipe_link"].ToString();
                textBox3.Text = reader1["video_link"].ToString();
                textBox4.Text = reader1["time_to_cook"].ToString();
                textBox6.Text = reader1["prefernce"].ToString();
            }
            if (textBox6.Text == "veg")
            {
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
            }
            if(textBox6.Text=="non veg")
            {
                pictureBox3.Visible = true;
                pictureBox2.Visible = false;
            }

            OracleCommand com1 = new OracleCommand("select dish_id from dish where dish_name =:name", con);
            OracleParameter pa5 = new OracleParameter();
            pa5.ParameterName = "name";
            pa5.DbType = DbType.String;
            pa5.Value = name;
            com1.Parameters.Add(pa5);
            OracleDataReader reader2;
            reader2 = com1.ExecuteReader();
            if (reader2.Read())
            {
                textBox7.Text = reader2["dish_id"].ToString(); 
                
            }
           dish_id=Int32.Parse(textBox7.Text);

            if (dish_id == 1)
            {
                pictureBox1.Image = Image.FromFile("1.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 2)
            {
                pictureBox1.Image = Image.FromFile("2.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 3)
            {
                pictureBox1.Image = Image.FromFile("3.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 4)
            {
                pictureBox1.Image = Image.FromFile("4.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            if (dish_id == 5)
            {
                pictureBox1.Image = Image.FromFile("5.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 6)
            {
                pictureBox1.Image = Image.FromFile("6.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 7)
            {
                pictureBox1.Image = Image.FromFile("7.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 8)
            {
                pictureBox1.Image = Image.FromFile("8.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 9)
            {
                pictureBox1.Image = Image.FromFile("9.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (dish_id == 10)
            {
                pictureBox1.Image = Image.FromFile("10.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            con.Close();


        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
                con.Open();
            }
            catch(Exception ex1)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
