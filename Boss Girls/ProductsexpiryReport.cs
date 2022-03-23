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
    public partial class ProductsexpiryReport : Form
    {
        public ProductsexpiryReport()
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
    }
}
