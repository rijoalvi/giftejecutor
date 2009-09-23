using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormNuevaColeccion : Form
    {
        FormPrincipal formPrincipal;
        int correlativoPadre;
        int correlativoFlujo;
        int modificar;
        int correlativoColeccion;
        public FormNuevaColeccion(FormPrincipal principal, String correlativoPadre, String correlativoFlujo)
        {
            this.correlativoPadre = int.Parse(correlativoPadre);           
            this.correlativoFlujo = int.Parse(correlativoFlujo);
            this.formPrincipal = principal;
            this.modificar = 0;
            InitializeComponent();
        }

        public FormNuevaColeccion(FormPrincipal principal, int correlativoColeccion) {
            this.formPrincipal = principal;
            this.correlativoColeccion = correlativoColeccion;
            this.modificar = 1;
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Length!=0)
            {
                this.btnAceptar.Enabled = true;
            }
            else {
                this.btnAceptar.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Coleccion coleccion = new Coleccion(this.correlativoColeccion,this.txtNombre.Text, correlativoPadre, correlativoFlujo);
                
            if (modificar == 0)
            {                
                coleccion.crearColeccion();
            }
            else {
                coleccion.modificarNombre();
            }
            this.formPrincipal.refrescarDirectorio();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}