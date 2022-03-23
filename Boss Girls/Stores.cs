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
    public partial class Stores : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public Stores()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)//back
        {
            AdminControls adcont = new AdminControls();
            this.Hide();
            adcont.ShowDialog();
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)//home
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)//close
        {
            this.Close();
        }

        private void Stores_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.Stores.ToList();
            var managid = from d in ent.Employees select d.Emp_ID;
            foreach(var m in managid)
            {
                comboBox1.Items.Add(m);
            }

        }

        private void button4_Click(object sender, EventArgs e)//Add store
        {
            Store st = new Store();
            string stname = textBox1.Text;
            var storename = (from d in ent.Stores where d.Store_Name == stname select d).FirstOrDefault();
            if(storename!= null)
            {
                MessageBox.Show("Choose another store name this name already exists!");
            }
            else
            {
                st.Store_Name = textBox1.Text;
                st.Store_Address = textBox2.Text;
                st.Manager_ID = int.Parse(comboBox1.Text);
                st.Store_Password = textBox3.Text;
                ent.Stores.Add(st);
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Stores.ToList();
                MessageBox.Show("New Store is added to your Data!");
            }

        }

        private void button3_Click(object sender, EventArgs e)//update store data
        {
            string stname = textBox1.Text;
            var str = (from d in ent.Stores where d.Store_Name == stname select d).FirstOrDefault();

            if(str != null)
            {
                str.Store_Name = textBox1.Text;
                str.Store_Address = textBox2.Text;
                str.Manager_ID = int.Parse(comboBox1.Text);
                str.Store_Password = textBox3.Text;
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Stores.ToList();
                MessageBox.Show("Store is updated");
            }else
            {
                MessageBox.Show("There is no store with this name in our data!");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = dgv.Cells[0].Value.ToString();
                textBox2.Text = dgv.Cells[1].Value.ToString();
                comboBox1.Text = dgv.Cells[2].Value.ToString();
                textBox3.Text = dgv.Cells[3].Value.ToString();
            }

        }
    }
}
