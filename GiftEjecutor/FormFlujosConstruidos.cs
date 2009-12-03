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
        int modificar;
        int correlativoExpediente;
        /***************************/
        private Ventanota padreMDI;

        public FormFlujosConstruidos(FormPrincipal principal,String correlativoPadre, String correlativoFlujo)
        {
            InitializeComponent();
            /****/
            this.formPrincipal = principal;
            this.correlativoPadre = int.Parse(correlativoPadre);
            this.correlativoFlujo = int.Parse(correlativoFlujo);
            //this.formPrincipal = principal;
            modificar = 0;            
            /////            
            IDFlujoSeleccionado = -1;
            llenarDataGrid();
            this.txtNombre.Focus();
        }

        /// <summary>
        /// Constructor que inicializa el Form para que se modifique nombre del expediente creado
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="correlativoExpediente"></param>
        public FormFlujosConstruidos(FormPrincipal principal, String correlativoExpediente,String correlativoPadre, String correlativoFlujo)
        {
            InitializeComponent();
            /****/
            this.formPrincipal = principal;
            this.correlativoExpediente = int.Parse(correlativoExpediente);
            this.correlativoPadre = int.Parse(correlativoPadre);
            this.correlativoFlujo = int.Parse(correlativoFlujo);
          
            modificar = 1;
            this.Text = "GIFT EJECUTOR - Cambiar nombre del expediente";
            this.label2.Text = "Digite el nuevo nombre del expediente";
            IDFlujoSeleccionado = -1;
            llenarDataGrid();
            this.txtNombre.Focus();
        }
        /// <summary>
        /// Llena el data grid con los datos de los flujos construidos
        /// </summary>
        private void llenarDataGrid() {
            miFlujo = new FlujoTrabajo(correlativoFlujo);
            //dataGridFlujos.DataSource = miFlujo.getFlujosConstruidos();
            dataGridFlujos.DataSource = miFlujo.getFlujoTrabajo(correlativoFlujo);
            //se esconde el ID para q el usuario no lo vea.
            //dataGridFlujos.Columns[0].Visible = false;
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
            Boolean refrescar=true;
            if (txtNombre.Text != null)
            {
                if (this.modificar == 0)
                {
                    Expediente expediente = new Expediente(txtNombre.Text, correlativoPadre, this.correlativoFlujo/*this.IDFlujoSeleccionado*/);            
                    expediente.crearExpediente();
                    if (this.padreMDI.getUsuario().getTipo() == 2)
                    {//si es un creador
                        this.padreMDI.getUsuario().asignarExpediente(expediente.getCorrelativo());
                        this.padreMDI.getUsuario().actualizarIdsExpedientes();
                    }
                    FormManual manual = new FormManual(expediente.getCorrelativo());
                    manual.Show();
                    manual.TopMost=true;
                    manual.StartPosition = FormStartPosition.CenterScreen;
                    FormListadoActividad actividad = new FormListadoActividad(padreMDI.getUsuario(),this.correlativoFlujo, expediente.getIDExpediente(), true,null);
                    actividad.MdiParent = padreMDI;
                    actividad.setPadreMDI(padreMDI);
                    if (!actividad.IsDisposed)
                    {
                        actividad.Show();
                    }
                    this.formPrincipal.refrescarDirectorio();
                
                
                    //else { refrescar = false; }
                }
                else
                {
                    Expediente expediente = new Expediente(txtNombre.Text, this.correlativoExpediente);
                    expediente.modificarNombre();
                }
                this.Close();
            }
            else {
                MessageBox.Show("Debe escribir un nombre para el expediente");
            }

            this.Dispose();
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }
    }
}