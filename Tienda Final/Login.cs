using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_Final
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        SqlConnection conecction = new SqlConnection("server=P-122608 ; database = SISTEMA ; INTEGRATED SECURITY = true ");


        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {

                conecction.Open();
                SqlCommand comando = new SqlCommand("SELECT USUARIO, CONTRASENA FROM PERSONA WHERE USUARIO = @vusuario AND CONTRASENA = @vcontrasena", conecction);
                comando.Parameters.AddWithValue("@vusuario", txtusuario.Text);
                comando.Parameters.AddWithValue("@vcontrasena", txtcontrasena.Text);

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    conecction.Close();

                    Form1 pantalla = new Form1();
                    pantalla.Show();

                    this.Hide();


                }

            }
            catch
            {

                MessageBox.Show("INGRESA POR FAVOR UNAS CREDENCIALES VALIDAS");
            
            
            }



        }
        

    }
}