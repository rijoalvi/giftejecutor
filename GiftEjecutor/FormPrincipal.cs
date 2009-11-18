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
    public partial class FormPrincipal : Form
    {
        private Ventanota padreMDI;
        private int IDExpediente;
        private String[] IDsFormularios;
        private FormFormulario formCaratula;
        private Usuario usuarioActual;

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
        /// constructor
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
            labelTituloExp.Hide();
            this.arbol = new ArbolGift(directorio, usuarioActual);                        
        }

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
        }

        private void buttonActividad_Click(object sender, EventArgs e)
        {
            int IDExpediente = 13;
            int IDFlujo = 4;
            FormListadoActividad formListadoActividad = new FormListadoActividad(IDFlujo, IDExpediente, true, null);
            formListadoActividad.MdiParent = padreMDI;
            formListadoActividad.setPadreMDI(padreMDI);
            formListadoActividad.Show();
        }

        private void agregarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Se debe seleccionar la colección en la que se creará la colección en el directorio");
            }
        }

        private void agregarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.arbol.hayNodoSeleccionado())
            {
                String correlativoFlujo;
                String correlativoPadre;
                FlujoTrabajo flujo = this.arbol.flujoSeleccionado();
                if (flujo != null)
                {
                    correlativoFlujo = flujo.getCorrelativo().ToString();// arbol.nodoSeleccionado().Name.Substring(1);
                    correlativoPadre = "0"; //Tiene correlativo en 0 pues se encuentra en la raíz del flujo
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
                        MessageBox.Show("Solo es posible crear Colecciones dentro de un Flujo de trabajo o dentro de otra Colección");
                    }
                }
            }
            else {
                MessageBox.Show("Se debe seleccionar el Flujo de trabajos o la colección en la que se creará la colección en el directorio");
            }            
        }

        private void cambiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String correlativoFlujo;
            String correlativoPadre;
            FlujoTrabajo flujo = arbol.flujoSeleccionado();
            if (flujo != null)//if (this.arbol.nodoSeleccionado().Name.Contains("F"))
            {
                MessageBox.Show("No es posible cambiarle el nombre a un flujo de trabajo");
            }/*else if (this.arbol.nodoSeleccionado().Name.Equals("0"))
            {
                MessageBox.Show("No es posible cambiarle el nombre a la raíz del directorio");
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
                        FormNuevaColeccion formColeccion = new FormNuevaColeccion(this,coleccion.getCorrelativo());
                        formColeccion.MdiParent = padreMDI;
                        formColeccion.setPadreMDI(padreMDI);
                        formColeccion.Show();
                    }
                }
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
                FormListadoActividad actividad = new FormListadoActividad(correlativoFlujo, correlativoExpediente, true,null);
                actividad.MdiParent = padreMDI;
                actividad.setPadreMDI(padreMDI);
                actividad.Show();
            }else if(expediente!=null && expediente.yaFinalizado()== 1){
                MessageBox.Show("El expediente seleccionado ya fue finalizado");
            }

        }

        private void eliminarBETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TreeNode seleccionado = arbol.nodoSeleccionado();
            Expediente expediente = arbol.expedienteSeleccionado();
            if (expediente != null) {
                FormEliminar eliminar = new FormEliminar(this,expediente.getNombre(),expediente.getCorrelativo().ToString(),"Expediente");
                eliminar.MdiParent = padreMDI;
                eliminar.setPadreMDI(padreMDI);
                eliminar.Show();
            }
        }
        
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
            ponerUsuarioEnVentanota();
        }

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
        /// Método que llena los datos de ejecución de un expediente, contenidos dentro del panel "panelEjecutorial"
        /// </summary>
        /// <param name="IDExpediente"></param>
        private void llenarDatosEjecucionExpediente(int IDExpediente, int IDFlujo)
        {
            invalidarPanels();
            //TreeNode seleccionado = arbol.nodoSeleccionado();
            //labelDetalleEjecutorial.Text = "Estado de Ejecución del Expediente " + seleccionado.Text;
            
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
            //Aqui se tiene que cargar los detalles del expediente, si el nodo seleccionado es 1 expediente.
         //   indiceFormularios = 0; //NO BORRAR! Beto
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
                //muestra el formulario caratula
                mostrarFormulario(0);
            }
            else
            {
                //MessageBox.Show("No soy expediente =(");
                invalidarPanels();
            }
        }

        private void mostrarFormulario(int index)
        {
            //Se abre el form correspondiente
            Formulario elFormulario = new Formulario(int.Parse(IDsFormularios[index]));
            int IDTupla = elFormulario.getIDDeLaTupla(this.IDExpediente);
            if (IDTupla == -1)
            {
                MessageBox.Show("¡El Expediente todavía no posee los datos del formulario correspondiente!");
            }
            else
            {
                labelTituloExp.Text = "Expediente " + this.arbol.expedienteSeleccionado().getNombre();
                labelTituloExp.Show();
                FormFormulario formEsteFormulario = new FormFormulario(elFormulario.getID(), this.IDExpediente, -1, IDTupla, 6, -1, "", null);
                formEsteFormulario.TopMost = true;
                formEsteFormulario.MdiParent = this;
                formEsteFormulario.StartPosition = FormStartPosition.Manual;
                formEsteFormulario.Location = new Point(256, 25);
                formEsteFormulario.Show();
                if (index == 0)
                    formCaratula = formEsteFormulario;
            }
        }

        //Esconde los panes y Labels
        private void invalidarPanels() {
            labelTituloExp.Visible = false;
        }

        private void gestiónPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionPerfiles gp = new FormGestionPerfiles();
            gp.Show();
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios usuarios = new FormGestionUsuarios();
            usuarios.Show();
        }

        private void asignaciónDeExpedientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignarExpedientes asignador = new FormAsignarExpedientes();
            asignador.MdiParent = padreMDI;
            asignador.setPadreMDI(padreMDI);
            asignador.Show();
        }

        private void desconexiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConexiones conexiones = new FormConexiones();
            conexiones.MdiParent = padreMDI;
            conexiones.setPadreMDI(padreMDI);
            this.Hide();
            conexiones.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = GiftEjecutor.Properties.Resources.PestañaInvertidaInbox;
            pictureBox1.Image = GiftEjecutor.Properties.Resources.PestañaNoInvertidaPrevia;
            //Aqui se pone el 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = GiftEjecutor.Properties.Resources.PestañaNoInvertidaInbox;
            pictureBox1.Image = GiftEjecutor.Properties.Resources.PestañaInvertidaPrevia;
        }

        private void asignaciónDeActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignacionActividades activid= new FormAsignacionActividades();
            activid.MdiParent = padreMDI;
            activid.setPadreMDI(padreMDI);
            activid.Show();
        }
    }
}