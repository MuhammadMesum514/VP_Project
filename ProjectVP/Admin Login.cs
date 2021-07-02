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
using System.Configuration;

namespace ProjectVP
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=SAM\SQLDEVELOPER;Initial Catalog=VaccinationSystem;Integrated Security=True;MultipleActiveResultSets=True;";


        private void Admin_Login_Load(object sender, EventArgs e)
        {
            
        }

        public void form_login()
        {
            //connectsql cs = new connectsql();
            //cs.connectdb();
            //cs.connect.Open();
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select login,pass from admin_login", con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["login"].ToString() == textBox1.Text && dr["pass"].ToString() == textBox2.Text)
                            {
                                MessageBox.Show("login sucessful");
                                AdminPanel ap = new AdminPanel();
                                ap.Show();
                                this.Hide();

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("invalid login Crendentials");
                MessageBox.Show(e.StackTrace);
            }
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            form_login();
        }
    }
}
