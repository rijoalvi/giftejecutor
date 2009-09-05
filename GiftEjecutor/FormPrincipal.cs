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
        /**
         * Para recordar!!!
         * //Son los macros que se usan para seleccion del combo box.
         * static final int NUMERO = 1;
         * static final int BINARIO = 2;
         * static final int FECHAHORA = 3;
         * static final int TEXTO = 4;
         * static final int INCREMENTAL = 5;         
         * static final int JERARQUIA = 6
         * static final int LISTA = 7;
         */

        public FormPrincipal()
        {
            InitializeComponent();
        }
        public FormPrincipal(int conexionSeleccionada)
        {
            ControladorBD.conexionSelecciona = conexionSeleccionada;

            //ControladorBD.conexionConfiguracionSeleccionada = conexionConfiguradorSeleccionada;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConstructorTablasFormularios tmp = new ConstructorTablasFormularios();
            tmp.construirTablas("1");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            //FormFormulario formFormulario = new FormFormulario(1);
            Formulario miForm = new Formulario(1);
            miForm.getMiembro(1);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormActividad formActividad = new FormActividad();
            formActividad.Show();
        }
    }
}