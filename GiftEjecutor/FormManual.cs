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
    /// Ventana que permite la elección sobre la forma de asignar actividades para el expediente
    /// </summary>
    public partial class FormManual : Form
    {

        int idExp;

        /// <summary>
        /// Constructor que recibe el ID del expediente
        /// </summary>
        /// <param name="idExpediente"></param>
        public FormManual(int idExpediente)
        {
            idExp = idExpediente;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaExpediente consulta = new ConsultaExpediente();
            consulta.setManual(true,idExp);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultaExpediente consulta = new ConsultaExpediente();
            consulta.setManual(false,idExp);
            this.Dispose();
        }

    }
}