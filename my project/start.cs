using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using my_project.data;
using my_project.data.allitemSetTableAdapters;
using my_project.NewFolder1;
using my_project.data.emptySetTableAdapters;
using my_project.data.Non_Empty_ItemSetTableAdapters;
using my_project.data.customerSetTableAdapters;
using my_project.data.All_Invoices_SetTableAdapters;
using my_project.data.allinvoicepaidSetTableAdapters;
using my_project.data.unpaidinvoicesetTableAdapters;
using my_project.data.invoice_change_setTableAdapters;

namespace my_project
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            itemsTableAdapter s = new itemsTableAdapter();
            allitemSet.itemsDataTable d = new allitemSet.itemsDataTable();
            s.Fill(d);

            allitem rpt = new allitem();
            rpt.SetDataSource(d[0].Table);


            Report_Viewer vd = new Report_Viewer();
            vd.crystalReportViewer1.ReportSource = rpt;
            vd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                itemsTableAdapter2 s = new itemsTableAdapter2();
                Non_Empty_ItemSet.itemsDataTable d = new Non_Empty_ItemSet.itemsDataTable();
                s.Fill(d);
                Non_Empty_Item rpt = new Non_Empty_Item();
                rpt.SetDataSource(d[0].Table);


                Report_Viewer vd = new Report_Viewer();
                vd.crystalReportViewer1.ReportSource = rpt;
                vd.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("There Is No Avilable Items");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                itemsTableAdapter1 s = new itemsTableAdapter1();
                emptySet.itemsDataTable dd = new emptySet.itemsDataTable();
                s.Fill(dd);
                empty_item rpt = new empty_item();
                rpt.SetDataSource(dd[0].Table);


                Report_Viewer vd = new Report_Viewer();
                vd.crystalReportViewer1.ReportSource = rpt;
                vd.ShowDialog();
            }
            catch (Exception)
            { MessageBox.Show("There Is No Empty Items"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                customerTableAdapter c = new customerTableAdapter();
                customerSet.customerDataTable cd = new customerSet.customerDataTable();
                c.Fill(cd);
                allcustomer rpt = new allcustomer();
                rpt.SetDataSource(cd[0].Table);


                Report_Viewer vd = new Report_Viewer();
                vd.crystalReportViewer1.ReportSource = rpt;
                vd.ShowDialog();
 
            }
            catch(Exception)
            {
                MessageBox.Show("There Is No Customer");
            }

        }

        private void start_Load(object sender, EventArgs e)
        {
            ado_project TDB = new ado_project();
            DataTable dt = TDB.return_company_name();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = dt.Columns[0].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                string name = comboBox1.Text;
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        invoice_1TableAdapter1 i = new invoice_1TableAdapter1();
                        All_Invoices_Set.invoice_1DataTable ai = new All_Invoices_Set.invoice_1DataTable();
                        i.Fill(ai, name);
                        allinvoice rpt = new allinvoice();
                        rpt.SetDataSource(ai[0].Table);


                        Report_Viewer vd = new Report_Viewer();
                        vd.crystalReportViewer1.ReportSource = rpt;
                        vd.ShowDialog();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There Is No Invoices For " + name + " Customer");
                    }
                }

                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        invoice_1TableAdapter2 i = new invoice_1TableAdapter2();
                        allinvoicepaidSet.invoice_1DataTable ai = new allinvoicepaidSet.invoice_1DataTable();
                        i.Fill(ai, name);
                        Allinvoice_paid rpt = new Allinvoice_paid();
                        rpt.SetDataSource(ai[0].Table);


                        Report_Viewer vd = new Report_Viewer();
                        vd.crystalReportViewer1.ReportSource = rpt;
                        vd.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There Is No Paid Invoices For " + name + " Customer");
                    }
                }

                else if (radioButton3.Checked == true)
                {
                    try
                    {
                        invoice_1TableAdapter3 i3 = new invoice_1TableAdapter3();
                        unpaidinvoiceset.invoice_1DataTable d = new unpaidinvoiceset.invoice_1DataTable();
                        i3.Fill(d, name);
                        unpaid_invoices rpt = new unpaid_invoices();
                        rpt.SetDataSource(d[0].Table);


                        Report_Viewer vd = new Report_Viewer();
                        vd.crystalReportViewer1.ReportSource = rpt;
                        vd.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There Is No Unpaid Invoices For " + name + " Customer");
                    }
                }

                else if (radioButton4.Checked == true)
                {
                    try
                    {
                        invoice_1TableAdapter4 i4 = new invoice_1TableAdapter4();
                        invoice_change_set.invoice_1DataTable dd = new invoice_change_set.invoice_1DataTable();
                        i4.Fill(dd, name);
                        change_invoice rpt = new change_invoice();
                        rpt.SetDataSource(dd[0].Table);


                        Report_Viewer vd = new Report_Viewer();
                        vd.crystalReportViewer1.ReportSource = rpt;
                        vd.ShowDialog();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There Is No Invoices For The Customer" + " " + name);
                    }
                }
           
            else 
            {
                MessageBox.Show("Please Choose What Any Report You want!!");
            }

            }
        
       

        
    }
}
