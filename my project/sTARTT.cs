using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using my_project.NewFolder1;
using my_project.data.allitemSetTableAdapters;
using my_project.data;
using my_project.data.Non_Empty_ItemSetTableAdapters;
using my_project.data.emptySetTableAdapters;
using my_project.data.customerSetTableAdapters;

namespace my_project
{
    public partial class sTARTT : Form
    {
        public sTARTT()
        {
            InitializeComponent();
        }

        private void sTARTT_Load(object sender, EventArgs e)
        {
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = 10000;
            //for(int i=0;i<=10000;i++)
            //{progressBar1.Value=i;}
            
             
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void openInvoicesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Open_Invoice_List op = new Open_Invoice_List();
            op.ShowDialog();
        }

        private void openCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Customer op = new Open_Customer();
            op.ShowDialog();
        }

        private void itemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            show_item sh = new show_item();
            sh.ShowDialog();

        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payments p = new payments();
            p.ShowDialog();
        }

        private void finshedItemToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            payments pp = new payments();
            pp.ShowDialog();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            invoice inn = new invoice();
            inn.ShowDialog();
        }

        private void createNewInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invoice inn = new invoice();
            inn.ShowDialog();
        }

        private void openInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Invoice_List op = new Open_Invoice_List();
            op.ShowDialog();
        }

        private void applyPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payments n = new payments();
            n.ShowDialog();
        }

        private void createNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.ShowDialog();
        }

        private void openAllCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Customer op = new Open_Customer();
            op.ShowDialog();
        }

        private void createNewItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void openAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_item i = new show_item();
            i.ShowDialog();
        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start s = new start();
            s.ShowDialog();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
            invoice inn = new invoice();
            inn.ShowDialog();
        }

        private void toolStripSplitButton2_Click(object sender, EventArgs e)
        {
            payments pp = new payments();
            pp.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void ceateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invoice ii = new invoice();
            ii.ShowDialog();
        }

        private void ceateNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void viewAllInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer r = new Customer();
            r.ShowDialog();
        }

        private void allInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Invoice_List op = new Open_Invoice_List();
            op.ShowDialog();
        }

        private void allCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Customer c = new Open_Customer();
            c.ShowDialog();
        }

        private void allItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_item r = new show_item();
            r.ShowDialog();
        }

        private void applayNewPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payments p = new payments();
            p.ShowDialog();
        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start r = new start();
            r.ShowDialog();
        }

        private void invoicesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            start r = new start();
            r.ShowDialog();
        }

        private void remainningItemsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void finshedItemsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void allCustomerToolStripMenuItem_Click(object sender, EventArgs e)
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
            catch (Exception)
            {
                MessageBox.Show("There Is No Customer");
            }
        }

        private void allItemsToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void remainningItemsToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void finshedItemsToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void allCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
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
            catch (Exception)
            {
                MessageBox.Show("There Is No Customer");
            }
        }
    }
}
