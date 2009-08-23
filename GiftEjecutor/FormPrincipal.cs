using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        public FormPrincipal(int conexionSeleccionada)
        {
            ControladorBD.conexionSelecciona = conexionSeleccionada;
            InitializeComponent();
        }
        private void constructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConstructor constructor = new FormConstructor();
            constructor.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}