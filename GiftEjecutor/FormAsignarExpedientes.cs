using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormAsignarExpedientes : Form
    {

        Usuario miUsuario;
        Expediente miExpediente;

        public FormAsignarExpedientes()
        {
            InitializeComponent();
            llenarComboUsuarios();
        }

        private void llenarComboUsuarios() { 
            
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}