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
    public partial class update_customer : Form
    {
        Int64 value = 0;
        public update_customer(Int64 id)
        {
            InitializeComponent();
            value = id;
        }
        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");


        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ado_project dd = new ado_project();
            try
            {
                Int64 idd = value; 
                string comp_name = textBox1.Text;
                string contact_person = textBox2.Text;
                string address = textBox3.Text;
                Int64 phone_prim = Int64.Parse(maskedTextBox1.Text);
                Int64 phone_alt = Int64.Parse(maskedTextBox2.Text);
                string email = textBox4.Text;
                Int64 card_numm = Int64.Parse(maskedTextBox3.Text);
                Int64 cardverification_num = Int64.Parse(maskedTextBox4.Text);
                string cardtype = comboBox1.Text.ToString();
                Int64 expiration_month = Int64.Parse(comboBox2.Text.ToString());
                Int64 expiration_year = Int64.Parse(comboBox3.Text.ToString());
                string card_holder = textBox5.Text;

                string shipping_address = textBox6.Text;
                string sales_person = textBox7.Text;
                string customer_note = textBox8.Text;
                string customer_group = comboBox6.Text.ToString();
                dd.update_customer(idd, comp_name, contact_person, address, phone_prim, phone_alt, email, card_numm, cardverification_num, cardtype, expiration_month, expiration_year, card_holder, shipping_address, sales_person, customer_note, customer_group);
                MessageBox.Show("done");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                textBox4.Text = "";
                maskedTextBox3.Text = "";
                maskedTextBox4.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                comboBox6.Text = "";

                

            }
            catch (Exception)
            { MessageBox.Show("Try Again"); }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_customer_Load(object sender, EventArgs e)
        {
            ado_project f = new ado_project();
            DataTable dt = f.combo_opencust();
            comboBox6.DataSource = dt;
            comboBox6.DisplayMember = dt.Columns[0].ToString();


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
                comboBox1.Text = dr[8].ToString();
                comboBox2.Text = dr[9].ToString();
                comboBox3.Text = dr[10].ToString();
                textBox5.Text = dr[11].ToString();
                
                textBox6.Text = dr[12].ToString();
                textBox7.Text = dr[13].ToString();
                textBox8.Text = dr[14].ToString();
                comboBox6.Text = dr[15].ToString();
                maskedTextBox5.Text = dr[16].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new_group n = new new_group();
            n.ShowDialog();
        }
    }
}
