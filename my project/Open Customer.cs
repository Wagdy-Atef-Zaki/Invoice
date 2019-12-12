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
    public partial class Open_Customer : Form
    {
        public Open_Customer()
        {
            InitializeComponent();
         
        }

        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");
        DataTable Dt = new DataTable();
        SqlDataAdapter adapt;
        SqlCommand com;
        DataRow dr;
        DataTable dt;
        private void Open_Customer_Load(object sender, EventArgs e)
        {
            

            con.Open();
            dataGridView1.Rows.Clear();
            Dt = new DataTable();
            com = new SqlCommand("select company_name,contact_person,phone_puplic,sales_person,custmer_group,blance from customer");
            com.Connection = con;
            adapt = new SqlDataAdapter(com);
            adapt.Fill(Dt);

           // dataGridView1.DataSource = Dt;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5]);
            }
            con.Close();

            
            ado_project f = new ado_project();
             dt = f.combo_opencust();

            dr = dt.NewRow();
            dr[0] = "All";
            dt.Rows.Add(dr);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = dt.Columns[0].ToString();

            Open_Customer op = new Open_Customer();
            op.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string group = comboBox1.Text;

            //con.Open();
            dataGridView1.Rows.Clear();
            Dt = new DataTable();
            com = new SqlCommand("select company_name,contact_person,phone_puplic,sales_person,custmer_group,blance from customer where custmer_group='"+group+"'",con);
           // com.Connection = con;
            if (group == "All")
            { com = new SqlCommand("select company_name,contact_person,phone_puplic,sales_person,custmer_group,blance from customer", con); }
            adapt = new SqlDataAdapter(com);
            adapt.Fill(Dt);

          
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5]);
            }
            con.Close();
 
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string company_name =( dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            int id=0;
            ado_project n = new ado_project();
            n.select_id_Companyname(company_name,ref id);


            more_information frm = new more_information(id);
            frm.ShowDialog();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                ado_project dd = new ado_project();
                int i = dataGridView1.CurrentRow.Index;

                string cmp_name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                dd.delete_customer(cmp_name);
                dataGridView1.Refresh();
            }
            catch (Exception)
            { MessageBox.Show("you can't Delete all companies"); }
            #region MyRegion
            //for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            //{
            //    cmp_name = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
            //}  
            //if (dataGridView1.SelectedRows[0].Selected)
            //{
               
            //}
            //else
            //{ MessageBox.Show("Please Select Company to Delete"); }
            #endregion



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string company_name = (dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                int id = 0;
                ado_project n = new ado_project();
                n.select_id_Companyname(company_name, ref id);
                update_customer uc = new update_customer(id);
                uc.ShowDialog();
            }
            catch (Exception)
            { MessageBox.Show("Please Choose One Company"); }
        }
    }
}
