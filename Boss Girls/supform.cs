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
    public partial class supform : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public supform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)//home
        {
            Home h = new Home();
            this.Hide();
            h.ShowDialog();
            this.Close();


        }

        private void label4_Click(object sender, EventArgs e)//exit
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AdminControls ad = new AdminControls();
            this.Hide();
            ad.ShowDialog();
            this.Close();

        }

        private void supform_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.Suppliers.ToList();
            var sid = from d in ent.Suppliers select d.Sup_ID;
            foreach(var s in sid)
            {
                comboBox1.Items.Add(s);
            }

        }

        private void button4_Click(object sender, EventArgs e)//Add supplier
        {
            Supplier sup = new Supplier();
            sup.Sup_Name = textBox1.Text;
            sup.Sup_Phone =int.Parse(textBox2.Text);
            sup.Sup_Email = textBox3.Text;
            sup.Sup_Fax = textBox4.Text;
            sup.Sup_Account = textBox5.Text;
            ent.Suppliers.Add(sup);
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Suppliers.ToList();
            comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            MessageBox.Show("A new supplier has been added to your Data");
            var sid = from d in ent.Suppliers select d.Sup_ID;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (var p in sid)
                {
                    comboBox1.Items.Add(p);
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = dgv.Cells[0].Value.ToString();
                textBox1.Text = dgv.Cells[1].Value.ToString();
                textBox2.Text = dgv.Cells[2].Value.ToString();
                textBox3.Text = dgv.Cells[3].Value.ToString();
                textBox4.Text = dgv.Cells[4].Value.ToString();
                textBox5.Text = dgv.Cells[5].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)//Update supplier
        {
            int sid = int.Parse(comboBox1.Text);
            var s = (from d in ent.Suppliers where d.Sup_ID == sid select d).FirstOrDefault();
            if(s!=null)
            {
                s.Sup_Name = textBox1.Text;
                s.Sup_Phone = int.Parse(textBox2.Text);
                s.Sup_Email = textBox3.Text;
                s.Sup_Fax = textBox4.Text;
                s.Sup_Account = textBox5.Text;
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Suppliers.ToList();
                MessageBox.Show("This Supplier has been Updated!");

            }

        }
    }
}
