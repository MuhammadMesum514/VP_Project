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
    public partial class global_report_evaluation : Form
    {
        string connection = @"Data Source=SAM\SQLDEVELOPER;Initial Catalog=VaccinationSystem;Integrated Security=True;MultipleActiveResultSets=True;";

        public global_report_evaluation()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            chart1.DataSource = GetData();
            chart1.Series[0].XValueMember = "city";
            chart1.Series[0].YValueMembers = "total";
        }

        private DataTable GetData()
        {
            DataTable chartdata = new DataTable();
            using (SqlConnection con = new SqlConnection(connection))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("global_chart", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    chartdata.Load(dr);

                }
            }
            return chartdata;        
        }

        private void global_report_evaluation_Load(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
