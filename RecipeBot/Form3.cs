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
    public partial class Form3 : Form
    {
            OracleConnection con=new OracleConnection(@"Data Source=MSI;User ID=system;Password=user");
        public static string nameh;
        public static int idx=0;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("insert into temp1 values('" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            listBox1.Items.Add(textBox1.Text);
            //MessageBox.Show("inserted");
            textBox1.Clear();


            con.Open();
            OracleCommand cmd1 = new OracleCommand("create or replace trigger trig\r\nbefore insert on temp1\r\nfor each row\r\nbegin \r\ndelete from  temp1 where ingredient_name=:new.ingredient_name;\r\nend;", con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {   
            con.Open();
            OracleCommand cmd2 = new OracleCommand("DECLARE \r\n    id int;\r\n   CURSOR c is \r\n      SELECT ingredients.ingredient_id from ingredients,temp1 where ingredients.ingredient_name=temp1.ingredient_name; \r\nBEGIN \r\n   OPEN c; \r\n   LOOP \r\n   FETCH c into id; \r\n      EXIT WHEN c%notfound; \r\n       insert into temp2 values(id);\r\n   END LOOP; \r\n   CLOSE c; \r\nEND;", con);
            cmd2.ExecuteNonQuery();

            OracleCommand cmd1 = new OracleCommand("DECLARE \r\n  a number(2);\r\ndishcount int; \r\n\r\nBEGIN \r\n\tselect count(dish_id) into dishcount from dish; \r\n   \tFOR a in 1..dishcount LOOP\r\n\t\r\n      DECLARE\r\n\tchk int;\r\n\tid int;\r\n\tCURSOR c1 is\r\n\tselect recipe.ingredient_id from recipe where recipe.dish_id=a;\r\n       BEGIN\r\n\tOPEN c1;\r\n\tLOOP\r\n\tFETCH c1 into id;\r\n \tEXIT WHEN c1%notfound; \r\n\tinsert into temp3 values(id);\r\n\tEND LOOP;\r\n\tselect count(*) into chk from (select * from temp3 except select * from temp2);\r\n\tIF(chk=0) THEN\r\n\tinsert into temp4 values(a);\r\n\tEND IF;\r\n\tCLOSE c1;\r\n\tEND;\r\n\tdelete  from temp3;\r\n          END LOOP;\r\n\t\r\nEND;  ", con);
            cmd1.ExecuteNonQuery();
          
          
            OracleCommand cmd = new OracleCommand("begin\r\nfor i in (select dish_id from temp4) \r\nloop\r\ndeclare\r\np int;\r\nf int;\r\ncc int;\r\ncal int;\r\nid int;\r\ncursor c is \r\nselect sum(protein),sum(carbs),sum(fats),sum(calories) from nutritional_info where ingredient_id in(select ingredient_id from recipe where recipe.dish_id in i.dish_id);\r\nbegin\r\nopen c;\r\nloop\r\nfetch c into p,cc,f,cal;\r\nexit when c%notfound;\r\ninsert into protein values(i.dish_id,p);\r\ninsert into carbs values(i.dish_id,cc);\r\ninsert into fats values(i.dish_id,f);\r\ninsert into calories values(i.dish_id,cal);\r\nend loop;\r\nclose c;\r\nend;\r\nend loop;\r\nend;\r\n ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            

            Form5 fm5=new Form5();
            fm5.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
            con.Open();
            
            OracleCommand cmd = new OracleCommand("drop trigger trig",con);
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(); 
            f4.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            idx = 1;
            nameh = "Veg Burger";
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            idx = 1;
            nameh = "white cake";
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            idx = 1;
            nameh = "banana nut oatmeal";
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            idx = 1;
            nameh = "Galician pie";
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            idx = 1;
            nameh = "Paneer Butter Masala";
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            idx = 1;
            nameh = "Chicken Biryani";
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
    }
}
