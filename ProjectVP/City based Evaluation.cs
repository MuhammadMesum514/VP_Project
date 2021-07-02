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
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select CITY from city_login", con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr[0].ToString());
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("records are empty");
            }
        }

        public void load_data()
        {
            chart1.DataSource = GetData();
            chart1.Series[0].Points.Clear();
            chart1.Series[0].XValueMember = "Center";
            chart1.Series[0].YValueMembers = "Total";
        }

        private DataTable GetData()
        {
            string value = comboBox1.Text;
            DataTable chartdata = new DataTable();
            try
            {
                
                using (SqlConnection con = new SqlConnection(connection))
                {

                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("city_chart", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //SqlParameter param = new SqlParameter();
                        //param.ParameterName = "@CITY";
                        ////param.Direction = ParameterDirection.Input;
                        //param.DbType = DbType.String;
                        //param.Value = comboBox1.SelectedItem.ToString();
                        //cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CITY", value);
                        SqlDataReader dr = cmd.ExecuteReader();
                        chartdata.Load(dr);

                    }
                   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("no record found");
            }
            return chartdata;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load_data();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void City_based_Evaluation_Load(object sender, EventArgs e)
        {
            bindata();
            //comboBox1.SelectedIndex = 0;
            //load_data();
            
            //comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        } 
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void City_based_Evaluation_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
        }
    }
}
