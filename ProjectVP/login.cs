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

namespace ProjectVP
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SKRQQHL\SQLEXPRESS;Initial Catalog=VaccinationSystem;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from login where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            string value = comboBox1.SelectedItem.ToString();
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                for(int i=0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i]["user_role"].ToString() == value)
                    {
                        if(comboBox1.SelectedIndex == 0)
                        {
                            AdminPanel form = new AdminPanel();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            Vaccination_center form = new Vaccination_center();
                            form.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Role login");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }
    }
}
