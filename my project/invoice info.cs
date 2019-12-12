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
    public partial class invoice_info : Form
    {
        Int64 value ;
        public invoice_info(Int64 invoice_num)
        {
            InitializeComponent();
            value = invoice_num;
        }
        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");
        private void invoice_info_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select company_name,contact_person,comp_address,comp_tell,shipping_adrress,shipping_person,shipping_cost,date,Date_deu,payment_terms,sales_person,comments from invoice_1 where invoice1_id=" + value + "", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                textBox7.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox1.Text = dr[2].ToString();
                maskedTextBox1.Text = dr[3].ToString();
                textBox3.Text = dr[4].ToString();
                textBox6.Text = dr[5].ToString();
                maskedTextBox2.Text = dr[6].ToString();
                textBox9.Text = dr[7].ToString();
                textBox10.Text = dr[8].ToString();
                textBox8.Text = dr[9].ToString();
                textBox5.Text = dr[10].ToString();
                textBox4.Text = dr[11].ToString();
            }
            dr.Close();
            con.Close();

            //con.Open();
            dataGridView1.Rows.Clear();
            
            com = new SqlCommand("select i.amount,t.item_name,t.item_describtion,t.unit_value,i.sup_total from dbo.invoice_2 i ,dbo.items t where i.item_nam=t.items_id and i.fk_invoice1_id=" + value + "", con);
           
            SqlDataAdapter adpt;
            adpt = new SqlDataAdapter(com);
            DataTable Dt = new DataTable();
            adpt.Fill(Dt);
            //SqlDataReader aa = com.ExecuteReader();
            //if (aa.Read())
            {

                for (int i =0; i < Dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                }
            }
            //aa.Close();
            //con.Close();

            //con.Open();
            //for (int i = 0; i < Dt.Rows.Count; i++)
            //{
            //    string itemname = dataGridView1.SelectedRows[i].Cells[1].Value.ToString();
            //    com = new SqlCommand("select item_describtion,unit_value from items where item_name='"+itemname+"'", con);
            //    dataGridView1.Rows.Add(Dt.Rows[i][2], Dt.Rows[i][3]);
            //}
            //con.Close();
        }
    }
}
