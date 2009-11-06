using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormDetallesPerfil : Form
    {
        private Perfil perfil;
        public FormDetallesPerfil()
        {
            InitializeComponent();
        }
        public FormDetallesPerfil(int IDPerfil)
        {
            InitializeComponent();
            perfil = new Perfil();
            perfil.setDatosPorID(IDPerfil);
            this.textBoxNombre.Text = perfil.nombre;
            this.textBoxTipo.Text = perfil.tipo;
        }
        private void buttonAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormAsignarColeccion fac = new FormAsignarColeccion();
            fac.Show();
        }

        private void FormDetallesPerfil_Load(object sender, EventArgs e)
        {
            Perfil p = new Perfil();
            //List < Perfil >lista;
            //lista= p.getListTodosPerfiles();
            for (int i = 0; i < p.perfiles.Count; i++)
            {
                comboBox1.Items.Add(p.perfiles[i]);
            }
            
        }
    }
}