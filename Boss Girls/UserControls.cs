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
    public partial class UserControls : Form
    {
        string storename;
        public UserControls(string stname)
        {
            InitializeComponent();
            storename = stname;
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

        private void button2_Click(object sender, EventArgs e)//buypermissionform
        {
            BuyPermission Buy_Perm = new BuyPermission(storename);
            this.Hide();
            Buy_Perm.ShowDialog();
            this.Close();
        }

        private void UserControls_Load(object sender, EventArgs e)
        {
            label2.Text = storename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Supply_Permission sup_Perm = new Supply_Permission(storename);
            this.Hide();
            sup_Perm.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientsData cl = new ClientsData(storename);
            this.Hide();
            cl.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SuppliersData sup = new SuppliersData(storename);
            this.Hide();
            sup.ShowDialog();
            this.Close();
        }
    }
}
