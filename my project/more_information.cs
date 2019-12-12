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
    public partial class more_information : Form
    {
        Int64 value = 0;
        public more_information(Int64 id_vallue)
        {
            InitializeComponent();
            value = id_vallue;
            
            
        }
        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");

        private void more_information_Load(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand com = new SqlCommand("select company_name,contact_person,address,phone_primary,phone_puplic,e_mail,card_num,card_verification_num,card_type,expiration_month,expiration_year,cardholder_name,shipping_address,sales_person,customer_notes,custmer_group,blance from customer where customer_id='" + value + "'", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                maskedTextBox1.Text = dr[3].ToString();
                maskedTextBox2.Text = dr[4].ToString();
                textBox4.Text = dr[5].ToString();
                maskedTextBox3.Text = dr[6].ToString();
                maskedTextBox4.Text = dr[7].ToString();
                textBox10.Text = dr[8].ToString();
                textBox11.Text = dr[9].ToString();
                textBox12.Text = dr[10].ToString();
                textBox5.Text = dr[11].ToString();
               
                textBox6.Text = dr[12].ToString();
                textBox7.Text = dr[13].ToString();
                textBox8.Text = dr[14].ToString();
                textBox9.Text = dr[15].ToString();
                maskedTextBox5.Text = dr[16].ToString();
            }
            dr.Close();
            con.Close();
        }
       
    }
}
