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
    public partial class Socio : Form
    {
        EntidadSocio Psocio = new EntidadSocio();
        ClaseNegocio ejec = new ClaseNegocio();
        public Socio()
        {
            InitializeComponent();
        }

        private void Socio_Load(object sender, EventArgs e)
        {
            dgvSocios.DataSource = ejec.Leer();
            MostrarTS();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Psocio.IDsocio = txtid.Text;
                Psocio.Tiposocio = Convert.ToInt32(cbTipoSocio.SelectedValue);
                Psocio.Nombre = txtnombre.Text;
                Psocio.Apellido = txtApellido.Text;
                Psocio.NombreCompleto = txtnombre.Text + " " + txtApellido.Text;
                if (cbFemenino.Checked == true)
                {
                    Psocio.Sexo = "F";

                }
                else if (cbMasculino.Checked == true)
                {
                    Psocio.Sexo = "M";

                }
                Psocio.Cedula = txtCedula.Text;
                Psocio.FechaIngreso = dtFechaIng.Value;
                Psocio.FechaNac = dtFechaNa.Value;
                Psocio.Direccion = txtDirec.Text;
                Psocio.Telefono = txtTelefono.Text;
                Psocio.Celular = txtCeluar.Text;
                Psocio.Email = TxtEmail.Text;


                if (rbInactivo.Checked == true)
                {
                    Psocio.Estatus = "0";

                }
                else if (rbActivo.Checked == true)
                {
                    Psocio.Estatus = "1";

                }
                ejec.agregar(Psocio);
                MessageBox.Show("Agregado correctamente");
                NuevaCar();
                //dgvVendedor.DataSource = ejec.Leer();
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

                Psocio.IDsocio = txtid.Text;
                Psocio.Tiposocio = Convert.ToInt32(cbTipoSocio.SelectedValue);
                Psocio.Nombre = txtnombre.Text;
                Psocio.Apellido = txtApellido.Text;
                Psocio.NombreCompleto = txtnombre.Text + " "+ txtApellido.Text;
                if (cbFemenino.Checked == true)
                {
                    Psocio.Sexo = "F";

                }
                else if (cbMasculino.Checked == true)
                {
                    Psocio.Sexo = "M";

                }
                Psocio.Cedula = txtCedula.Text;
                Psocio.FechaIngreso = dtFechaIng.Value;
                Psocio.FechaNac = dtFechaNa.Value;
                Psocio.Direccion = txtDirec.Text;
                Psocio.Telefono = txtTelefono.Text;
                Psocio.Celular = txtCeluar.Text;
                Psocio.Email = TxtEmail.Text;

                    if (rbInactivo.Checked == true)
                    {
                        Psocio.Estatus = "0";

                    }
                    else if (rbActivo.Checked == true)
                    {
                        Psocio.Estatus = "1";

                    }
                ejec.editar(Psocio);
                MessageBox.Show("Editado correctamente");
                NuevaCar();

            }
            catch (Exception eex)
            {
                MessageBox.Show(eex.Message);

            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            string va = txtCedula.Text;
            string message = "¿Seguro deseas eliminar este registro cedula " +Psocio.Cedula + " ?";
            string title = "Cerrar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Psocio.Cedula = txtCedula.Text;
                    ejec.borrar(va);
                    MessageBox.Show("Borrado correctamente");
                    NuevaCar();

                }
                catch (Exception eex)
                {
                    MessageBox.Show(eex.Message);
                    

                }
            }
            else
            {
                MessageBox.Show("Registro no eliminado");
                NuevaCar();


            }
        }

        private void cbTipoSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbTipoSocio.DataSource = null;

        }

        private void MostrarTS()
        {
            cbTipoSocio.DataSource = ejec.Mostrar();
            cbTipoSocio.ValueMember = "IDtiposocio";
            cbTipoSocio.DisplayMember = "Descripcion";
            cbTipoSocio.SelectedIndex = -1;
        }
        private void NuevaCar()
        {
            dgvSocios.DataSource = ejec.Leer();
        }

        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtid.Text = dgvSocios.CurrentRow.Cells[1].Value.ToString();
                cbTipoSocio.SelectedValue = dgvSocios.CurrentRow.Cells[2].Value.ToString();
                txtnombre.Text = dgvSocios.CurrentRow.Cells[3].Value.ToString();
                txtApellido.Text = dgvSocios.CurrentRow.Cells[4].Value.ToString();
                txtCedula.Text = dgvSocios.CurrentRow.Cells[7].Value.ToString();
                txtDirec.Text = dgvSocios.CurrentRow.Cells[10].Value.ToString(); ;
                txtTelefono.Text = dgvSocios.CurrentRow.Cells[11].Value.ToString(); ;
                txtCeluar.Text = dgvSocios.CurrentRow.Cells[12].Value.ToString(); ;
                TxtEmail.Text= dgvSocios.CurrentRow.Cells[13].Value.ToString(); 

            }
            catch { }
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

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            string val = txtBuscar.Text;

            dgvSocios.DataSource = ejec.Busqueda(val);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
