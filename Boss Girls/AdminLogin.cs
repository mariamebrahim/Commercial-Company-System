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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)//Home
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)//Exit
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)//Login
        {
            string pass = textBox2.Text;
            BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
            var admin = (from d in ent.Employees
                         where pass == d.Emp_Password
                         select d).FirstOrDefault();
            if (admin!=null)
            {
                AdminControls adm= new AdminControls();
                this.Hide();
                adm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sorry!You are not an Admin");
            }
        }
    }
}
