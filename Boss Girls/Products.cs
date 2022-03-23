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
    public partial class Products : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            var pdid = from d in ent.Products select d.Prod_ID;
            foreach(var p in pdid)
            {
                comboBox1.Items.Add(p);
            }
            dataGridView1.DataSource = ent.Products.ToList();
            dataGridView2.DataSource = ent.Product_Store.ToList();

        }

        private void button4_Click(object sender, EventArgs e)//add product
        {
            string pdname = textBox1.Text;
            Product prod = new Product();
            var pd = (from d in ent.Products where d.Prod_Name == pdname select d).FirstOrDefault();
            if (pd != null)
            {
                MessageBox.Show("There is a product with the exact name! Please Choose a new name!");
            }else
            {
                prod.Prod_Name = textBox1.Text;
                ent.Products.Add(prod);
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Products.ToList();
                MessageBox.Show("A new Product is added to your Data!");
                comboBox1.Text = textBox1.Text = string.Empty;
            }
            var pdid = from d in ent.Products select d.Prod_ID;
            if(comboBox1.Items.Count>0)
            {
                comboBox1.Items.Clear();
                foreach (var p in pdid)
                {
                    comboBox1.Items.Add(p);
                }

            }
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pdid = int.Parse(comboBox1.Text);
            var pd = (from d in ent.Products where d.Prod_ID == pdid select d).FirstOrDefault();
            if(pd!=null)
            {
                pd.Prod_Name = textBox1.Text;
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Products.ToList();
                MessageBox.Show("Your Product Data has been Updated!");
            }else
            {
                MessageBox.Show("There is no Product with such ID to update!");

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = dgv.Cells[0].Value.ToString();
                textBox1.Text = dgv.Cells[1].Value.ToString();
            }
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

        private void label8_Click(object sender, EventArgs e)//back
        {
            AdminControls ad = new AdminControls();
            this.Hide();
            ad.ShowDialog();
            this.Close();

        }
    }
}
