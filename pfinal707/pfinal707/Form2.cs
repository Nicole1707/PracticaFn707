using pfinal707;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNegocio
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Socio soc = new Socio();
            soc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
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

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }
    }
}
