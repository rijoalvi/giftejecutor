using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormDetallesPerfil : Form
    {
        public FormDetallesPerfil()
        {
            InitializeComponent();
        }

        private void buttonAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormAsignarColeccion fac = new FormAsignarColeccion();
            fac.Show();
        }
    }
}