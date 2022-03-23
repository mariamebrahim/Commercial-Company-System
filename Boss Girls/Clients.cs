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
    public partial class Clients : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.Clients.ToList();
            var cid = from d in ent.Clients select d.Client_ID;
            foreach (var c in cid)
            {
                comboBox1.Items.Add(c);
            }

        }

        private void label1_Click(object sender, EventArgs e)//home
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

        private void label8_Click(object sender, EventArgs e)//admin controls
        {

            AdminControls ad = new AdminControls();
            this.Hide();
            ad.ShowDialog();
            this.Close();


        }

        private void button4_Click(object sender, EventArgs e)//add new client
        {
            Client cl = new Client();
            cl.Client_Name = textBox1.Text;
            cl.Client_Phone = int.Parse(textBox2.Text);
            cl.Client_Email = textBox3.Text;
            cl.Client_Fax = textBox4.Text;
            cl.Client_Account = textBox5.Text;
            ent.Clients.Add(cl);
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Clients.ToList();
            
            MessageBox.Show("A new Client has been added to your Data!");
            comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            var cid = from d in ent.Clients select d.Client_ID;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (var p in cid)
                {
                    comboBox1.Items.Add(p);
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)//update client
        {
            int cid = int.Parse(comboBox1.Text);
            var c = (from d in ent.Clients where d.Client_ID == cid select d).FirstOrDefault();
            if (c != null)
            {
                c.Client_Name = textBox1.Text;
                c.Client_Phone = int.Parse(textBox2.Text);
                c.Client_Email = textBox3.Text;
                c.Client_Fax = textBox4.Text;
                c.Client_Account = textBox5.Text;
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Clients.ToList();
                MessageBox.Show("This Client has been Updated!");
                comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;

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
    }
}
