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
    public partial class SelectReport : Form
    {
        public SelectReport()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)//go to stores report
        {
            StoresReport strep = new StoresReport();
            this.Hide();
            strep.ShowDialog();
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

        private void label2_Click(object sender, EventArgs e)
        {
            AdminControls ad = new AdminControls();
            this.Hide();
            ad.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductsReportF prorep = new ProductsReportF();
            this.Hide();
            prorep.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransactionsReport tran = new TransactionsReport();
            this.Hide();
            tran.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductsinstoreTimeReport pd = new ProductsinstoreTimeReport();
            this.Hide();
            pd.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductsexpiryReport pde = new ProductsexpiryReport();
            this.Hide();
            pde.ShowDialog();
            this.Close();
        }
    }
}
