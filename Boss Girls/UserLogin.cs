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
    


    public partial class UserLogin : Form
    {
        string storename;
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//loginButton
        {
            storename = comboBox1.Text;
            string pass= textBox1.Text;
            
            var p = (from d in ent.Stores where pass==d.Store_Password && storename== d.Store_Name
                           select d).FirstOrDefault();
            if(p!=null)
            {
                UserControls usercont = new UserControls(storename);
                this.Hide();
                usercont.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("The Password You entered is not correct!You are not allowed to access the data of this store!");
            }

        }

        private void label1_Click(object sender, EventArgs e)//Home
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)//exit
        {
            this.Close();

        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            var stores = from d in ent.Stores
                         select d.Store_Name;
            foreach(var str in stores)
            {
                comboBox1.Items.Add(str);
            }

        }
    }
}
