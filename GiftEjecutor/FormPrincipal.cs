using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace GiftEjecutor
{
    /// <summary>
    /// Ventana principal que muestra la interfaz inicial luego se ingresar un usuario
    /// </summary>
    public partial class FormPrincipal : Form
    {
        private Ventanota padreMDI;
        private int IDExpediente;
        private String[] IDsFormularios;
        private FormFormulario formCaratula;
        private Usuario usuarioActual;
        private Inbox inbox;
        public Boolean manual;
        //private ArbolGift arbol;
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
        
        /// <summary>
        /// constructor que le indica la conecci�n a la base de datos y el usuario
        /// </summary>
        /// <param name="conexionSeleccionada">La coneccion a utilizar, ECCI o USA</param>
        public FormPrincipal(int conexionSeleccionada, int idUsuario)
        {
           //ControladorBD.conexionSelecciona = conexionSeleccionada;

            //ControladorBD.conexionConfiguracionSeleccionada = conexionConfiguradorSeleccionada;
            InitializeComponent();
            labelFormulariosCreados.Hide();
            listaFormularios.Hide();
            usuarioActual = new Usuario(idUsuario);
            esconderLabels();
            this.arbol = new ArbolGift(directorio, usuarioActual);
            this.Text = "GIFT Ejecutor - " + usuarioActual.getNombre() + " ("+this.usuarioActual.getPerfil().getNombre()+")";         
        }

        /// <summary>
        /// refresca el arbol
        /// </summary>
        public void refrescarDirectorio() {
            arbol.refrescar();            
        }

        private void constructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConstructor constructor = new FormConstructor();
            constructor.MdiParent = padreMDI;
            constructor.setPadreMDI(padreMDI);
            constructor.Show();
        }
        
        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            refrescarDirectorio();//este comente a veces, luisk
            revisarAdmin();
            mostrarInbox();
        }

        /// <summary>
        /// Revisa si el usuario es admin, de lo contrario bloquea el menu de los m�dulos
        /// </summary>
        private void revisarAdmin()
        {
            //si NO es admin
            if (usuarioActual.getTipo() != 0) {
                m�dulosToolStripMenuItem.Visible = false;
            }
        }

        private void buttonActividad_Click(object sender, EventArgs e)
        {
            int IDExpediente = 13;
            int IDFlujo = 4;
            FormListadoActividad formListadoActividad = new FormListadoActividad(padreMDI.getUsuario(),IDFlujo, IDExpediente, true, null);
            formListadoActividad.MdiParent = padreMDI;
            formListadoActividad.setPadreMDI(padreMDI);
            formListadoActividad.Show();
        }

        private void agregarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.usuarioActual.getTipo()==0 || this.usuarioActual.getTipo()==2){//si es administrador o creador
                if (arbol.hayNodoSeleccionado())
                {
                    Coleccion coleccion = arbol.coleccionSeleccionada(); 
                    if (coleccion == null) { 
                        MessageBox.Show("Solo se pueden crear expedientes dentro de una coleccion");
                    }
                    else
                    {
                        String correlativoPadre = coleccion.getCorrelativo().ToString();// arbol.nodoSeleccionado().Name;
                        String correlativoFlujo = coleccion.getCorrelativoFlujo().ToString();// ((Coleccion)arbol.nodoSeleccionado().Tag).getCorrelativoFlujo().ToString();
                        FormFlujosConstruidos flujosConstruidos = new FormFlujosConstruidos(this, correlativoPadre, correlativoFlujo);
                        flujosConstruidos.MdiParent = padreMDI;
                        flujosConstruidos.setPadreMDI(padreMDI);
                        flujosConstruidos.Show();                        
                    }
                }
                else
                {
                    MessageBox.Show("Se debe seleccionar la colecci�n en la que se crear� la colecci�n en el directorio");
                }
            }else{
                MessageBox.Show("Es necesario ser un usuario de tipo administrador o creador para llvar a cabo esta operaci�n");
            }
        }

        private void agregarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuarioActual.getTipo() == 0 || usuarioActual.getTipo() == 2)
            {
                if (this.arbol.hayNodoSeleccionado())
                {
                    String correlativoFlujo;
                    String correlativoPadre;
                    FlujoTrabajo flujo = this.arbol.flujoSeleccionado();
                    if (flujo != null)
                    {
                        correlativoFlujo = flujo.getCorrelativo().ToString();// arbol.nodoSeleccionado().Name.Substring(1);
                        correlativoPadre = "0"; //Tiene correlativo en 0 pues se encuentra en la ra�z del flujo
                        FormNuevaColeccion c = new FormNuevaColeccion(this, correlativoPadre, correlativoFlujo);
                        c.MdiParent = padreMDI;
                        c.setPadreMDI(padreMDI);
                        c.Show();
                    }
                    else
                    {
                        Coleccion coleccion = arbol.coleccionSeleccionada();
                        if (coleccion != null)   //if (!this.arbol.nodoSeleccionado().Name.Contains("E") && !this.arbol.nodoSeleccionado().Name.Equals("0"))
                        {
                            correlativoFlujo = coleccion.getCorrelativoFlujo().ToString(); //((Coleccion)arbol.nodoSeleccionado().Tag).getCorrelativoFlujo().ToString();
                            correlativoPadre = coleccion.getCorrelativo().ToString();      //arbol.nodoSeleccionado().Name;
                            FormNuevaColeccion c = new FormNuevaColeccion(this, correlativoPadre, correlativoFlujo);
                            c.MdiParent = padreMDI;
                            c.setPadreMDI(padreMDI);
                            c.Show();
                        }
                        else
                        {
                            MessageBox.Show("Solo es posible crear Colecciones dentro de un Flujo de trabajo o dentro de otra Colecci�n");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Se debe seleccionar el Flujo de trabajos o la colecci�n en la que se crear� la colecci�n en el directorio");
                }
            }
            else {
                MessageBox.Show("Se necesitan permisos de administrador o creador para realizar esta acci�n");
            }
        }

        private void directorio_DoubleClick(object sender, EventArgs e)
        {
            abrirExpediente();
        }

        private void abrirExpediente()
        {
            Expediente expediente = arbol.expedienteSeleccionado();
            //TreeNode seleccionado = arbol.nodoSeleccionado();
            if (expediente != null && expediente.yaFinalizado() != 1)
            {
                //MessageBox.Show("Se selecciono el Expediente " + arbol.nodoSeleccionado().Name+" "+arbol.nodoSeleccionado().Text);

                int correlativoFlujo = expediente.getIDFlujo();
                //MessageBox.Show("Correlativo Flujo" + correlativoFlujo);
                int correlativoExpediente = expediente.getCorrelativo();
                //MessageBox.Show("correlativo expediente " + correlativoExpediente);
                FormListadoActividad actividad = new FormListadoActividad(padreMDI.getUsuario(),correlativoFlujo, correlativoExpediente, true,null);
                actividad.MdiParent = padreMDI;
                actividad.setPadreMDI(padreMDI);
                actividad.Show();
            }else if(expediente!=null && expediente.yaFinalizado()== 1){
                MessageBox.Show("El expediente seleccionado ya fue finalizado");
            }

        }
        
        /// <summary>
        /// Asigna el padre MDI
        /// </summary>
        /// <param name="v"></param>
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
            ponerUsuarioEnVentanota();
        }

        /// <summary>
        /// Agrega el usuario a la ventana de fondo, para que lo utilicen las dem�s ventanas
        /// </summary>
        public void ponerUsuarioEnVentanota()
        {
            padreMDI.setUsuario(this.usuarioActual);
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }         

        //ESTO ES PARA VER LA BITACORA
        private void verBitacora()
        {
            FormVistaBitacora bit = new FormVistaBitacora(999);
            bit.MdiParent = padreMDI;
            bit.Show();
        }

        /// <summary>
        /// M�todo que llena los datos de ejecuci�n de un expediente, contenidos dentro del panel "panelEjecutorial"
        /// </summary>
        /// <param name="IDExpediente"></param>
        private void llenarDatosEjecucionExpediente(int IDExpediente, int IDFlujo)
        {
            esconderLabels();
            //TreeNode seleccionado = arbol.nodoSeleccionado();
            //labelDetalleEjecutorial.Text = "Estado de Ejecuci�n del Expediente " + seleccionado.Text;
            
            Controlador c = new Controlador();

            //Llenar un DataGrid para mostrar la bitacoraza

            //this.dataGridDetallesEjecucion.DataSource = c.getDataTableBitacora(IDExpediente);
            Actividad act = new Actividad();
            labelRealizadas.Text = act.getSecuenciaActRealizadas(IDExpediente, IDFlujo);
            labelEnCurso.Text = act.getActividadActual(IDExpediente, IDFlujo);
            labelPorRealizar.Text = act.getSecuenciaActPorRealizar(IDExpediente, IDFlujo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TreeNode seleccionado = arbol.nodoSeleccionado();
            Expediente expediente = arbol.expedienteSeleccionado();
            if (expediente != null && expediente.yaFinalizado() != 1)
            {
                int Flujo = expediente.getIDFlujo();
                int Expediente = expediente.getCorrelativo();
                llenarDatosEjecucionExpediente(Expediente, Flujo);
            }
        }

        private void directorio_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.arbol.cargarNodo();
            mostrarVistaPrevia();            
        }

        private void mostrarVistaPrevia()
        {
            //Aqui se tiene que cargar los detalles del expediente, si el nodo seleccionado es 1 expediente.
            //   indiceFormularios = 0; //NO BORRAR! Beto
			panelInbox.Hide();            
            Expediente expediente = arbol.expedienteSeleccionado();
            if (expediente != null)
            {
                //MessageBox.Show("Soy Expediente!!!");
                int Flujo = expediente.getIDFlujo();
                int Expediente = expediente.getCorrelativo();

                llenarDatosEjecucionExpediente(Expediente, Flujo);

                //se obtienen los datos de los formularios
                labelTituloExp.Show();
                labelTituloExp.Text = "Expediente " + expediente.getNombre();

                //obtiene los datos de todos los formularios del expediente
                int correlativoFlujo = expediente.getIDFlujo();
                IDExpediente = expediente.getCorrelativo();
                ConstructorTablasFormularios misFormularios = new ConstructorTablasFormularios();
                IDsFormularios = misFormularios.buscarFormularios(correlativoFlujo);
                int idFormCaratula = misFormularios.getIDCaratula(correlativoFlujo);
                //muestra el formulario caratula
                mostrarFormulario(0, idFormCaratula);
            }
            else
            {
                //MessageBox.Show("No soy expediente =(");
                esconderLabels();
            }
        }

        private void mostrarFormulario(int index, int idFormCaratula)
        {
            esconderLabels();
            panelDetalleActividades.Show();
            pictureBoxInbox.Image = GiftEjecutor.Properties.Resources.Pesta�aNoInvertidaInbox;
            pictureBoxVistaPrevia.Image = GiftEjecutor.Properties.Resources.Pesta�aInvertidaPrevia;
            if (formCaratula != null)
                formCaratula.Dispose();
            //Se abre el form correspondiente    
            Formulario elFormulario;
            if (index == 0)
            {
                elFormulario = new Formulario(idFormCaratula);
            }
            else             
            {
                elFormulario = new Formulario(int.Parse(IDsFormularios[index]));            
            }
            int IDTupla = elFormulario.getIDDeLaTupla(this.IDExpediente);
            if (IDTupla == -1)
            {
                labelAviso.Show();
            }
            else
            {
                labelTituloExp.Text = "Expediente " + this.arbol.expedienteSeleccionado().getNombre();
                labelTituloExp.Show();
                FormFormulario formEsteFormulario = new FormFormulario(elFormulario.getID(), this.IDExpediente, -1, IDTupla, 6, -1, "", null, -1);
                formEsteFormulario.TopMost = true;
                formEsteFormulario.MdiParent = this;
                formEsteFormulario.StartPosition = FormStartPosition.Manual;
                formEsteFormulario.Location = new Point(256, 125);
                formEsteFormulario.Show();
                if (index == 0)
                    formCaratula = formEsteFormulario;
            }
        }

        //Esconde los panes y Labels d la vista previa
        private void esconderLabels()
        {
            labelTituloExp.Hide();
            labelAviso.Hide();
            panelDetalleActividades.Hide();
        }

        //Muestra los panes y Labels de la vista previa
        private void mostrarLabels()
        {
            labelTituloExp.Show();
            labelAviso.Show();
            panelDetalleActividades.Show();
        }

        private void gesti�nPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionPerfiles gp = new FormGestionPerfiles();
            gp.MdiParent = padreMDI;
            gp.setPadreMDI(padreMDI);
            gp.Show();
        }

        private void gesti�nDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios usuarios = new FormGestionUsuarios();
            usuarios.MdiParent = padreMDI;
            usuarios.setPadreMDI(padreMDI);
            usuarios.Show();
        }

        private void asignaci�nDeExpedientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignarExpedientes asignador = new FormAsignarExpedientes();
            asignador.MdiParent = padreMDI;
            asignador.setPadreMDI(padreMDI);
            asignador.Show();
        }

        private void asignaci�nDeActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignacionActividades activid= new FormAsignacionActividades();
            activid.MdiParent = padreMDI;
            activid.setPadreMDI(padreMDI);
            activid.Show();
        }

        private void cambiarNombreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String correlativoFlujo;
            String correlativoPadre;
            FlujoTrabajo flujo = arbol.flujoSeleccionado();
            if (flujo != null)//if (this.arbol.nodoSeleccionado().Name.Contains("F"))
            {
                MessageBox.Show("No es posible cambiarle el nombre a un flujo de trabajo");
            }/*else if (this.arbol.nodoSeleccionado().Name.Equals("0"))
            {
                MessageBox.Show("No es posible cambiarle el nombre a la ra�z del directorio");
            }*/
            else
            {
                Expediente expediente = arbol.expedienteSeleccionado();
                if (expediente != null)
                {
                    correlativoFlujo = expediente.getIDFlujo().ToString();
                    correlativoPadre = expediente.getIDColeccion().ToString();
                    String correlativoExpediente = expediente.getCorrelativo().ToString();
                    FormFlujosConstruidos form = new FormFlujosConstruidos(this, correlativoExpediente, correlativoPadre, correlativoFlujo);
                    form.MdiParent = padreMDI;
                    form.setPadreMDI(padreMDI);
                    form.Show();
                }
                else
                {
                    Coleccion coleccion = arbol.coleccionSeleccionada();
                    if (coleccion != null)
                    {
                        correlativoFlujo = coleccion.getCorrelativoFlujo().ToString();
                        correlativoPadre = coleccion.getCorrelativo().ToString();
                        FormNuevaColeccion formColeccion = new FormNuevaColeccion(this, coleccion.getCorrelativo());
                        formColeccion.MdiParent = padreMDI;
                        formColeccion.setPadreMDI(padreMDI);
                        formColeccion.Show();
                    }
                }
            }            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TreeNode seleccionado = arbol.nodoSeleccionado();
            Expediente expediente = arbol.expedienteSeleccionado();
            if (expediente != null)
            {
                FormEliminar eliminar = new FormEliminar(this, expediente.getNombre(), expediente.getCorrelativo().ToString(), "Expediente");
                eliminar.MdiParent = padreMDI;
                eliminar.setPadreMDI(padreMDI);
                eliminar.Show();
            }
        }

        private void cerrarSesi�nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConexiones conexiones = new FormConexiones();
            conexiones.MdiParent = padreMDI;
            conexiones.setPadreMDI(padreMDI);
            this.Hide();
            conexiones.Show();
        }

        private void pictureBoxInbox_Click(object sender, EventArgs e)
        {
            pictureBoxInbox.Image = GiftEjecutor.Properties.Resources.Pesta�aInvertidaInbox;
            pictureBoxVistaPrevia.Image = GiftEjecutor.Properties.Resources.Pesta�aNoInvertidaPrevia;            
            mostrarInbox();
        }

        private void mostrarInbox() {
            esconderVistaPrevia();
            panelInbox.Show();
            inbox = new Inbox(this.usuarioActual);
            if (usuarioActual.getIDsExpedientes() != null)
            {
                //tengo q crear todos los expedientes
                int[] idsExps = usuarioActual.getIDsExpedientes();
                Expediente[] exps = new Expediente[idsExps.Length];
                for (int i = 0; i < idsExps.Length; ++i)
                {
                    exps[i] = new Expediente(idsExps[i]);
                }
                //dataGridInbox.RowCount = 0;
                //dataGridInbox.DataSource = null;
                dataGridInbox = new DataGridView();
                dataGridInbox.DataSource = inbox.llenarDataGridInbox(exps);
                if (dataGridInbox.Rows.Count > 0)
                {
                    dataGridInbox.Columns[0].Visible = false;
                    dataGridInbox.Columns[2].Visible = false;
                    dataGridInbox.Columns[4].Visible = false;
                    dataGridInbox.Columns[7].Visible = false; //esta es la fecha, de momento no esta funcionando.
                    dataGridInbox.Refresh();
                }
            }
        }

        private void pictureBoxVistaPrevia_Click(object sender, EventArgs e)
        {
            pictureBoxInbox.Image = GiftEjecutor.Properties.Resources.Pesta�aNoInvertidaInbox;
            pictureBoxVistaPrevia.Image = GiftEjecutor.Properties.Resources.Pesta�aInvertidaPrevia;
            //esconde el panel del inbox
            panelInbox.Hide();
            mostrarVistaPrevia();            
        }        

        /// <summary>
        /// Esconde el form caratula si esta abierto y cualquier otra informacion de la vista previa
        /// </summary>
        private void esconderVistaPrevia()
        {
            if (this.formCaratula != null)
                this.formCaratula.Dispose();
            esconderLabels();
        }

        private void botonEjecutarActInbox_Click(object sender, EventArgs e)
        {
            //si se eligio alguna actividad
            if (dataGridInbox.CurrentRow != null)
            {
                int correlativoFlujo = int.Parse(this.dataGridInbox[0, this.dataGridInbox.CurrentRow.Index].Value.ToString());
                int correlativoExpediente = int.Parse(this.dataGridInbox[2, this.dataGridInbox.CurrentRow.Index].Value.ToString());
                FormListadoActividad actividad = new FormListadoActividad(padreMDI.getUsuario(),correlativoFlujo, correlativoExpediente, true, null);
                actividad.MdiParent = padreMDI;
                actividad.setPadreMDI(padreMDI);
                actividad.Show();
            }
            else {
                MessageBox.Show("Favor elegir una actividad");                
            }
        }

        private void botonRechazarActInbox_Click(object sender, EventArgs e)
        {
            //si se eligio alguna actividad
            if (dataGridInbox.CurrentRow != null)
            {
                int idAct = int.Parse(this.dataGridInbox[4, this.dataGridInbox.CurrentRow.Index].Value.ToString());
                int idExp = int.Parse(this.dataGridInbox[2, this.dataGridInbox.CurrentRow.Index].Value.ToString());
                
                //int index = dataGridInbox.CurrentRow.Index;
                /*this.dataGridInbox.SelectedRows = -1;
                dataGridInbox.se
                *///this.dataGridInbox.Rows[index].Visible = false;
                
                usuarioActual.desasignarActividad(idExp, idAct);
                mostrarInbox();
            }
            else
            {
                MessageBox.Show("Favor elegir una actividad");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}