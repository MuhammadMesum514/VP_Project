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
    public partial class Vaccination_center : Form
    {
        
        string connection=@"Data Source=SAM\SQLDEVELOPER;Initial Catalog=VaccinationSystem;Integrated Security=True;MultipleActiveResultSets=True;";

       

        public Vaccination_center()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fetch_data();
            
        }

        // method for fetching data in gridview
        public void fetch_data()
        {
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from registrants where registration_id=@id", con)) { 
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //SqlDataReader reader = cmd.ExecuteReader();

                //dataGridView1.DataSource = reader;
                //dataGridView1.DataBind();


                DataSet ds = new DataSet();

                adapter.Fill(ds, "fetch");
                    // displaying data in gridview
                dataGridView1.DataSource = ds.Tables["fetch"].DefaultView; 

               
                }
            }
        }
        // inserting data in vaccination table
        public void insert_data_in_vaccination_table()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from registrants where registration_id=100", con))
                {
                    //cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                   
                    //getting radio button value
                    string value = "";
                    bool isChecked = radioButton2.Checked;
                    if (isChecked)
                        value = radioButton2.Text;
                    else
                        value = radioButton1.Text;

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string name = string.Concat(dr["first_name"], " ", dr["last_name"]);
                            string cnic = dr["cnic"].ToString();
                            int age = Int32.Parse(dr["age"].ToString());
                            string center = comboBox1.SelectedItem.ToString();
                            string status = value;
                            string dt = DateTime.Now.ToString("yyyy-MM-dd");
                            int reg_id = Int32.Parse(dr["registration_id"].ToString());

                            SqlCommand command = new SqlCommand("insert into vaccination_center (name,cnic,age,vaccination_center,status,vaccination_date,registration_id) values(@name,@cnic,@age,@vaccination_center,@status,@vaccination_date,@registration_id)", con);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@cnic", cnic);
                            command.Parameters.AddWithValue("@age", age);
                            command.Parameters.AddWithValue("@vaccination_center", center);
                            command.Parameters.AddWithValue("@status", status);
                            command.Parameters.AddWithValue("@vaccination_date", dt);
                            command.Parameters.AddWithValue("@registration_id", reg_id);
                            command.ExecuteNonQuery();
                        }


                    }
                }

                }

        }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Vaccination_center_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // a comment to test git
            insert_data_in_vaccination_table();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            login form = new login();
            form.Show();
            this.Hide();
        }
    }
}
