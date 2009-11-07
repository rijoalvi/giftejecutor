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
        private Perfil perfil;
        public FormDetallesPerfil()
        {
            InitializeComponent();
        }
        public FormDetallesPerfil(int IDPerfil)
        {
            InitializeComponent();
            perfil = new Perfil();
            perfil.setDatosPorID(IDPerfil);
            this.textBoxNombre.Text = perfil.getNombre();
            this.textBoxTipo.Text = perfil.getTipo();
        }
        private void buttonAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormAsignarColeccion fac = new FormAsignarColeccion();
            fac.Show();
        }

        private void FormDetallesPerfil_Load(object sender, EventArgs e)
        {
          /*  Perfil p = new Perfil();
    
            for (int i = 0; i < p.perfiles.Count; i++)
            {
                comboBox.Items.Add(p.perfiles[i]);
            }*/



            FlujoTrabajo f = new FlujoTrabajo();
            for (int i = 0; i < f.flujosTrabajo.Count; i++)
            {
                comboBox1.Items.Add(f.flujosTrabajo[i]);
            }
        }

        private void comboBoxFlujoTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}