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
    public partial class new_group : Form
    {
        public new_group()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            ado_project dd = new ado_project();
            string groupp = textBox1.Text;
            dd.insertgroup(groupp);
            MessageBox.Show("done");
        }

        private void new_group_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet9.groups' table. You can move, or remove it, as needed.
            this.groupsTableAdapter1.Fill(this.projectDataSet9.groups);
            // TODO: This line of code loads data into the 'projectDataSet3.groups' table. You can move, or remove it, as needed.
            this.groupsTableAdapter.Fill(this.projectDataSet3.groups);

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            new_group ng = new new_group();
            ng.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name=comboBox1.Text;
            con.Open();
            SqlCommand com = new SqlCommand("delete from groups where group_name='"+name+"'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Done");
            comboBox1.Text = "";
            new_group ng = new new_group();
            ng.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            con.Open();
            SqlCommand com = new SqlCommand("insert into groups values('"+name+"')", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Done");
            textBox1.Text = "";
            new_group ng = new new_group();
            ng.Refresh();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            new_group ng = new new_group();
            ng.Refresh();
        }
    }
}
