using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormFlujosConstruidos : Form
    {
        int IDFlujoSeleccionado;
        FlujoTrabajo miFlujo;
                /************************/        
        FormPrincipal formPrincipal;
        int correlativoPadre;
        int correlativoFlujo;
        /***************************/

        public FormFlujosConstruidos(FormPrincipal principal,String correlativoPadre, String correlativoFlujo)
        {
            InitializeComponent();
            /****/
            this.formPrincipal = principal;
            this.correlativoPadre = int.Parse(correlativoPadre);
            this.correlativoFlujo = int.Parse(correlativoFlujo);
            //this.formPrincipal = principal;
            
            /////
            
            IDFlujoSeleccionado = -1;
            llenarDataGrid();
            
        }

        /// <summary>
        /// Llena el data grid con los datos de los flujos construidos
        /// </summary>
        private void llenarDataGrid() {
            /*miFlujo = new FlujoTrabajo(correlativoFlujo);
            //dataGridFlujos.DataSource = miFlujo.getFlujosConstruidos();
            dataGridFlujos.DataSource = miFlujo.getDataTableTodosLosFlujosDeTrabajo();
            //se esconde el ID para q el usuario no lo vea.
            dataGridFlujos.Columns[0].Visible = false;*/
        }

        private void dataGridFlujos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridFlujos.CurrentRow.Index;            
            IDFlujoSeleccionado = int.Parse(dataGridFlujos[0, fila].Value.ToString());
        }

        /************************/        

       /* private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Length!=0)
            {
                this.btnAceptar.Enabled = true;
            }
            else {
                this.btnAceptar.Enabled = false;
            }
        }*/

   /*     private void btnAceptar_Click(object sender, EventArgs e)
        {
            Coleccion coleccion = new Coleccion(this.txtNombre.Text,correlativoPadre);
            coleccion.crearColeccion();
            this.Close();
        }

        /**************************************************************************/

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void botonCrearExpediente_Click(object sender, EventArgs e)
        {
            Expediente expediente = new Expediente(txtNombre.Text, correlativoPadre,this.correlativoFlujo/*this.IDFlujoSeleccionado*/);
            expediente.crearExpediente();
            FormListadoActividad actividad = new FormListadoActividad(this.correlativoFlujo, expediente.getIDExpediente(), true);
            actividad.Show();
            this.formPrincipal.refrescarDirectorio();
            this.Close();
        }
    }
}