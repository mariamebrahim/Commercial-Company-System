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
    public partial class Supply_Permission : Form
    {
        string strname;
        BossGirlsCompanyEntities Ent = new BossGirlsCompanyEntities();
        public Supply_Permission(string storename)
        {
            InitializeComponent();
            strname = storename;
        }

        private void Supply_Permission_Load(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView1.DataSource = Ent.Supply_Permission.ToList();
            dataGridView2.DataSource = Ent.Supply_Perm_Product.ToList();
            label10.Text = label11.Text = strname;


            var supplier = from d in Ent.Suppliers
                         select d.Sup_ID;
            var Product = from d in Ent.Products
                          select d.Prod_ID;
        

            foreach (var sup in supplier)
            {
                comboBox2.Items.Add(sup);
            }
            foreach (var prd in Product)
            {
                comboBox1.Items.Add(prd);
            }
            comboBox3.Items.Add("Piece");
            comboBox3.Items.Add("Kg");
        }

        private void button4_Click(object sender, EventArgs e)//add supply permission
        {
            Supply_Permission supperm = new Supply_Permission();
            supperm.Sup_Perm_ID = int.Parse(textBox2.Text);
            supperm.Store_Name = strname;
            supperm.Sup_ID = int.Parse(comboBox2.Text);
            supperm.Sup_Perm_Date = dateTimePicker1.Value;
            Ent.Supply_Permission.Add(supperm);
            Ent.SaveChanges();
            dataGridView1.DataSource = Ent.Supply_Permission.ToList();
            MessageBox.Show("Supply Permission has been added to your data!");

        }

        private void button1_Click(object sender, EventArgs e)//add products to your supplier permission 
        {
            //add products to permission
            Supply_Perm_Product permproduct = new Supply_Perm_Product();
            permproduct.Sup_Perm_ID= int.Parse(textBox2.Text);
            permproduct.Prod_ID= int.Parse(comboBox1.Text);
            permproduct.Quantity = int.Parse(textBox1.Text);
            permproduct.Unit = comboBox3.Text;
            permproduct.Production_Date = dateTimePicker2.Value;
            permproduct.Expire_Date = dateTimePicker3.Value;
            Ent.Supply_Perm_Product.Add(permproduct);         
            Ent.SaveChanges();
            dataGridView2.DataSource = Ent.Supply_Perm_Product.ToList();
            MessageBox.Show("Product is added to this Permission!");

        }

        private void button6_Click(object sender, EventArgs e)//update product/store
        {
            //add product quantity to this store
            int prodid = int.Parse(comboBox1.Text);
            string unit = comboBox3.Text;
            Product_Store prodstr = new Product_Store();
            var prodinstore = (from d in Ent.Product_Store where prodid == d.Prod_ID && strname == d.Store_Name select d).FirstOrDefault();

            if (prodinstore != null)//there is such a product in store
            {
                if (unit == "kg")
                {
                    prodinstore.Quantity = prodinstore.Quantity + (int.Parse(textBox1.Text) * 5);

                }
                else
                {
                    prodinstore.Quantity = prodinstore.Quantity + int.Parse(textBox1.Text);
                }


            }
            else//There is no such product in store create the product in store
            {
                prodstr.Store_Name = strname;
                prodstr.Prod_ID = int.Parse(comboBox1.Text);
                if (unit == "kg")
                {
                    prodstr.Quantity = int.Parse(textBox1.Text) * 5;

                }
                else
                {
                    prodstr.Quantity = int.Parse(textBox1.Text);
                }
                Ent.Product_Store.Add(prodstr);
            }
           
            Ent.SaveChanges();
            MessageBox.Show("Store is updated");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = string.Empty;

        }

        private void button3_Click(object sender, EventArgs e)//update permission in supply permission table
        {
            int permid = int.Parse(textBox2.Text);
            var perm = (from d in Ent.Supply_Permission where permid == d.Sup_ID select d).FirstOrDefault();
            if (perm != null)
            {
                perm.Sup_ID = int.Parse(comboBox2.Text);
                perm.Sup_Perm_Date = dateTimePicker1.Value;
                Ent.SaveChanges();
                dataGridView1.DataSource = Ent.Supply_Permission.ToList();

                MessageBox.Show("Supply Permission is Updated");
            }
            else
            {
                MessageBox.Show("There is no permisiion with this ID!");
            }

        }

        private void button2_Click(object sender, EventArgs e)//update product/permission in supplypermission/ product table
        {
            int permid = int.Parse(textBox2.Text);
            int prodid = int.Parse(comboBox1.Text);
            var prod = (from d in Ent.Supply_Perm_Product where permid == d.Sup_Perm_ID && prodid == d.Prod_ID select d).First();
            if (prod != null)
            {
                prod.Quantity = int.Parse(textBox1.Text);
                prod.Unit = comboBox3.Text;
                prod.Production_Date = dateTimePicker2.Value;
                prod.Expire_Date = dateTimePicker3.Value;
                Ent.SaveChanges();
                dataGridView2.DataSource = Ent.Supply_Perm_Product.ToList();
                MessageBox.Show("Product is Updated");
            }
            else
            {
                MessageBox.Show("There is no Product with this ID in this Permission!");
            }

        }

        private void label1_Click(object sender, EventArgs e)//Home
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

        private void label8_Click(object sender, EventArgs e)
        {
            UserControls cont = new UserControls(strname);
            this.Hide();
            cont.ShowDialog();
            this.Close();
        }
    }
}
