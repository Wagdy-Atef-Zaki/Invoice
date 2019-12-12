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
    public partial class show_item : Form
    {
        public show_item()
        {
            InitializeComponent();
        }

        private void show_item_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet4.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.projectDataSet4.items);
            show_item s = new show_item();
            s.Refresh();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ado_project dd = new ado_project();
            int i = dataGridView1.CurrentRow.Index;

            string item = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dd.delete_items(item);
            MessageBox.Show("The Item Deleted");
            dataGridView1.Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            //stri i = dataGridView1.CurrentRow.Index;
            update_item c = new update_item(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            c.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            string item = (dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            Int64 id = 0;
            ado_project n = new ado_project();
            n.select_id_itemname(item, ref id);
            open_item op = new open_item(id);
            op.ShowDialog();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }
    }
}
