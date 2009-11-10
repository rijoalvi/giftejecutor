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
        private int IDFlujoSeleccionado;
        public FormDetallesPerfil()
        {
            InitializeComponent();
        }
        public FormDetallesPerfil(int IDPerfil)
        {
            InitializeComponent();
            perfil = new Perfil();
            perfil.setDatosPorID(IDPerfil);
            this.textBoxNombre.Text = perfil.getNombre();
            this.textBoxTipo.Text = perfil.getTipo();
        }
        private void buttonAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormAsignarColeccion fac = new FormAsignarColeccion();
            fac.Show();
        }

        private void FormDetallesPerfil_Load(object sender, EventArgs e)
        {
            /*Perfil p = new Perfil();
    
            for (int i = 0; i < p.perfiles.Count; i++)
            {
                comboBox1.Items.Add(p.perfiles[i]);
            }*/

            FlujoTrabajo f = new FlujoTrabajo();
            for (int i = 0; i < f.flujosTrabajo.Count; i++)
            {
                comboBoxFlujoTrabajo.Items.Add(f.flujosTrabajo[i]);
            }

        }

        private void comboBoxFlujoTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(((FlujoTrabajo)(this.comboBoxFlujoTrabajo.SelectedItem)).getCorrelativo().ToString());
            this.IDFlujoSeleccionado = ((FlujoTrabajo)(this.comboBoxFlujoTrabajo.SelectedItem)).getCorrelativo();

            Coleccion c = new Coleccion();
            c.setColeccionesDeUnFlujo(this.IDFlujoSeleccionado);
            comboBoxColecciones.Items.Clear();
            if (0==c.coleccionesDeUnFlujo.Count){
                MessageBox.Show("Flujo no tiene colecciones");
            }
            for (int i = 0; i < c.coleccionesDeUnFlujo.Count; i++)
            {
                comboBoxColecciones.Items.Add(c.coleccionesDeUnFlujo[i]);
            }
        }

        private void buttonAsignarColeccion_Click(object sender, EventArgs e)
        {
            // tabPage=;
            if (null != this.comboBoxColecciones.SelectedItem)
            {
                Actividad a= new Actividad();
                DataGridView dg = new DataGridView();
                dg.Width = 400;
                dg.DataSource = a.getDataTableActividadesPorIDFlujo(this.IDFlujoSeleccionado);
                TabPage tabPage = new TabPage(((Coleccion)this.comboBoxColecciones.SelectedItem).getNombre());
                tabPage.Controls.Add(dg);
                this.tabColecciones.Controls.Add(tabPage);
            }
            else {
                MessageBox.Show("Favor seleccione una colección");
            }

        }
    }
}