using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVP
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            login form = new login();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            global_report_evaluation gre = new global_report_evaluation();
            gre.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            City_based_Evaluation cbe = new City_based_Evaluation();
            cbe.Show();
            this.Hide();
        }
    }
}
