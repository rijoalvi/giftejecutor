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
        private Ventanota padreMDI;
        private Expediente miExpediente;

        public FormAsignarExpedientes()
        {
<<<<<<< .mine
            InitializeComponent();            
=======
            InitializeComponent();
>>>>>>> .r183
        }

        private void llenarComboUsuarios() {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = padreMDI.getUsuario().getTodosLosUsuarios();
            comboUsuarios.Items.Clear();
            for (int i = 0; i < usuarios.Count; i++)
            {
                comboUsuarios.Items.Add(usuarios[i]);
            }
        }

        /// <summary>
        /// Llena el comboBox de los expedientes posibles a asignar segun el usuario seleccionado.
        /// </summary>
        private void llenarComboExpedientes()
        {
            miExpediente = new Expediente("basura");
            List<Expediente> expedientes = new List<Expediente>();
            expedientes = miExpediente.getTodosLosExpedientes(((Usuario)(comboUsuarios.SelectedItem)).getCorrelativo());
            comboExpedientes.Items.Clear();
            comboExpedientes.Text = "";            
            for (int i = 0; i < expedientes.Count; i++)
            {
                comboExpedientes.Items.Add(expedientes[i]);
            }             
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            if (comboExpedientes.SelectedIndex == -1)
            {
                MessageBox.Show("¡Debe elegir un expediente!");
            }
            else
            {
                int idUsuario = ((Usuario)(comboUsuarios.SelectedItem)).getCorrelativo();
                int idExpediente = ((Expediente)(comboExpedientes.SelectedItem)).getCorrelativo();
                miExpediente.agregarAsignacion(idUsuario, idExpediente);
                MessageBox.Show("¡El expediente ha sido asignado!");
                comboExpedientes.SelectedIndex = -1;
            }
        }

        private void comboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComboExpedientes();
        }
<<<<<<< .mine

        private void FormAsignarExpedientes_Load(object sender, EventArgs e)
        {
            //llena el combo Box
            llenarComboUsuarios();
        }
=======

        private void FormAsignarExpedientes_Load(object sender, EventArgs e)
        {
            llenarComboUsuarios();
        }
>>>>>>> .r183
    }
}