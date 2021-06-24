using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProjectVP;

namespace ProjectVP
{

    public partial class login : Form
    {
        string value,bcode;

        public login()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=SAM\SQLDEVELOPER;Initial Catalog=VaccinationSystem;Integrated Security=True;MultipleActiveResultSets=True;";
        




        private void Loginbtn_Click(object sender, EventArgs e)
        {
            form_login();
        }
        public void bindata()
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

        public void getbranchname() // get branch name for next form
        {
            using (SqlConnection con = new SqlConnection(connection))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("select center_name from branches where branch_code=@branch", con))
                {
                    cmd.Parameters.AddWithValue("@branch", textBox3.Text);
                    SqlDataReader dr= cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bcode = dr[0].ToString();
                    }

                }
            }
        }
        public bool verify(string s) //verify branch code
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {

                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select braNch_code from branches where city=@city", con))
                    {
                        cmd.Parameters.AddWithValue("@city", s);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (textBox3.Text == dr[0].ToString())
                            {
                                return true;
                            }
                            else {
                                return false;
                            }
                        }

                    }
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("no record found"+e.StackTrace);
                return false;
                
            }
        }
        public void form_login()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                 value = comboBox1.SelectedItem.ToString();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select login,pass from city_login where CITY=@city", con))
                {
                    cmd.Parameters.AddWithValue("@city", value);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if(dr["login"].ToString()==textBox1.Text && dr["pass"].ToString() == textBox2.Text)
                        {
                            if (verify(value)) //will check for branch code
                            {
                                getbranchname();
                               
                                MessageBox.Show("login sucessful");
                                Vaccination_center vc = new Vaccination_center();
                                vc.show_city(value);
                                vc.show_branch(bcode);
                                vc.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("branch code is not valid");
                            }
                        }
                        else
                        {
                            MessageBox.Show("invalid login Credentials");
                        }
                    }
                }
            }
        }
        private void login_Load(object sender, EventArgs e)
        {
            bindata();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
