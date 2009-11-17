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
            this.llenarComboColecciones();
            this.actualizarTabControl();
        }
        public void llenarComboColecciones() {
            this.IDFlujoSeleccionado = ((FlujoTrabajo)(this.comboBoxFlujoTrabajo.SelectedItem)).getCorrelativo();

            Coleccion c = new Coleccion();
            c.setColeccionesDeUnFlujo(this.IDFlujoSeleccionado,this.perfil.getCorrelativo());
            comboBoxColecciones.Items.Clear();
            if (0 == c.coleccionesDeUnFlujo.Count)
            {
                MessageBox.Show("Flujo no tiene colecciones");
            }
            for (int i = 0; i < c.coleccionesDeUnFlujo.Count; i++)
            {
                comboBoxColecciones.Items.Add(c.coleccionesDeUnFlujo[i]);
            }        
        }

        private void buttonAsignarColeccion_Click(object sender, EventArgs e)
        {
            Coleccion coleccionSeleccionada = (((Coleccion)this.comboBoxColecciones.SelectedItem));
            this.asignarColeccion(coleccionSeleccionada);
            this.agregarColeccionATabControl(coleccionSeleccionada);

        }

        public void asignarColeccion(Coleccion coleccionAAsignar) {
            if (null != coleccionAAsignar)
            {
                this.perfil.asignarColeccion(coleccionAAsignar.getCorrelativo());
            }
            else {
                MessageBox.Show("Error");
            }
            this.llenarComboColecciones();//para que se actualize
        }
        public void agregarColeccionATabControl(Coleccion coleccionAAgregarAlPestanero)
        {


            if (null != coleccionAAgregarAlPestanero)
            {
                Actividad actividad = new Actividad();
                listActividadesDisponibles = new ListBox();
                listaListActividadesDisponibles.Add(listActividadesDisponibles);
                listActividadesDisponibles.SetBounds(20, 20, 170, 160);

                listActividadesPermitidasAlaColeccion = new ListBox();
                listaListActividadesPermitidasAlaColeccion.Add(listActividadesPermitidasAlaColeccion);
                listActividadesPermitidasAlaColeccion.SetBounds(260, 20, 170, 160);

                List<Actividad> listaActividades = actividad.getListaDataTableActividadesPorIDFlujo(this.IDFlujoSeleccionado);
                ColeccionAsignada coleccionAsignada = new ColeccionAsignada();
                coleccionAsignada.setDatosPorPerfilYColeccion(this.perfil.getCorrelativo(), coleccionAAgregarAlPestanero.getCorrelativo());
                List<Actividad> listaActividadesNoAsignadas = actividad.getListaDataTableActividadesNoPermitiasPorIDFlujo(this.IDFlujoSeleccionado, coleccionAsignada.correlativo);
                for (int i = 0; i < listaActividadesNoAsignadas.Count; i++)
                {
                    listActividadesDisponibles.Items.Add(listaActividadesNoAsignadas[i]);
                }
                //--------------------------------------------------------------
               // this.actualizarListaActividadPermitidas(coleccionAAgregarAlPestanero,this.tabColecciones.TabCount-1);




                // MessageBox.Show("IDColeccionAsignación: " + coleccionAsignada.correlativo);


                //************
                List<Actividad> lista = new List<Actividad>();
                Actividad ac = new Actividad();
                lista = ac.getListActividadesPermitidasPorColeccionAsignada(coleccionAsignada.correlativo);

                this.comboBoxPrueba.Items.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    //this.comboBoxPrueba.Items.Add(lista[i]);
                    listActividadesPermitidasAlaColeccion.Items.Add(lista[i]);
            //        listActividadesDisponibles.Items.Remove(lista[i]);
                }
                //******************
                //--------------------------------------------------------------
                //--------------------------------------------------------------


                //--------------------------------------------------------------


                //  Coleccion coleccionAAgregarAlPestanero = ((Coleccion)this.comboBoxColecciones.SelectedItem);
                // this.perfil.asignarColeccion(coleccionAAgregarAlPestanero.getCorrelativo());


                TabPage tabPage = new TabPage(coleccionAAgregarAlPestanero.getNombre());
                tabPage.Tag = coleccionAAgregarAlPestanero;

                Button buttonPermitirActividad = new Button();
                buttonPermitirActividad.Text = ">";
                buttonPermitirActividad.SetBounds(190, 70, 40, 40);
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
            else
            {
                MessageBox.Show("Favor seleccione una colección");
            }
        }
        public void actualizarListaActividadPermitidas(Coleccion coleccionPermitida,int index) {
            //--------------------------------------------------------------
            //--------------------------------------------------------------
            //Coleccion coleccionSeleccionada = coleccionAAgregarAlPestanero;
            ColeccionAsignada coleccionAsignada = new ColeccionAsignada();
            coleccionAsignada.setDatosPorPerfilYColeccion(this.perfil.getCorrelativo(), coleccionPermitida.getCorrelativo());


            // MessageBox.Show("IDColeccionAsignación: " + coleccionAsignada.correlativo);


            //************
            List<Actividad> lista = new List<Actividad>();
            Actividad ac = new Actividad();
            lista = ac.getListActividadesPermitidasPorColeccionAsignada(coleccionAsignada.correlativo);

           // this.comboBoxPrueba.Items.Clear();
            listaListActividadesPermitidasAlaColeccion[index].Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
             //   this.comboBoxPrueba.Items.Add(lista[i]);
                listaListActividadesPermitidasAlaColeccion[index].Items.Add(lista[i]);
            }
            //******************
            //--------------------------------------------------------------
            //--------------------------------------------------------------
        
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
                Actividad actividadSeleccionada = (Actividad)this.listaListActividadesDisponibles[indexTabSelected].SelectedItem;
           ////////     this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].Items.Add(actividadSeleccionada);
                this.listaListActividadesDisponibles[indexTabSelected].Items.Remove(actividadSeleccionada);

                Coleccion coleccionSeleccionada = ((Coleccion)this.tabColecciones.SelectedTab.Tag);
                ColeccionAsignada coleccionAsignada = new ColeccionAsignada();
                coleccionAsignada.setDatosPorPerfilYColeccion(this.perfil.getCorrelativo(), coleccionSeleccionada.getCorrelativo());



                /*
               MessageBox.Show("IDColeccionAsignación: " + coleccionAsignada.correlativo);


               //************
               List<Actividad> lista = new List<Actividad>();
               Actividad ac = new Actividad();
               lista = ac.getListActividadesPermitidasPorColeccionAsignada(coleccionAsignada.correlativo);

               this.comboBoxPrueba.Items.Clear();
               for (int i = 0; i < lista.Count; i++)
               {
                   this.comboBoxPrueba.Items.Add(lista[i]);
               }
               //******************
               //--------------------------------*/


                coleccionAsignada.permitirActividad(actividadSeleccionada.getID());
                this.actualizarListaActividadPermitidas(coleccionSeleccionada,this.tabColecciones.SelectedIndex);
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

                Actividad actividadSeleccionada = (Actividad)this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].SelectedItem;
                this.listaListActividadesDisponibles[indexTabSelected].Items.Add(this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].SelectedItem);
                this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].Items.Remove(this.listaListActividadesPermitidasAlaColeccion[indexTabSelected].SelectedItem);


                Coleccion coleccionSeleccionada = ((Coleccion)this.tabColecciones.SelectedTab.Tag);
                ColeccionAsignada coleccionAsignada = new ColeccionAsignada();
                coleccionAsignada.setDatosPorPerfilYColeccion(this.perfil.getCorrelativo(), coleccionSeleccionada.getCorrelativo());
                coleccionAsignada.despermitirActividad(actividadSeleccionada.getID());
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

          //  listaListActividadesDisponibles.RemoveAt(this.tabColecciones.SelectedIndex);
          //  listaListActividadesPermitidasAlaColeccion.RemoveAt(this.tabColecciones.SelectedIndex);

            this.perfil.desasignarColeccion(((Coleccion)tabSeleccionada.Tag).getCorrelativo());

            MessageBox.Show("Colección desasignada: "+( (Coleccion)tabSeleccionada.Tag).toString());
            this.actualizarTabControl();
            this.llenarComboColecciones();
        }


        public void actualizarTabControl() {
            Coleccion c = new Coleccion();
            this.tabColecciones.TabPages.Clear();
            this.listaListActividadesPermitidasAlaColeccion.Clear();
            this.listaListActividadesDisponibles.Clear();
            List<Coleccion> coleccionAsignadas = c.getListTodasColeccionesAsignadasDeUnFlujoDeUnPerfil(this.IDFlujoSeleccionado, this.perfil.getCorrelativo());

            for (int i = 0; i < coleccionAsignadas.Count; i++)
            {
                this.agregarColeccionATabControl(coleccionAsignadas[i]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}