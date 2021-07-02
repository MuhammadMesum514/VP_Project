using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVP
{
    public partial class manage_registrant : Form
    {
        string connection = @"Data Source=SAM\SQLDEVELOPER;Initial Catalog=VaccinationSystem;Integrated Security=True;MultipleActiveResultSets=True;";
        DataTable dt;
        public manage_registrant()
        {
            InitializeComponent();
        }

        private void manage_registrant_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'VaccinationSystemDataSet.registrants' table. You can move, or remove it, as needed.
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fetch_data();
            
           
            //this.registrantsTableAdapter.Fill(this.VaccinationSystemDataSet.registrants);

            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
        }

        public void fetch_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select first_name,last_name,cnic,vaccination_status,city from registrants where registration_id='"+textBox1.Text + "'", con))
                    {
                        //cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                        //SqlDataReader dr = cmd.ExecuteReader();
                        //SqlDataAdapter da = new SqlDataAdapter();
                        cmd.CommandType = CommandType.Text;
                         dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        //da.Fill(dt);
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        reportViewer1.LocalReport.ReportPath = @"C:\Users\DELL\source\repos\ProjectVP\ProjectVP\Report1.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(ds);
                        reportViewer1.RefreshReport();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("no record found");
            }
        }

        public void delete_record()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("delete from vaccination_center where registration_id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("delete from registrants where registration_id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("record deleted sucessfully;");
            }
            catch (Exception)
            {
                MessageBox.Show("no record found");
            }
        }
        
    private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete_record();
        }

        private void manage_registrant_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
        }
    }
}
