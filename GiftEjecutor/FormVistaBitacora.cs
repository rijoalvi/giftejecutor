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
    /// Ventana que permite la vista de la bit�cora
    /// </summary>
    public partial class FormVistaBitacora : Form
    {
        private Ventanota padreMDI;

        /// <summary>
        /// Constructor por omisi�n
        /// </summary>
        public FormVistaBitacora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que abre la bit�cora para un expediente espec�fico
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
            this.labelEncabezadoBitacora.Text = "Bit�cora del Expediente ''" + nomExpediente + "''";
            this.Text = "Bit�cora del Expediente ''" + nomExpediente + "''";
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