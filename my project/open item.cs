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
    public partial class open_item : Form
    {
        Int64 valuee = 0;
        public open_item(Int64 idd)
        {
            InitializeComponent();
            valuee = idd;
        }
        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");

        private void open_item_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select item_code,item_name,item_describtion,unit_value,current_quantaty,ideal_quantaty,warning_quantaty from items where items_id='"+valuee+"'", con);
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
    }
}
