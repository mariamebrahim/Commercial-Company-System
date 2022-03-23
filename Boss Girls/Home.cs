using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boss_Girls
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)//open userlogin
        {
            UserLogin user = new UserLogin();
            this.Hide();
            user.ShowDialog();
            this.Close();

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.IndianRed;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkSalmon;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.IndianRed;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.DarkSalmon;
        }

        private void label2_Click(object sender, EventArgs e)//Admin login
        {
            AdminLogin admin = new AdminLogin();
            this.Hide();
            admin.ShowDialog();
            this.Close();

        }
    }
}
