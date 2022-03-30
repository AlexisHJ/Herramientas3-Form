using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda_Final.Models;

namespace Tienda_Final
{
    public partial class Form1 : Form
    {
        public int? ID;
        Tienda5 Otabla = null;
        public Form1(int? ID = null)
        {
            InitializeComponent();

            this.ID = ID;
            if (ID != null)
            {
                LoadDate();
            }

        }

        private void LoadDate()
        {
            using (CRUDEntities5 db = new CRUDEntities5())
            {
                Otabla = db.Tienda5.Find(ID);
                textBox1.Text = Otabla.Nombre_Cliente;
                textBox2.Text = Otabla.Cedula_Cliente;
                textBox3.Text = Otabla.Tipo_Producto;
                textBox4.Text = Otabla.Estado_Producto;
                textBox5.Text = Otabla.Producto;
                textBox6.Text = Otabla.Sitio;
                textBox5.Text = Otabla.IVA;
                 


            }

        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
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

        #region HELPER
        private void Refrescar()
        {
            using (CRUDEntities5 db = new CRUDEntities5())
            {
                var list = from a in db.Tienda5
                           select a;
                dataGridView1.DataSource = list.ToList();



            }
        }
        private int? GetID()
        {
            try
            {
               return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            }
            catch

            {

                return null;
            }
            
        }

    

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Refrescar();
            using (CRUDEntities5 db = new CRUDEntities5())
            {
                if (ID == null)
                    Otabla = new Tienda5();
                Otabla.Nombre_Cliente = textBox1.Text;
                Otabla.Cedula_Cliente = textBox2.Text;
                Otabla.Tipo_Producto = textBox3.Text;
                Otabla.Estado_Producto = textBox4.Text;
                Otabla.Producto = textBox5.Text;
                Otabla.Sitio = textBox6.Text;
                Otabla.IVA = textBox7.Text;

                if(ID == null)
                    db.Tienda5.Add(Otabla);
                else
                {
                    db.Entry(Otabla).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();


            }
            /*int p = dataGridView1.Rows.Add();
            dataGridView1.Rows[p].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[p].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[p].Cells[2].Value = textBox3.Text;
            dataGridView1.Rows[p].Cells[3].Value = textBox4.Text;
            dataGridView1.Rows[p].Cells[4].Value = textBox5.Text;
            dataGridView1.Rows[p].Cells[5].Value = textBox6.Text;
            dataGridView1.Rows[p].Cells[6].Value = textBox7.Text;*/
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

        private void button1_Click(object sender, EventArgs e)
        {
            int? ID = GetID();
            if (ID != null)
               
                using (CRUDEntities5 db = new CRUDEntities5())
                {
                    Tienda5 Otabla = db.Tienda5.Find(ID);
                    db.Tienda5.Remove(Otabla);


                    db.SaveChanges();
                }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";

            Refrescar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? ID = GetID();
            if (ID != null)
            {
                Form1 edit = new Form1(ID);
                edit.ShowDialog();

                Refrescar();
            }
        }
    }
}
