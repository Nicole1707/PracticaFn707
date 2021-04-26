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
    public partial class Form3 : Form
    {
        EntidadTipoSocio Tsocio = new EntidadTipoSocio();
        ClaseNegocio ejec = new ClaseNegocio();

        public Form3()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "¿Seguro deseas cerrar sesion?";
            string title = "Cerrar Sesion";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Entendido");
            }
        }
        private void MostrarTS()
        {
            cbbuscar.DataSource = ejec.Mostrar();
            cbbuscar.ValueMember = "IDtiposocio";
            cbbuscar.DisplayMember = "Descripcion";
            cbbuscar.SelectedIndex = -1;
        }
        private void NuevaCar()
        {
            dgvTsocio.DataSource = ejec.Mostrar();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dgvTsocio.DataSource = ejec.Mostrar();
            MostrarTS();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Socio soc = new Socio();
            soc.Show();
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            { 
                Tsocio.Descripcion = txtTsocio.Text;
                ejec.agregarTs(Tsocio);
                MessageBox.Show("Agregado correctamente");
                NuevaCar();
                    }
            catch (Exception eex)
            {
                MessageBox.Show(eex.Message);

            }
        }

        private void btnActu_Click(object sender, EventArgs e)
        {
            try
            {

                Tsocio.Descripcion = txtTsocio.Text;
                ejec.actualizarTS(Tsocio);
                MessageBox.Show("Editado correctamente");
                NuevaCar();

            }
            catch (Exception eex)
            {
                MessageBox.Show(eex.Message);

            }
        }
    }
}
