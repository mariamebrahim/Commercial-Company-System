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
    public partial class BuyPermission : Form
    {
        string stname;
        BossGirlsCompanyEntities Ent = new BossGirlsCompanyEntities();
        public BuyPermission(string storename)
        {
            InitializeComponent();
            stname = storename;
        }

        private void BuyPermission_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Ent.Buy_Permission.ToList();
            dataGridView2.DataSource = Ent.Buy_Perm_Product.ToList();
            label10.Text=label11.Text = stname;
            
            
            var Client = from d in Ent.Clients
                        select d.Client_ID;
            var Product = from d in Ent.Products
                        select d.Prod_ID;
          
            foreach (var cl in Client)
            {
                comboBox2.Items.Add(cl);
            }
            foreach (var prd in Product)
            {
               comboBox1.Items.Add(prd);
            }
            comboBox3.Items.Add("Piece");
            comboBox3.Items.Add("Kg");
        }

        private void label8_Click(object sender, EventArgs e)//back to user controls
        {
            UserControls user = new UserControls(stname);
            this.Hide();
            user.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//Add products buypermission/product
        {
                Buy_Perm_Product permproduct = new Buy_Perm_Product();
                permproduct.Buy_ID = int.Parse(textBox2.Text);
                permproduct.Prod_ID = int.Parse(comboBox1.Text);
                permproduct.Quantity = int.Parse(textBox1.Text);
                permproduct.Unit = comboBox3.Text;
                Ent.Buy_Perm_Product.Add(permproduct);
                Ent.SaveChanges();
                dataGridView2.DataSource = Ent.Buy_Perm_Product.ToList();


        }

        private void button4_Click(object sender, EventArgs e)//addpermisiion in Buy_Permission Table
        {
            Buy_Permission buyperm = new Buy_Permission();
            int bid = int.Parse(textBox2.Text);
            var id = (from d in Ent.Buy_Permission where d.Buy_ID == bid select d).FirstOrDefault();
            if(id!=null)
            {
                MessageBox.Show("Choose another Permission Id! This one is already token!");
            }
            else
            {
                buyperm.Buy_ID = int.Parse(textBox2.Text);
                buyperm.Store_Name = stname;
                buyperm.Client_ID = int.Parse(comboBox2.Text);
                buyperm.Buy_Date = dateTimePicker1.Value;
                Ent.Buy_Permission.Add(buyperm);
                Ent.SaveChanges();
                dataGridView1.DataSource = Ent.Buy_Permission.ToList();
                MessageBox.Show("Buy Permission has been added to your data!");
            }
          

        }

        private void button3_Click(object sender, EventArgs e)//update permission in buy permisiion table
        {
            int permid = int.Parse(textBox2.Text);
            var perm = (from d in Ent.Buy_Permission where permid == d.Buy_ID select d).First();
            if(perm!=null)
            {
                perm.Client_ID = int.Parse(comboBox2.Text);
                perm.Buy_Date = dateTimePicker1.Value;
                Ent.SaveChanges();
                dataGridView1.DataSource = Ent.Buy_Permission.ToList();
           
                MessageBox.Show("Buy Permission is Updated");
            }
            else
            {
                MessageBox.Show("There is no permisiion with this ID!");
            }
        }

        private void button5_Click(object sender, EventArgs e)//newpermission
        {
            textBox1.Text = textBox2.Text = comboBox1.Text = comboBox2.Text = string.Empty;

        }

        private void button2_Click(object sender, EventArgs e)//update product per permission
        {
            int permid = int.Parse(textBox2.Text);
            int prodid = int.Parse(comboBox1.Text);
            var prod = (from d in Ent.Buy_Perm_Product where permid == d.Buy_ID && prodid == d.Prod_ID select d).First();
            if (prod != null)
            {
                prod.Quantity = int.Parse(textBox1.Text);
                prod.Unit = comboBox3.Text;
                Ent.SaveChanges();
                dataGridView2.DataSource = Ent.Buy_Perm_Product.ToList();
                MessageBox.Show("Product is Updated");
            }
            else
            {
                MessageBox.Show("There is no Product with this ID in this Permission!");
            }

        }

        private void button6_Click(object sender, EventArgs e)//updatestore
        {
            //add product quantity to this store
            int prodid = int.Parse(comboBox1.Text);
            string unit = comboBox3.Text;
            Product_Store prodstr = new Product_Store();
            var prodinstore = (from d in Ent.Product_Store where prodid == d.Prod_ID && stname == d.Store_Name select d).FirstOrDefault();

            if (prodinstore != null)//there is such a product in store
            {

                if (unit == "kg")
                {
                    prodinstore.Quantity = prodinstore.Quantity - (int.Parse(textBox1.Text) * 5);

                }
                else
                {
                    prodinstore.Quantity = prodinstore.Quantity - int.Parse(textBox1.Text);
                }

            }
            else//There is no such product in store create the product in store
            {
                MessageBox.Show("There is no product with this ID in the Store!");
            }

            Ent.SaveChanges();
            MessageBox.Show("Store is updated");

        }
    }
}
