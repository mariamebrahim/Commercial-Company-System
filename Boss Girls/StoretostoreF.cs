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
    public partial class StoretostoreF : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public StoretostoreF()
        {
            InitializeComponent();
           

        }

        private void StoretostoreF_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.Store_to_stores.ToList();
            dataGridView2.DataSource = ent.Product_Store.ToList();
            var stnames = from d in ent.Stores select d.Store_Name;
            foreach(var stn in stnames)
            {
                comboBox1.Items.Add(stn);
                comboBox2.Items.Add(stn);
            }
            var sid = from d in ent.Suppliers select d.Sup_ID;
            foreach(var s in sid)
            {
                comboBox4.Items.Add(s);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//check if store has products or no
        {
            string store = comboBox1.Text;
            var stfrom = (from d in ent.Product_Store where store == d.Store_Name select d).FirstOrDefault();
            if(stfrom != null)
            {

            }
            else
            {
                MessageBox.Show("Choose another store this store has no products!");
            }
            var prodid = from d in ent.Product_Store where store == d.Store_Name select d.Prod_ID;
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.Items.Clear();

            }
            foreach (var pid in prodid)
            {
               
                comboBox3.Items.Add(pid);
            }
        }

        private void button4_Click(object sender, EventArgs e)//transact from store to store
        {
            Store_to_store ex = new Store_to_store();
            ex.Store_From = comboBox1.Text;
            ex.Store_To = comboBox2.Text;
            ex.Prod_ID = int.Parse(comboBox3.Text);
            ex.Quantity = int.Parse(textBox4.Text);
            ex.Sup_ID = int.Parse(comboBox4.Text);
            ent.Store_to_stores.Add(ex);
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Store_to_stores.ToList();
            MessageBox.Show("Product from " + comboBox1.Text + " to " + comboBox2.Text + " has been Tranacted!");
        }

        private void button3_Click(object sender, EventArgs e)//update product/store Table
        {
            //add product quantity to this store
            string StoreFrom = comboBox1.Text;
            string Storeto = comboBox2.Text;
            int prodid = int.Parse(comboBox3.Text);
            Product_Store prodstr = new Product_Store();
            var prodinstorefrom = (from d in ent.Product_Store where prodid == d.Prod_ID && StoreFrom == d.Store_Name select d).FirstOrDefault();
            if (prodinstorefrom != null)//there is such a product in store
            {
                prodinstorefrom.Quantity = prodinstorefrom.Quantity - (int.Parse(textBox4.Text));

            }
            var prodinstoreto = (from d in ent.Product_Store where prodid == d.Prod_ID && Storeto == d.Store_Name select d).FirstOrDefault();
            if (prodinstoreto != null)
            {
                prodinstoreto.Quantity = prodinstoreto.Quantity + (int.Parse(textBox4.Text));
            }else
            {
                Product_Store newprod = new Product_Store();
                newprod.Store_Name = Storeto;
                newprod.Prod_ID = int.Parse(comboBox3.Text);
                newprod.Quantity = int.Parse(textBox4.Text);
                ent.Product_Store.Add(newprod);
            }
            ent.SaveChanges();
            dataGridView2.DataSource = ent.Product_Store.ToList();
            MessageBox.Show("Store is updated");

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

        private void label8_Click(object sender, EventArgs e)
        {
            AdminControls ad= new AdminControls();
            this.Hide();
            ad.ShowDialog();
            this.Close();

        }
    }
}
