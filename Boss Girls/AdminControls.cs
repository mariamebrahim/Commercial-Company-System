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
    public partial class AdminControls : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        string stname;
        public AdminControls()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)//suplier form
        {
            supform supp= new supform();
            this.Hide();
            supp.ShowDialog();
            this.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)//store form
        {
            Stores store = new Stores();
            this.Hide();
            store.ShowDialog();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)//products form
        {
            Products product = new Products();
            this.Hide();
            product.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)//buypermission
        {
            stname = comboBox1.Text;
            BuyPermission bp = new BuyPermission(stname);
            this.Hide();
            bp.ShowDialog();
            this.Close();

        }

        private void AdminControls_Load(object sender, EventArgs e)
        {
            var stores = from d in ent.Stores select d.Store_Name;
            foreach(var st in stores)
            {
                comboBox1.Items.Add(st);
            }

        }

        private void button1_Click(object sender, EventArgs e)//supplypermission
        {
            Supply_Permission superm = new Supply_Permission(stname);
            this.Close();
            superm.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)//clients
        {
            Clients cl = new Clients();
            this.Hide();
            cl.ShowDialog();
            cl.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            this.Hide();
            emp.ShowDialog();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)//storesexchange 
        {
            StoretostoreF stex = new StoretostoreF();
            this.Hide();
            stex.ShowDialog();
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)//go select your report
        {
            SelectReport selectreport = new SelectReport();
            this.Hide();
            selectreport.ShowDialog();
            this.Close();
        }
    }
}
