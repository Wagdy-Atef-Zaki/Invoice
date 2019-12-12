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
    public partial class payments : Form
    {
        public payments()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");
        SqlCommand com;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string comp = comboBox1.Text;
            string d = "true";
            string dd = "false";
            if (checkBox1.Checked == true)
            {
                groupBox1.Text = "Paid Invoices";
                con.Close();
                con.Open();
                dataGridView1.Rows.Clear();
                DataTable Dt = new DataTable();
                com = new SqlCommand("select invoice1_id,date,Date_deu,total_invoice,paid,change from invoice_1 where company_name='" + comp + "'and Done='" + d + "'", con);
                SqlDataAdapter adapt = new SqlDataAdapter(com);
                adapt.Fill(Dt);
                //con.Close();
                con.Close();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4],"Pay" ,Dt.Rows[i][5]);

                }
                
            }

            else
            {
                groupBox1.Text = "Unpaid Invoices";
                con.Open();
                dataGridView1.Rows.Clear();
                DataTable Dtt = new DataTable();
                com = new SqlCommand("select invoice1_id,date,total_invoice,paid,change from invoice_1 where company_name='" + comp + "'and Done='" + dd + "'", con);
                SqlDataAdapter adapt = new SqlDataAdapter(com);
                adapt.Fill(Dtt);

                for (int i = 0; i < Dtt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(Dtt.Rows[i][0], Dtt.Rows[i][1],"", Dtt.Rows[i][2], Dtt.Rows[i][3],"Pay" ,Dtt.Rows[i][4]);

                }
            }
        }


        private void payments_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[5].Visible = true ;
            ado_project TDB = new ado_project();
            DataTable dt = TDB.return_company_name();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = dt.Columns[0].ToString();
            payments p = new payments();
            p.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string comp = comboBox1.Text;
            string dd = "false";
            con.Open();
            dataGridView1.Rows.Clear();
            DataTable Dtt = new DataTable();
            com = new SqlCommand("select invoice1_id,date,total_invoice,paid,change from invoice_1 where company_name='" + comp + "'and Done='" + dd + "'", con);
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            adapt.Fill(Dtt);

            for (int i = 0; i < Dtt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(Dtt.Rows[i][0], Dtt.Rows[i][1], "",Dtt.Rows[i][2], Dtt.Rows[i][3],"Pay", Dtt.Rows[i][4]);

            }
            con.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            double amount = 0;
            try
            {
                amount = double.Parse(maskedTextBox1.Text.ToString());
            }
            catch
            { MessageBox.Show("You Should Enter The Amount"); }
            int i = dataGridView1.CurrentRow.Index;
            double total = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            Int64 in_num = Int64.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            string d = "true";
            string dd = "false";
            string date_deu=dateTimePicker1.Text.ToString();
            if (dataGridView1.Rows.Count > 0)
            {

                if (dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                   if(amount==total)
                   {
                       double c = 0;
                       dataGridView1.Rows[i].Cells[6].Value = "0";
                       dataGridView1.Rows[i].Cells[4].Value = amount;
                       dataGridView1.Rows[i].Cells[2].Value = date_deu;
                       con.Open();
                       com = new SqlCommand("update invoice_1 set paid=" + amount + ",change=" + c + ",Done='" + d + "',Date_deu='"+date_deu+"' where invoice1_id=" + in_num + "", con);
                       com.ExecuteNonQuery();
                       con.Close();
                   }
                   else if(amount<total)
                   {
                       double cc = total - amount;
                       dataGridView1.Rows[i].Cells[6].Value = cc;
                       dataGridView1.Rows[i].Cells[4].Value = amount;
                       con.Open();
                       com = new SqlCommand("update invoice_1 set paid=" + amount + ",change=" + cc + ",Done='" + dd + "' where invoice1_id=" + in_num + "", con);
                       com.ExecuteNonQuery();
                       con.Close();
                   }
                   // else if(amount>total)
                   //{
                   //    DialogResult dialogResult = MessageBox.Show("The Amount Is So Much Clik Ok To Remove It ,click No To Edit", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   //    if (dialogResult == DialogResult.Yes)
                   //    { dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index); }
                   // }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
