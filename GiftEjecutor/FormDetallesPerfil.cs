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
        public ListBox listActividadesDisponibles;
        public ListBox listActividadesPermitidasAlaColeccion;

        public List<ListBox> listaListActividadesDisponibles;
        public List<ListBox> listaListActividadesPermitidasAlaColeccion;
        public FormDetallesPerfil()
        {
            InitializeComponent();
        }
        public FormDetallesPerfil(int IDPerfil)
        {
            listaListActividadesDisponibles = new List<ListBox>();
            listaListActividadesPermitidasAlaColeccion = new List<ListBox>();
            InitializeComponent();
            perfil = new Perfil();
            perfil.setDatosPorID(IDPerfil);
            this.textBoxNombre.Text = perfil.getNombre();
            this.textBoxTipo.Text = perfil.getTipo();
            if (this.textBoxTipo.Text.ToString().Equals("Administrador"))
            {
                this.groupBoxAsignarColecciones.Visible = false;
                this.ColleccionesAsignadas.Visible = false;
                this.comboBoxFlujoTrabajo.Visible = false;
                this.labelFlujo.Visible = false;
                
                this.labelMensaje.Text = "Administrador tiene derechos sobre todo.";
                
            }
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
            //this.comboBoxFlujoTrabajo
        }

        private void buttonAsignarColeccion_Click(object sender, EventArgs e)
        {
            // tabPage=;
            if (null != this.comboBoxColecciones.SelectedItem)
            {
                Actividad actividad= new Actividad();
             //   DataGridView dg = new DataGridView();
                listActividadesDisponibles = new ListBox();
                listaListActividadesDisponibles.Add(listActividadesDisponibles);
                listActividadesDisponibles.SetBounds(20, 20, 170, 160);

                listActividadesPermitidasAlaColeccion = new ListBox();
                listaListActividadesPermitidasAlaColeccion.Add(listActividadesPermitidasAlaColeccion);
                listActividadesPermitidasAlaColeccion.SetBounds(260, 20, 170, 160);

                List<Actividad> listaActividades= actividad.getListaDataTableActividadesPorIDFlujo(this.IDFlujoSeleccionado);
                for (int i = 0; i < listaActividades.Count; i++ )
                {
                    listActividadesDisponibles.Items.Add(listaActividades[i]);
                }

               // dg.Width = 600;//getDataTableActividadesPorIDFlujoParaAsignaciones
               // dg.DataSource = actividad.getDataTableActividadesPorIDFlujo(this.IDFlujoSeleccionado);
                //dg.DataSource = actividad.getDataTableActividadesPorIDFlujoParaAsignaciones(this.IDFlujoSeleccionado);
              //  dg.Columns[0].Visible = false;//para ocultar ID
                Coleccion coleccionSeleccionada=((Coleccion)this.comboBoxColecciones.SelectedItem);
                this.perfil.asignarColeccion(coleccionSeleccionada.getCorrelativo());

                TabPage tabPage = new TabPage(coleccionSeleccionada.getNombre());
                tabPage.Tag = coleccionSeleccionada;

                Button buttonPermitirActividad = new Button();
                buttonPermitirActividad.Text = ">";
                buttonPermitirActividad.SetBounds(190, 70, 40,40);
                buttonPermitirActividad.Click += new System.EventHandler(click_PermitirActividad);
                //this.comboBoxFlujoTrabajo.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlujoTrabajo_SelectedIndexChanged);



                Button buttonDespermitirActividad = new Button();
                buttonDespermitirActividad.SetBounds(190, 120, 40, 40);
                buttonDespermitirActividad.Click += new System.EventHandler(click_DespermitirActividad);


                buttonDespermitirActividad.Text = "<";
                tabPage.Controls.Add(buttonPermitirActividad);
                tabPage.Controls.Add(buttonDespermitirActividad);


                tabPage.Controls.Add(listActividadesDisponibles);
                tabPage.Controls.Add(listActividadesPermitidasAlaColeccion);
                this.tabColecciones.Controls.Add(tabPage);

                
            }
            else {
                MessageBox.Show("Favor seleccione una colección");
            }

        }
        public void click_PermitirActividad(object sender, EventArgs e)
        {
           /* if (null != this.listActividadesDisponibles.SelectedItem)
            {
                this.listActividadesPermitidasAlaColeccion.Items.Add(this.listActividadesDisponibles.SelectedItem);
                this.listActividadesDisponibles.Items.Remove(this.listActividadesDisponibles.SelectedItem);
            }
            else {
                MessageBox.Show("Seleccione una actividad ");
            }*/
            //this.listActividadesDisponibles.SelectedItem

            int indexTabSelected=this.tabColecciones.SelectedIndex;
            if (null != this.listaListActividadesDisponibles[indexTabSelected].SelectedItem)
            {
                this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].Items.Add(this.listaListActividadesDisponibles[indexTabSelected].SelectedItem);
                this.listaListActividadesDisponibles[indexTabSelected].Items.Remove(this.listaListActividadesDisponibles[indexTabSelected].SelectedItem);
            }
            else
            {
                MessageBox.Show("Seleccione una actividad ");
            }


        }
        public void click_DespermitirActividad(object sender, EventArgs e)
        {
            int indexTabSelected = this.tabColecciones.SelectedIndex;
            if (null != this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].SelectedItem)
            {
                this.listaListActividadesDisponibles[indexTabSelected].Items.Add(this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].SelectedItem);
                this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].Items.Remove(this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].SelectedItem);
            }
            else
            {
                MessageBox.Show("Seleccione una actividad");
            }
            //this.listActividadesDisponibles.SelectedItem
        }

        private void buttonEliminarPerfil_Click(object sender, EventArgs e)
        {
            TabPage tabSeleccionada = this.tabColecciones.SelectedTab;
            MessageBox.Show("Colección seleccionada: "+( (Coleccion)tabSeleccionada.Tag).toString());
        }
    }
}