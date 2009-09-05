using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormActividad : Form
    {
        public FormActividad()
        {
            InitializeComponent();
        }

        private void FormActividad_Load(object sender, EventArgs e)
        {
            Actividad actividadPrueba = new Actividad();
            label1.Text = actividadPrueba.getComandoPrueba().ToString();
            this.cargarDataGridComandos();
        }
        private void cargarDataGridComandos() { 
            Actividad actividadPrueba = new Actividad();
            this.dataGridComandos.DataSource = actividadPrueba.getDataTableConComandosDeLaActividad();
            dataGridComandos.Refresh();
        }
    }
}