using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormVistaBitacora : Form
    {
        public FormVistaBitacora()
        {
            InitializeComponent();
        }

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

    }
}