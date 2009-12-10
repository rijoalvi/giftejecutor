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
    /// Ventana que permita la creación de nuevos expedientes
    /// </summary>
    public partial class FormNuevoExpediente : Form
    {
        private Ventanota padreMDI;
        Form formPrincipal;
        int correlativoColeccion;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="correlativoColeccion"></param>
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
            Expediente expediente = new Expediente(this.txtNombre.Text,correlativoColeccion,0);
            expediente.crearExpediente();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Asigna el padre MDI
        /// </summary>
        /// <param name="v"></param>
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }
    }
}