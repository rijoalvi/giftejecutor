using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormConstructor : Form
    {
        public FormConstructor()
        {
            InitializeComponent();
        }

        private void FormConstructor_Load(object sender, EventArgs e)
        {
            FlujoTrabajo flujo = new FlujoTrabajo();
            dataGridFlujosTrabajo.DataSource = flujo.getDataTableTodosLosFlujosDeTrabajo();
        }
    }
}