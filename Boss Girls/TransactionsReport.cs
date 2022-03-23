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
    public partial class TransactionsReport : Form
    {
        public TransactionsReport()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SelectReport rep = new SelectReport();
            this.Hide();
            rep.ShowDialog();
            this.Close();
        }

        private void TransactionsReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
