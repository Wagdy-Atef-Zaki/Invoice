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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ado_project db = new ado_project();
            try
            {
                string name = textBox3.Text;
                string code = textBox1.Text;
                string description = textBox2.Text;
                Int64 unit_value = Int64.Parse(maskedTextBox1.Text);
                Int64 current_quntaty = Int64.Parse(maskedTextBox2.Text);
                Int64 ideal_quntaty = Int64.Parse(maskedTextBox3.Text);
                Int64 warnning_quntaty = Int64.Parse(maskedTextBox4.Text);
                db.insert_items(code, name, description, unit_value, current_quntaty, ideal_quntaty, warnning_quntaty);
                MessageBox.Show("Done");
            }
             catch(Exception)
            {MessageBox.Show("Try Again");}

            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";

            Form1 f = new Form1();
            f.Refresh();
 
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
