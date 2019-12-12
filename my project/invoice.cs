using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using my_project.data.invoiceSet1TableAdapters;
using my_project.data;
using my_project.NewFolder1;

namespace my_project
{
    public partial class invoice : Form
    {
        public invoice()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Open_Customer oc = new Open_Customer();
            oc.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            { string address = textBox1.Text;
            textBox3.Text = address;
            }
            else if (checkBox1.Checked == false)
            {
                textBox3.Clear(); 
            }
        }

        private void invoice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet5.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter2.Fill(this.projectDataSet5.items);
            // TODO: This line of code loads data into the 'projectDataSet1.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter1.Fill(this.projectDataSet1.items);
            // TODO: This line of code loads data into the 'projectDataSet.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.projectDataSet.items);

            ado_project TDB = new ado_project();
            DataTable dt = TDB.return_company_name();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = dt.Columns[0].ToString();
           




        }

        Int64 count = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int c;
            try
            {
                count = 0;
                ado_project ado = new ado_project();
                string descripe = "";
                Int64 num = 0;
                double value = 0;

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    c =int.Parse( dataGridView1.Rows[i].Cells[1].Value.ToString());
                    Int64 n = Int64.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    ado.select_invoice_info(c, ref descripe, ref num, ref value);
                    dataGridView1.Rows[i].Cells[2].Value = descripe;
                    dataGridView1.Rows[i].Cells[3].Value = value;
                    

                    if (num>= n)
                    {
                        double  calculate = n * value;
                        dataGridView1.Rows[i].Cells[4].Value = calculate;
                        count += Int64.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    }


                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("The Amount Not Enough Clik Ok To Remove It ,click No To Edit", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        { dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index); }

                    }


                }
                label9.Text = count.ToString();

            }
                
            catch
            {
                c = 0;
            }
        }

       

        private void recordOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                string company = comboBox1.Text;
                string contactperson = textBox2.Text;
                string address = textBox1.Text;
                Int64 ph = Int64.Parse(maskedTextBox1.Text);
                string shiptoo = "";
                try { shiptoo = textBox3.Text; }
                catch { shiptoo = ""; }

                string shipbyy = "";
                try { shipbyy = textBox6.Text; }
                catch { shipbyy = ""; }

                 Int64 shipcost = 0;
                try
                {shipcost = Int64.Parse(maskedTextBox2.Text);}
                 catch
                {shipcost = 0;}
                
                string date = dateTimePicker1.Text;
                Int64 payment = 0;
                try { payment = Int64.Parse(domainUpDown2.Text); }
                catch { payment = 0; }

                string salesperson = "";
                try { salesperson = textBox5.Text; }
                catch { salesperson = ""; }

                string note = "";
                try { note = textBox4.Text; }
                catch { note = ""; }
                double total = double.Parse(label9.Text) + shipcost;
                double ppaid = 0;
                double cchange = double.Parse(label9.Text);
                string done = "false";
                string date_due = "Not Paid";
                int idd = 0;
                ado_project d = new ado_project();
                d.select_id_Companyname(company, ref idd);

                d.insert_invoice(company, contactperson, address, ph, shiptoo, shipbyy, shipcost, date, date_due, payment, salesperson, note, total, ppaid, cchange, done, idd);

                int use_id = 0;
                d.select_id(company, date, ref use_id);
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    Int64 amount_num = Int64.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    int item = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    string descriiption = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    Int64 unittprice = Int64.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    Int64 ssuptotal = Int64.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

                    //string itemm = "";
                    //d.select_itemmname(item, ref itemm);
                    d.insert_invoice2(amount_num, item,  ssuptotal, use_id);

                    Int64 ref_unmber = 0;
                    d.select_itemname(item, ref ref_unmber);
                    Int64 new_num = ref_unmber - amount_num;
                    d.update_numberitem(item, new_num);

                }
                MessageBox.Show("Recording Done");
            }
            catch(Exception)
            { MessageBox.Show("Try Again"); }


            textBox3.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            domainUpDown2.Text = "";
            label9.Text = "00.00";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ado_project d = new ado_project();
            string person = "";
            string address = "";
            Int64 ph = 0;
            string name = comboBox1.Text;
            d.select_data(name,ref person,ref address,ref ph);
            textBox2.Text = person;
            textBox1.Text = address;
            maskedTextBox1.Text = ph.ToString();
        }

       
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                if (dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    DialogResult dialogResult = MessageBox.Show("This Item Will Be Delete From This Invoice", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int i = dataGridView1.CurrentRow.Index;
                        Int64 n = Int64.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        count -= n;
                        label9.Text = count.ToString();
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                      
                    }
                    
                }
            }
        }



        private void recordAndPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string company = comboBox1.Text;
                string contactperson = textBox2.Text;
                string address = textBox1.Text;
                Int64 ph = Int64.Parse(maskedTextBox1.Text);
                string date = dateTimePicker1.Text;

                string shiptoo = "";
                try { shiptoo = textBox3.Text; }
                catch { shiptoo = ""; }

                string shipbyy = "";
                try { shipbyy = textBox6.Text; }
                catch { shipbyy = ""; }

                Int64 shipcost = 0;
                try
                { shipcost = Int64.Parse(maskedTextBox2.Text); }
                catch
                { shipcost = 0; }

                Int64 payment = 0;
                try { payment = Int64.Parse(domainUpDown2.Text); }
                catch { payment = 0; }

                string salesperson = "";
                try { salesperson = textBox5.Text; }
                catch { salesperson = ""; }

                string note = "";
                try { note = textBox4.Text; }
                catch { note = ""; }
                double total = double.Parse(label9.Text)+shipcost;
                double ppaid = 0;
                double cchange = double.Parse(label9.Text);
                string done = "false";
                string date_due = "Not Paid";
                int idd = 0;
                ado_project d = new ado_project();
                d.select_id_Companyname(company, ref idd);
                d.insert_invoice(company, contactperson, address, ph, shiptoo, shipbyy, shipcost, date, date_due, payment, salesperson, note, total, ppaid, cchange, done, idd);

                int use_id = 0;
                d.select_id(company, date, ref use_id);
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    Int64 amount_num = Int64.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    int item =int.Parse( dataGridView1.Rows[i].Cells[1].Value.ToString());
                    string descriiption = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    Int64 unittprice = Int64.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    Int64 ssuptotal = Int64.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

                    //string itemm = "";
                    //d.select_itemmname(item, ref itemm);
                    d.insert_invoice2(amount_num, item, ssuptotal, use_id);

                    Int64 ref_unmber = 0;
                    d.select_itemname(item, ref ref_unmber);
                    Int64 new_num = ref_unmber - amount_num;
                    d.update_numberitem(item, new_num);

                }

               DialogResult dialogResult= MessageBox.Show("Recoding Done ,Do you Want Print Invoice?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {


                    DataTable2TableAdapter d2 = new DataTable2TableAdapter();
                    invoiceSet1.DataTable2DataTable dd = new invoiceSet1.DataTable2DataTable();
                    d2.Fill(dd, use_id);
                    testt rpt = new testt();
                    rpt.SetDataSource(dd[0].Table);


                    Report_Viewer vd = new Report_Viewer();
                    vd.crystalReportViewer1.ReportSource = rpt;
                    vd.ShowDialog();
                }
            }
            catch (Exception)
            { MessageBox.Show("Try Again"); }


            textBox3.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            domainUpDown2.Text = "";
            label9.Text = "00.00";
            

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void recordWithPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            string company = comboBox1.Text;
            string contactperson = textBox2.Text;
            string address = textBox1.Text;
            Int64 ph = Int64.Parse(maskedTextBox1.Text);
            string shiptoo = "";
            try { shiptoo = textBox3.Text; }
            catch { shiptoo = ""; }

            string shipbyy = "";
            try { shipbyy = textBox6.Text; }
            catch { shipbyy = ""; }

            Int64 shipcost = 0;
            try
            { shipcost = Int64.Parse(maskedTextBox2.Text); }
            catch
            { shipcost = 0; }

            string date = dateTimePicker1.Text;
            Int64 payment = 0;
            try { payment = Int64.Parse(domainUpDown2.Text); }
            catch { payment = 0; }

            string salesperson = "";
            try { salesperson = textBox5.Text; }
            catch { salesperson = ""; }

            string note = "";
            try { note = textBox4.Text; }
            catch { note = ""; }
            double total = double.Parse(label9.Text)+shipcost;
            double paid = double.Parse(label9.Text);
            double change = 0;
            string done = "true";
            int idd = 0;
            ado_project d = new ado_project();
            
            d.select_id_Companyname(company, ref idd);
            d.insert_invoice(company, contactperson, address, ph, shiptoo, shipbyy, shipcost, date, date, payment, salesperson, note, total, paid, change, done,idd);

            int use_id = 0;
            d.select_id(company, date, ref use_id);
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {

                Int64 amount_num = Int64.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                int item =int.Parse( dataGridView1.Rows[i].Cells[1].Value.ToString());
                string descriiption = dataGridView1.Rows[i].Cells[2].Value.ToString();
                Int64 unittprice = Int64.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                Int64 ssuptotal = Int64.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

                //string itemm = "";
                //d.select_itemmname(item,ref itemm);
                d.insert_invoice2(amount_num, item,  ssuptotal,use_id);

                Int64 ref_unmber = 0;
                d.select_itemname(item, ref ref_unmber);
                Int64 new_num = ref_unmber - amount_num;
                d.update_numberitem(item, new_num);

            }
            DialogResult dialogResult = MessageBox.Show("Recoding With Payment Done ,Do you Want Print Invoice?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                
                    DataTable2TableAdapter d2 = new DataTable2TableAdapter();
                    invoiceSet1.DataTable2DataTable dd = new invoiceSet1.DataTable2DataTable();
                    d2.Fill(dd, use_id);
                    testt rpt = new testt();
                    rpt.SetDataSource(dd[0].Table);


                    Report_Viewer vd = new Report_Viewer();
                    
                    vd.crystalReportViewer1.ReportSource = rpt;
                    vd.ShowDialog();
            }
            }
            catch (Exception)
            { MessageBox.Show("Try Again"); }


            textBox3.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            domainUpDown2.Text = "";
            label9.Text = "00.00";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
