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
        string cityname;
        string branchname;
        bool city_returned=false;

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
        public void show_city(string c)
        {
            cityname = c;
        }
        public void show_branch(string b)
        {
            branchname = b;
        }

        // method for fetching data in gridview
        public void fetch_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from registrants where registration_id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        bool flag = verify_city();
                        if (flag)
                        {
                            city_returned = false; // it will set verify city value to false so to be checked again on next searcg
                            DataSet ds = new DataSet();

                            adapter.Fill(ds, "fetch");
                            // displaying data in gridview
                            dataGridView1.DataSource = ds.Tables["fetch"].DefaultView;
                            
                        }
                        else
                        {
                            MessageBox.Show("No Record found in this city");
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            } 
        }
        public bool verify_city() // check if user is in the reg center of desired city
        {
            
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select city from registrants where registration_id=@id", con))
                {
                   
                    cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                        while (dr.Read())
                        {
                            if (label6.Text == dr["city"].ToString())
                                city_returned= true;
                            
                        }                                           
                    return city_returned;

                } 
            }
        }
        // it will return text of selected radio button 
        public string radiobtn_vaccination_status()
        {
            string value = "";
            bool isChecked = radioButton2.Checked;
            if (isChecked)
                value = radioButton2.Text;
            else
                value = radioButton1.Text;
            return value;

        }
        // inserting data in vaccination table
        public void insert_data_in_vaccination_table()
        {
           
            
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from registrants where registration_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                    SqlDataReader dr = cmd.ExecuteReader();




                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (check_existing_status())
                            {
                                using (SqlCommand command = new SqlCommand("update vaccination_center set status=@vaccination_status where registration_id=@id", con))
                                {
                                    command.Parameters.AddWithValue("@vaccination_status", radiobtn_vaccination_status());
                                    command.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                                    command.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string name = string.Concat(dr["first_name"], " ", dr["last_name"]);
                                string cnic = dr["cnic"].ToString();
                                int age = Int32.Parse(dr["age"].ToString());
                                string center = label5.Text;
                                string status = radiobtn_vaccination_status();
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
                        update_registration_form();
                        

                    }


                }

                }
            

        }
        // it will update vaccination status in registration form; we will call it in proceed button click event 
        public void update_registration_form()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Update registrants set vaccination_status=@status where registration_id=@reg_id", con))
                {
                    cmd.Parameters.AddWithValue("@reg_id", Int32.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@status", radiobtn_vaccination_status());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Status to: " + radiobtn_vaccination_status());
                }
            }
        }

        // check if record already in vaccination center table.if exist it will notify not to insert new record.
        // just simply update existing one
        public bool check_existing_status()
        {
            using (SqlConnection con=new SqlConnection(connection))
            {
                con.Open();
                using(SqlCommand cmd=new SqlCommand("select * from vaccination_center where registration_id=@reg_id", con))
                {
                    cmd.Parameters.AddWithValue("@reg_id", Int32.Parse(textBox1.Text));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
        }




    private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Vaccination_center_Load(object sender, EventArgs e)
        {
            label5.Text = branchname;
            label6.Text = cityname;
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
        //public bool check_date()
        //{
        //    using (SqlConnection con = new SqlConnection(connection))
        //    {
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand("check_date", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlParameter param = new SqlParameter("@reg_id", Int32.Parse(textBox1.Text));
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if()
        //        }
        //    }

        //        }

        private void button2_Click(object sender, EventArgs e)
        {
            // a comment to test git
            insert_data_in_vaccination_table();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            startpage form = new startpage();
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
