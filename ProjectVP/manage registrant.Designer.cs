
namespace ProjectVP
{
    partial class manage_registrant
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.registrantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VaccinationSystemDataSet = new ProjectVP.VaccinationSystemDataSet();
            this.registrantsTableAdapter = new ProjectVP.VaccinationSystemDataSetTableAdapters.registrantsTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.registrantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VaccinationSystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // registrantsBindingSource
            // 
            this.registrantsBindingSource.DataMember = "registrants";
            this.registrantsBindingSource.DataSource = this.VaccinationSystemDataSet;
            // 
            // VaccinationSystemDataSet
            // 
            this.VaccinationSystemDataSet.DataSetName = "VaccinationSystemDataSet";
            this.VaccinationSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registrantsTableAdapter
            // 
            this.registrantsTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(275, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check Vaccination Status";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Fetch data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(323, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(137, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter Registrant ID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(376, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Delete Record";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.registrantsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProjectVP.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(75, 90);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(604, 165);
            this.reportViewer1.TabIndex = 6;
            // 
            // manage_registrant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 328);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "manage_registrant";
            this.Text = "manage_registrant";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.manage_registrant_FormClosed);
            this.Load += new System.EventHandler(this.manage_registrant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registrantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VaccinationSystemDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource registrantsBindingSource;
        private VaccinationSystemDataSet VaccinationSystemDataSet;
        private VaccinationSystemDataSetTableAdapters.registrantsTableAdapter registrantsTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}