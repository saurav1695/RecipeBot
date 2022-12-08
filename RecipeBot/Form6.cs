using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace RecipeBot
{       
    public partial class Form6 : Form
    {
        OracleConnection con = new OracleConnection(@"Data Source=MSI;User ID=system;Password=user");
        public Form6()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            int id1 = Form5.dish_id;
            string id = id1.ToString();
            textBox1.Text=Form5.name;

            con.Open();
            OracleCommand cmd = new OracleCommand("begin\r\nfor i in (select dish_id from temp4) \r\nloop\r\ndeclare\r\np int;\r\nf int;\r\ncc int;\r\ncal int;\r\nid int;\r\ncursor c is \r\nselect sum(protein),sum(carbs),sum(fats),sum(calories) from nutritional_info where ingredient_id in(select ingredient_id from recipe where recipe.dish_id in i.dish_id);\r\nbegin\r\nopen c;\r\nloop\r\nfetch c into p,cc,f,cal;\r\nexit when c%notfound;\r\ninsert into protein values(i.dish_id,p);\r\ninsert into carbs values(i.dish_id,cc);\r\ninsert into fats values(i.dish_id,f);\r\ninsert into calories values(i.dish_id,cal);\r\nend loop;\r\nclose c;\r\nend;\r\nend loop;\r\nend;", con);

            cmd.ExecuteNonQuery();
         
            con.Close();


            con.Open();
            OracleCommand com = new OracleCommand("select protein.value as p,carbs.value as c,fats.value as f,calories.value as cal from protein,carbs,fats,calories where protein.dish_id in :id and carbs.dish_id in :id and fats.dish_id in :id and calories.dish_id in :id", con);
            OracleParameter pa1 = new OracleParameter();
            pa1.ParameterName = "id";
            pa1.DbType = DbType.String;
            pa1.Value = id;
            com.Parameters.Add(pa1);
            OracleDataReader reader1;
            reader1 = com.ExecuteReader();
            if (reader1.Read())
            {
                textBox2.Text = reader1["p"].ToString();
                textBox3.Text = reader1["c"].ToString();
                textBox4.Text = reader1["f"].ToString();
                textBox5.Text = reader1["cal"].ToString();
                
            }
            con.Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();

        }
    }
}
