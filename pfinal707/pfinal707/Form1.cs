using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CEntidad;
using CNegocio;

namespace pfinal707
{
    public partial class Form1 : Form
    {
        ClaseEntidad usuario = new ClaseEntidad();
        ClaseNegocio ejc = new ClaseNegocio();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            usuario.user = txtusuario.Text;
            usuario.pass = txtpass.Text;

            tb = ejc.logear(usuario);

            if (tb.Rows.Count > 0)
            {
                usuario.user = tb.Rows[0][0].ToString();
                usuario.pass = tb.Rows[0][1].ToString();

                MessageBox.Show("Bienvenido al sistema " + usuario.user);

                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();


            }
            else
            {
                MessageBox.Show("Datos Erroneos. Intente de nuevo");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            foreach (Control oControls in this.Controls)
            {
                if (oControls is TextBox)
                {
                    oControls.Text = "";
                }
            }
        }
    }
}
