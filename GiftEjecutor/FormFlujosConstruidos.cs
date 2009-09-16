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


        public FormFlujosConstruidos()
        {
            InitializeComponent();
            IDFlujoSeleccionado = -1;
            llenarDataGrid();
        }

        /// <summary>
        /// Llena el data grid con los datos de los flujos construidos
        /// </summary>
        private void llenarDataGrid() {
            miFlujo = new FlujoTrabajo();
            dataGridFlujos.DataSource = miFlujo.getFlujosConstruidos();
            //se esconde el ID para q el usuario no lo vea.
            dataGridFlujos.Columns[0].Visible = false;
        }

        private void dataGridFlujos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridFlujos.CurrentRow.Index;
            IDFlujoSeleccionado = int.Parse(dataGridFlujos[fila, 0].Value.ToString());
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}