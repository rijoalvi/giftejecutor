using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormEliminar : Form
    {
        Expediente expediente;
        Coleccion coleccion;
        FormPrincipal principal;
        private Ventanota padreMDI;

        public FormEliminar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El tipo indica si es un expediente o una coleccion /////***No se xq no me deja mandar un Expediente o una Coleccion de parametro... si alguien sabe que me diga...**/
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="correlativo"></param>
        /// <param name="tipo"></param>
        public FormEliminar(FormPrincipal form, String nombre, String correlativo, String tipo) {
            InitializeComponent();
            principal = form;
            if (tipo.Equals("Expediente"))
            {
                this.expediente = new Expediente(nombre, int.Parse(correlativo));
                this.coleccion = null;
                this.Text = "GIFT EJECUTOR - Eliminar Expediente";
                this.label1.Text = "Está por eliminar el expediente \"" + expediente.getNombre() + "\". Esta acción no es revertible.\nRealmente desea eliminarlo?";
            }
            else if (tipo.Equals("Coleccion"))
            {
                MessageBox.Show("Esta sección se encuentra bajo contrucción.... Disculpe los inconvenientes");
                /*this.coleccion = new Coleccion(int.Parse(correlativo),nombre,0,0);
                this.expediente= null;
                this.Text = "GIFT EJECUTOR - Eliminar Colección";
                this.label1.Text = "Esta por eliminar la coleccion" + expediente.getNombre() + '\n' + ". Desea continuar?";*/
            }
            
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }


        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (expediente != null) {
                expediente.eliminar();
                principal.refrescarDirectorio();
                MessageBox.Show("Se ha eliminado el expediente "+expediente.getNombre());

            }
            else if (coleccion != null) { 
                
            }
            this.Dispose();
        }

        

    }
}