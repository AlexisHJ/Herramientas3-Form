using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Tienda_Final.Models;

namespace Tienda_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            /*using (CRUDEntities db = new CRUDEntities())
            {
                var list = from a in db.TIENDA
                           select a;
                dataGridView1.DataSource = list.ToList();
            
            
            
            
            }
            /*comboBox1.Items.Add("Usado");
            comboBox1.Items.Add("Nuevo");
            comboBox4.Items.Add("Domicilio");
            comboBox4.Items.Add("Tienda");
            comboBox5.Items.Add("Tiene IVA");
            comboBox5.Items.Add("Excento de IVA");
            comboBox2.Items.Add("Tableta/IPAD");
            comboBox2.Items.Add("Celular");
            comboBox2.Items.Add("Laptop");
            comboBox2.Items.Add("Destock");
            comboBox2.Items.Add("Cargador");
            comboBox2.Items.Add("Protector");
            comboBox2.Items.Add("Carcasa");
            comboBox2.Items.Add("Monitor");
            comboBox2.Items.Add("Disco Duro Solido");
            comboBox2.Items.Add("Memoria RAM");
            comboBox2.Items.Add("Otros");
            comboBox3.Items.Add("Aprobado");
            comboBox3.Items.Add("Reprobado");*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int p = dataGridView1.Rows.Add();
            dataGridView1.Rows[p].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[p].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[p].Cells[2].Value = textBox3.Text;
            dataGridView1.Rows[p].Cells[3].Value = textBox4.Text;
            dataGridView1.Rows[p].Cells[4].Value = textBox5.Text;
            dataGridView1.Rows[p].Cells[5].Value = textBox6.Text;
            dataGridView1.Rows[p].Cells[6].Value = textBox7.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
