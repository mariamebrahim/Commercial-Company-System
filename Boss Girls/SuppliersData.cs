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
    public partial class SuppliersData : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        string strname;
        public SuppliersData(string stname)
        {
            InitializeComponent();
            strname = stname;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UserControls cont = new UserControls(strname);
            this.Hide();
            cont.ShowDialog();
            this.Close();
        }

        private void SuppliersData_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.Suppliers.ToList();
        }
    }
}
