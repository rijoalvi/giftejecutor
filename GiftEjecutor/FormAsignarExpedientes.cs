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
        private Usuario usuarioActual;
        private Expediente miExpediente;

        public FormAsignarExpedientes(Usuario user)
        {
            InitializeComponent();
            usuarioActual = user;
            llenarComboUsuarios();
        }

        private void llenarComboUsuarios() {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = usuarioActual.getTodosLosUsuarios();
            comboUsuarios.Items.Clear();
            for (int i = 0; i < usuarios.Count; i++)
            {
                comboUsuarios.Items.Add(usuarios[i]);
            }
        }


        private void llenarComboExpedientes()
        {            
            /*
            miExpediente = new Expediente("basura");
            List<Expediente> expedientes = new List<Expediente>();
            expedientes = miExpediente.listarExpedientes();
            comboExpedientes.Items.Clear();
            for (int i = 0; i < expedientes.Count; i++)
            {
                comboExpedientes.Items.Add(expedientes[i]);
            }
            */ 
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

        }

        private void comboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComboExpedientes();
        }
    }
}