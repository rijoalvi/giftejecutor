using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormNuevoExpediente : Form
    {
        Form formPrincipal;
        int correlativoColeccion;
        public FormNuevoExpediente(Form principal, String correlativoColeccion)
        {
            this.correlativoColeccion = int.Parse(correlativoColeccion);
            this.formPrincipal = principal;
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
            Expediente expediente = new Expediente(this.txtNombre.Text,correlativoColeccion);
            expediente.crearExpediente();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}