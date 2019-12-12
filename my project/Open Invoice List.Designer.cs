namespace my_project
{
    partial class Open_Invoice_List
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Open_Invoice_List));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.invoice1idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salespersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalinvoiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectDataSet8 = new my_project.projectDataSet8();
            this.projectDataSet7 = new my_project.projectDataSet7();
            this.invoice_1TableAdapter = new my_project.projectDataSet7TableAdapters.invoice_1TableAdapter();
            this.invoice_1TableAdapter1 = new my_project.projectDataSet8TableAdapters.invoice_1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoice1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet7)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radioButton3);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton2);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(853, 565);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 1;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(563, 17);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(127, 20);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Unpaid Invoices";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(437, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(111, 20);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Paid Invoices";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(320, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 20);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All Invoices";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(120, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Company Name:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoice1idDataGridViewTextBoxColumn,
            this.companynameDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.salespersonDataGridViewTextBoxColumn,
            this.totalinvoiceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.invoice1BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(853, 508);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // invoice1idDataGridViewTextBoxColumn
            // 
            this.invoice1idDataGridViewTextBoxColumn.DataPropertyName = "invoice1_id";
            this.invoice1idDataGridViewTextBoxColumn.HeaderText = "Invoice Number";
            this.invoice1idDataGridViewTextBoxColumn.Name = "invoice1idDataGridViewTextBoxColumn";
            this.invoice1idDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoice1idDataGridViewTextBoxColumn.Width = 130;
            // 
            // companynameDataGridViewTextBoxColumn
            // 
            this.companynameDataGridViewTextBoxColumn.DataPropertyName = "company_name";
            this.companynameDataGridViewTextBoxColumn.HeaderText = "Company Name";
            this.companynameDataGridViewTextBoxColumn.Name = "companynameDataGridViewTextBoxColumn";
            this.companynameDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 150;
            // 
            // salespersonDataGridViewTextBoxColumn
            // 
            this.salespersonDataGridViewTextBoxColumn.DataPropertyName = "sales_person";
            this.salespersonDataGridViewTextBoxColumn.HeaderText = "Sales person";
            this.salespersonDataGridViewTextBoxColumn.Name = "salespersonDataGridViewTextBoxColumn";
            this.salespersonDataGridViewTextBoxColumn.Width = 200;
            // 
            // totalinvoiceDataGridViewTextBoxColumn
            // 
            this.totalinvoiceDataGridViewTextBoxColumn.DataPropertyName = "total_invoice";
            this.totalinvoiceDataGridViewTextBoxColumn.HeaderText = "Total ";
            this.totalinvoiceDataGridViewTextBoxColumn.Name = "totalinvoiceDataGridViewTextBoxColumn";
            this.totalinvoiceDataGridViewTextBoxColumn.Width = 130;
            // 
            // invoice1BindingSource
            // 
            this.invoice1BindingSource.DataMember = "invoice_1";
            this.invoice1BindingSource.DataSource = this.projectDataSet8;
            // 
            // projectDataSet8
            // 
            this.projectDataSet8.DataSetName = "projectDataSet8";
            this.projectDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectDataSet7
            // 
            this.projectDataSet7.DataSetName = "projectDataSet7";
            this.projectDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // invoice_1TableAdapter
            // 
            this.invoice_1TableAdapter.ClearBeforeFill = true;
            // 
            // invoice_1TableAdapter1
            // 
            this.invoice_1TableAdapter1.ClearBeforeFill = true;
            // 
            // Open_Invoice_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(853, 565);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Open_Invoice_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Invoices";
            this.Load += new System.EventHandler(this.Open_Invoice_List_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoice1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private projectDataSet7 projectDataSet7;
        private projectDataSet7TableAdapters.invoice_1TableAdapter invoice_1TableAdapter;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private projectDataSet8 projectDataSet8;
        private System.Windows.Forms.BindingSource invoice1BindingSource;
        private projectDataSet8TableAdapters.invoice_1TableAdapter invoice_1TableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice1idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salespersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalinvoiceDataGridViewTextBoxColumn;
    }
}