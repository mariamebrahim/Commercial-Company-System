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
    public partial class Employees : Form
    {
        BossGirlsCompanyEntities ent = new BossGirlsCompanyEntities();
        public Employees()
        {
            InitializeComponent();
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
            AdminControls ad = new AdminControls();
            this.Hide();
            ad.ShowDialog();
            this.Close();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ent.Employees.ToList();
            var eid = from d in ent.Employees select d.Emp_ID;
            foreach (var emp in eid)
            {
                comboBox1.Items.Add(emp);
            }
        }

        private void button4_Click(object sender, EventArgs e)//add employee
        {
            Employee emp = new Employee();
            emp.Emp_Name = textBox1.Text;
            emp.Emp_Phone = int.Parse(textBox2.Text);
            emp.Emp_Address = textBox3.Text;
            emp.Emp_Password = textBox4.Text;
            ent.Employees.Add(emp);
            ent.SaveChanges();
            dataGridView1.DataSource = ent.Employees.ToList();
            MessageBox.Show("A new Employee has been added to your Data!");
            comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text  = string.Empty;
            var eid = from d in ent.Employees select d.Emp_ID;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (var p in eid)
                {
                    comboBox1.Items.Add(p);
                }

            }


        }

        private void button3_Click(object sender, EventArgs e)//Update EMPLOYEE
        {
            int Eid = int.Parse(comboBox1.Text);
            var E = (from d in ent.Employees where d.Emp_ID == Eid select d).FirstOrDefault();
            if (E != null)
            {
                E.Emp_Name = textBox1.Text;
                E.Emp_Phone = int.Parse(textBox2.Text);
                E.Emp_Address = textBox3.Text;
                E.Emp_Password = textBox4.Text;
                ent.SaveChanges();
                dataGridView1.DataSource = ent.Employees.ToList();
                MessageBox.Show("This Employee Data has been Updated!");
                comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;

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
            }
        }
    }
}
