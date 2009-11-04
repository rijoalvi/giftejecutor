using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class NuevoPerfil : Form
    {
        GestionPerfiles gestionPerfiles;
        Perfil perfil;
        public NuevoPerfil()
        {
            InitializeComponent();
        }
        public NuevoPerfil(GestionPerfiles gestionPerfiles)
        {
            InitializeComponent();
            perfil = new Perfil();
            this.gestionPerfiles = gestionPerfiles;
        }

        private void NuevoPerfil_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.camposValidos()) {
                this.perfil.addNuevoPerfil(this.textBoxNombrePerfil.Text, this.textBoxTipoPerfil.Text, -1);
                this.gestionPerfiles.actulizarDataGrid();
                this.Dispose();
            }

        }
        public bool camposValidos(){
            if (this.textBoxNombrePerfil.Text.Equals("")){
                this.mostrarError();
                return false;
            }
            if (this.textBoxTipoPerfil.Text.Equals(""))
            {
                this.mostrarError();
                return false;
            }
            return true;
        }
        public void mostrarError() {
            MessageBox.Show("Datos no válidos");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}