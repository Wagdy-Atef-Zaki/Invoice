using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace my_project
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            textBox6.Text = " ";
            
            string address = textBox3.Text;
            textBox6.Text = address;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ado_project dd = new ado_project();
            try
            {
                string comp_name = textBox1.Text;
                string contact_person = textBox2.Text;
                string address = textBox3.Text;
                Int64 phone_prim = Int64.Parse(maskedTextBox1.Text);
                Int64 phone_alt = Int64.Parse(maskedTextBox2.Text);
                string email = textBox4.Text;
                
                Int64 card_numm ;
                Int64 cardverification_num ;
                string cardtype;
                Int64 expiration_month ;
                Int64 expiration_year ;
                string card_holder ;
                if (checkBox1.Checked == true)
                {
                     card_numm=0;
                     cardverification_num=0;
                     cardtype="";
                     expiration_month=0;
                     expiration_year=0;
                     card_holder="";
                }
                else
                {
                    card_numm = Int64.Parse(maskedTextBox3.Text);
                    cardverification_num = Int64.Parse(maskedTextBox4.Text);
                    cardtype = comboBox1.Text.ToString();
                    expiration_month = Int64.Parse(comboBox2.Text.ToString());
                    expiration_year = Int64.Parse(comboBox3.Text.ToString());
                    card_holder = textBox5.Text;
                }
                string shipping_address = textBox6.Text;
                string sales_person = textBox7.Text;
                string customer_note = textBox8.Text;
                string customer_group = comboBox6.Text.ToString();
                double balanc = 0;

                dd.insert_customer(comp_name, contact_person, address, phone_prim, phone_alt, email, card_numm, cardverification_num, cardtype, expiration_month, expiration_year, card_holder, shipping_address, sales_person, customer_note, customer_group, balanc);
                MessageBox.Show("Done");
            }
            catch (Exception)
            { MessageBox.Show("Try Again"); }

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

            Customer c = new Customer();
            c.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new_group n = new new_group();
            n.ShowDialog();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            ado_project f = new ado_project();
            DataTable dt = f.combo_opencust();
            comboBox6.DataSource = dt;
            comboBox6.DisplayMember = dt.Columns[0].ToString();
            //if (checkBox1.Checked == true)
            //{
            //    maskedTextBox3.Text = "";
            //    maskedTextBox4.Text = "";
            //    comboBox1.Text = "";
            //    comboBox2.Text = "";
            //    comboBox3.Text = "";
            //    textBox5.Text = "";
            //    maskedTextBox3.Enabled = false;
            //    maskedTextBox4.Enabled = false;
            //    comboBox1.Enabled = false;
            //    comboBox2.Enabled = false;
            //    comboBox3.Enabled = false;
            //    textBox5.Enabled = false;
 
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                maskedTextBox3.Text = "";
                maskedTextBox4.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox5.Text = "";
                maskedTextBox3.Enabled = false;
                maskedTextBox4.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox5.Enabled = false;

            }
            else
            {
                maskedTextBox3.Enabled = true;
                maskedTextBox4.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                textBox5.Enabled = true;
 
            }
        }
    }
}
