using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace my_project
{
    public partial class update_item : Form
    {
        string valuee = "";
        public update_item(string id)
        {
            InitializeComponent();
            valuee = id;
        }
        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");
        private void update_item_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select item_code,item_name,item_describtion,unit_value,current_quantaty,ideal_quantaty,warning_quantaty from items where item_code='" + valuee + "'", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                maskedTextBox1.Text = dr[3].ToString();
                maskedTextBox2.Text = dr[4].ToString();
                maskedTextBox3.Text = dr[5].ToString();
                maskedTextBox4.Text = dr[6].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string code = textBox1.Text;
                string name = textBox3.Text;
                string describtion = textBox2.Text;
                double price = double.Parse(maskedTextBox1.Text.ToString());
                Int64 quantaty = Int64.Parse(maskedTextBox2.Text.ToString());
                Int64 ideal = Int64.Parse(maskedTextBox3.Text.ToString());
                Int64 warnning = Int64.Parse(maskedTextBox4.Text.ToString());
                ado_project d = new ado_project();
                d.update_item(valuee, code, name, describtion, price, quantaty, ideal, warnning);
                MessageBox.Show("Done");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                maskedTextBox3.Text = "";
                maskedTextBox4.Text = "";
            }
            catch (Exception)
            { MessageBox.Show("Try Again"); }
            //update_item up = new update_item();
            //up.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
