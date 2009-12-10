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
    /// Ventana que permite la vista de la bitácora
    /// </summary>
    public partial class FormVistaBitacora : Form
    {
        private Ventanota padreMDI;

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public FormVistaBitacora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que abre la bitácora para un expediente específico
        /// </summary>
        /// <param name="IDExpediente"></param>
        public FormVistaBitacora(int IDExpediente)
        {
            InitializeComponent();
            Controlador c;
            c = new Controlador();
            this.dataGridElementosBitacora.DataSource = c.getDataTableBitacora(IDExpediente);
            dataGridElementosBitacora.Refresh();
            ConsultaExpediente consulta;
            consulta = new ConsultaExpediente();
            String nomExpediente = consulta.buscarNombreExpediente(IDExpediente);
            this.labelEncabezadoBitacora.Text = "Bitácora del Expediente ''" + nomExpediente + "''";
            this.Text = "Bitácora del Expediente ''" + nomExpediente + "''";
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Asigna el padreMDI
        /// </summary>
        /// <param name="v"></param>
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

    }
}