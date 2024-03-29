using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    /// <summary>
    /// Ventana que permite la creaci�n de nuevos perfiles
    /// </summary>
    public partial class FormNuevoPerfil : Form
    {
        FormGestionPerfiles gestionPerfiles;
        Perfil perfil;
        public FormNuevoPerfil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gestionPerfiles"></param>
        public FormNuevoPerfil(FormGestionPerfiles gestionPerfiles)
        {
            InitializeComponent();
            perfil = new Perfil();
            this.gestionPerfiles = gestionPerfiles;
        }

        private void NuevoPerfil_Load(object sender, EventArgs e)
        {
            this.textBoxNombrePerfil.Focus();
        }
        private String getTipoSeleccionado() { 
            if(this.radioButton1.Checked){
                return this.radioButton1.Text;
            }
            if (this.radioButton2.Checked)
            {
                return this.radioButton2.Text;
            }
            if (this.radioButton3.Checked)
            {
                return this.radioButton3.Text;
            }
            if (this.radioButton4.Checked)
            {
                return this.radioButton4.Text;
            }
            MessageBox.Show("Tipo no seleccionado");
            return null;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.camposValidos()) {
                this.perfil.addNuevoPerfil(this.textBoxNombrePerfil.Text, this.getTipoSeleccionado(), -1);
                this.gestionPerfiles.actulizarDataGrid();
                this.Dispose();
            }

        }

        /// <summary>
        /// Revisa que todos los campos hayan sido digitados correctamente por el usuario
        /// </summary>
        /// <returns></returns>
        public bool camposValidos(){
            if (this.textBoxNombrePerfil.Text.Equals("")){
                this.mostrarError();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Muestra un error indicando que los datos no son v�lidos
        /// </summary>
        public void mostrarError() {
            MessageBox.Show("Datos no v�lidos");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}