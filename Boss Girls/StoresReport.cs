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
    public partial class StoresReport : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public StoresReport()
        {
            InitializeComponent();
        }

        private void StoresReport_Load(object sender, EventArgs e)
        {
            var stores = from d in ent.Stores select d.Store_Name;
            foreach (var d in stores)
            {
                comboBox1.Items.Add(d);
            }

            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stname = comboBox1.Text;
            var stdata = from d in ent.Stores where d.Store_Name == stname select d;
            foreach(var d in stdata)
            {
               // dataGridView1.items.Add(d);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SelectReport reps = new SelectReport();
            this.Hide();
            reps.ShowDialog();
            this.Close();
        }
    }
}
