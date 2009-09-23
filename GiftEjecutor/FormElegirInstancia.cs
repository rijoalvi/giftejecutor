using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormElegirInstancia : Form
    {
        private bool instanciaElegida;
        private int IDTupla;

        public FormElegirInstancia()
        {
            InitializeComponent();
            instanciaElegida = false;
        }

        public bool isInstanciaElegida() {
            return instanciaElegida;
        }

        public int getIDTupla() {
            return IDTupla;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            instanciaElegida = true;
            this.Dispose();
        }

        private void botonEjecutar_Click(object sender, EventArgs e)
        {
            instanciaElegida = true;
            //IDTupla = 
            this.Hide();
        }
    }
}