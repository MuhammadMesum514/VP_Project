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
    public partial class City_based_Evaluation : Form
    {
        public City_based_Evaluation()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=SAM\SQLDEVELOPER;Initial Catalog=VaccinationSystem;Integrated Security=True;MultipleActiveResultSets=True;";
        public void bindata() // get value for city combobox
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select CITY from branches", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr[0].ToString());
                    }
                }
            }
        }

        public void load_data()
        {
            chart1.DataSource = GetData();
            chart1.Series[0].XValueMember = "Center";
            chart1.Series[0].YValueMembers = "Total";
        }

        private DataTable GetData()
        {
             
            DataTable chartdata = new DataTable();
            using (SqlConnection con = new SqlConnection(connection))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("city_chart", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter("@CITY",comboBox1.SelectedItem.ToString());
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);
                    SqlDataReader dr = cmd.ExecuteReader();
                    chartdata.Load(dr);

                }
            }
            return chartdata;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void City_based_Evaluation_Load(object sender, EventArgs e)
        {
            bindata();
            //comboBox1.SelectedIndex = 1;
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            

        }
    }
}
