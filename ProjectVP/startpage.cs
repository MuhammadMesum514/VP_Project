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
    public partial class startpage : Form
    {
        public startpage()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            login branch = new login();
            branch.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Admin_Login ap = new Admin_Login();
            ap.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void startpage_Load(object sender, EventArgs e)
        {
            
        }
    }
}
