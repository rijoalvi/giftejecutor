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
        private Ventanota padreMDI;

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
            this.Text = "GIFT EJECUTOR - Cambiar nombre de la colección";
            this.label1.Text = "Digite el nuevo nombre de la colección";
            
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
            if (txtNombre.Text != null)
            {
                Coleccion coleccion = new Coleccion(this.correlativoColeccion, this.txtNombre.Text, correlativoPadre, correlativoFlujo);

                if (modificar == 0)//Si se esta creando la coleccion
                {
                    coleccion.crearColeccion();
                    if(this.padreMDI.getUsuario().getTipo()==2){//si el usuario es creador
                        this.padreMDI.getUsuario().getPerfil().asignarColeccion(coleccion.getCorrelativo());
                    }
                }
                else//si se esta modificando el nombre del expediente
                {
                    coleccion.modificarNombre();
                }
                this.formPrincipal.refrescarDirectorio();
                this.Close();
            }
            else {
                MessageBox.Show("Debe escribir un nombre para la colección");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }
    }
}