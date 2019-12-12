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
    public partial class Open_Invoice_List : Form
    {
        public Open_Invoice_List()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");
        DataTable Dt = new DataTable();
        SqlDataAdapter adapt;
        SqlCommand com;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Open_Invoice_List_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'projectDataSet8.invoice_1' table. You can move, or remove it, as needed.
            this.invoice_1TableAdapter1.Fill(this.projectDataSet8.invoice_1);
            // TODO: This line of code loads data into the 'projectDataSet7.invoice_1' table. You can move, or remove it, as needed.
            //this.invoice_1TableAdapter.Fill(this.projectDataSet7.invoice_1);

            ado_project TDB = new ado_project();
            DataTable dt = TDB.return_company_name();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = dt.Columns[0].ToString();
            radioButton1.Checked = true;
            Open_Invoice_List op = new Open_Invoice_List();
            op.Refresh();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //dataGridView1.Rows.Clear(); = null;
            try
            {
                if(dataGridView1.Rows.Count>0)
                dataGridView1.Rows.Clear();
            }
            catch { }
            radioButton1.Checked = true;
            string company_name = comboBox1.Text;
            
            //con.Open();
            dataGridView1.DataSource = null;
            Dt = new DataTable();
            com = new SqlCommand("select invoice1_id,company_name,date,sales_person,total_invoice from invoice_1 where company_name='" + company_name + "'", con);
            // com.Connection = con;
            adapt = new SqlDataAdapter(com);
            adapt.Fill(Dt);


            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int64 invoice_number=Int64.Parse(( dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            invoice_info info = new invoice_info(invoice_number);
            info.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear(); 
            try
            {
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows.Clear();
            }
            catch { }
            if (radioButton1.Checked == true)
            {
                string company_name = comboBox1.Text;

                //con.Open();
                dataGridView1.DataSource = null;
                Dt = new DataTable();
                com = new SqlCommand("select invoice1_id,company_name,date,sales_person,total_invoice from invoice_1 where company_name='" + company_name + "'", con);
                // com.Connection = con;
                adapt = new SqlDataAdapter(com);
                adapt.Fill(Dt);


                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                }
                con.Close();

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); 
            if (radioButton2.Checked == true)
            {
                string company_name = comboBox1.Text;
                string dd = "true";
                //con.Open();
                dataGridView1.DataSource = null;
                Dt = new DataTable();
                com = new SqlCommand("select invoice1_id,company_name,date,sales_person,total_invoice from invoice_1 where company_name='" + company_name + "' and Done='" + dd + "'", con);
                // com.Connection = con;
                adapt = new SqlDataAdapter(com);
                adapt.Fill(Dt);


                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                }
                con.Close();

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); 
            
            if (radioButton3.Checked == true)
            {
                string company_name = comboBox1.Text;
                string dd = "false";
                //con.Open();
                dataGridView1.DataSource = null;
                Dt = new DataTable();
                com = new SqlCommand("select invoice1_id,company_name,date,sales_person,total_invoice from invoice_1 where company_name='" + company_name + "' and Done='" + dd + "'", con);
                // com.Connection = con;
                adapt = new SqlDataAdapter(com);
                adapt.Fill(Dt);


                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                }
                con.Close();
            }
        }
    }
}