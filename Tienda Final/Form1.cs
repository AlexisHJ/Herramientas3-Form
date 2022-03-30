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
                textBox7.Text = Otabla.IVA;
            }     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
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
