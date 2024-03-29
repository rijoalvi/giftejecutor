using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    /// <summary>
    /// Ventana que muestra las actividades de un flujo, o las actividades de una actividad compuesta
    /// </summary>
    public partial class FormListadoActividad : Form
    {
        private Ventanota padreMDI;

        string mensajeTemporal="------";
        int IDFlujo;
        public int IDActividadCompuesta;
        int IDExpediente;
        bool soyUnFlujoNoActividadCompuesta;
        ActividadCompuesta actividadCompuesta;
        FormListadoActividad miPadre;

        /// <summary>
        /// Constructor por omisi�n
        /// </summary>
        public FormListadoActividad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe datos para inicializar
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="IDFlujo"></param>
        /// <param name="IDExpediente"></param>
        /// <param name="soyUnFlujo"></param>
        /// <param name="tata"></param>
        public FormListadoActividad(Usuario usuario,int IDFlujo, int IDExpediente, bool soyUnFlujo, FormListadoActividad tata)
        {
           
            miPadre = tata;
            soyUnFlujoNoActividadCompuesta = soyUnFlujo;
            //Si se van a mostrar las actividades de un flujo
            InitializeComponent();
            this.IDExpediente = IDExpediente;
            if (soyUnFlujoNoActividadCompuesta)
            {                
                this.IDFlujo = IDFlujo;
                
                
               // this.cargarDataGridActividad();
                FlujoTrabajo flujo;
                flujo = new FlujoTrabajo(IDFlujo);
                this.labelEncabezadoActividades.Text = "Actividades del flujo ''" + flujo.getNombreFlujo() + "''";
                this.Text = "Actividades del Flujo\"" + flujo.getNombreFlujo() + "\"";
                this.cargarDataGridActividad(usuario);                
            }
            //Aqui es para mostrar actividades compuestas
            else {
                this.IDActividadCompuesta = IDFlujo;
                actividadCompuesta = new ActividadCompuesta();
                actividadCompuesta.setIDExpediente(IDExpediente);
                actividadCompuesta.setAtributosPorID(IDActividadCompuesta);
             //   MessageBox.Show(actividadCompuesta.ToString());
                this.labelEncabezadoActividades.Text = "Actividades de la actividad ''" + actividadCompuesta.getNombre() + "'' Paralela: " + actividadCompuesta.esParalela + "'' Exclusivo: " + actividadCompuesta.esExclusiva;

                this.IDExpediente = IDExpediente;
                soyUnFlujoNoActividadCompuesta = false;
                this.cargarDataGridActividad(usuario);           
            }





        }
        
        private void FormListadoActividad_Load(object sender, EventArgs e)
        {
            //this.cargarDataGridActividad();
        }

        /// <summary>
        /// Llena los datos de los datagrids
        /// </summary>
        /// <param name="usuario"></param>
        public void cargarDataGridActividad(Usuario usuario) {
            Actividad actividad = new Actividad();
            ActividadCompuesta actividadCompuesta = new ActividadCompuesta();
            actividadCompuesta.setAtributosDeActividadCompuesta(this.IDActividadCompuesta);
            actividad.setAtributosSegunID(this.IDActividadCompuesta);
            actividad.esParalela = actividadCompuesta.esParalela;

         //   ActividadCompuesta actividadCompuesta = new ActividadCompuesta();
            actividad.setIDExpediente(IDExpediente);

            if (soyUnFlujoNoActividadCompuesta)
            //if (!compuesta)
            {
                dataGridEjecutados.DataSource = actividad.getDataTableActividadesPorIDFlujoEjecutadas(this.IDFlujo);
                dataGridEjecutados.Columns[4].Visible = false;
                dataGridEjecutados.Refresh();

                dataGridActividad.DataSource = actividad.getDataTableActividadesEjecutablesPorIDFlujo(this.IDFlujo);
                dataGridActividad.Columns[4].Visible = false; 
                dataGridActividad.Refresh();

                dataGridPorEjecutar.DataSource = actividad.getDataTableActividadesNOEjecutablesPorIDFlujo(this.IDFlujo);
                dataGridPorEjecutar.Columns[4].Visible = false; 
                dataGridPorEjecutar.Refresh();
                
                //cuando se finalizo la actividad simple
                if (dataGridActividad.RowCount == 0)
                {
                    Controlador cont;
                    cont = new Controlador();
                    cont.finalizarActividadBitacora(IDExpediente, IDFlujo, usuario);//padreMDI.getUsuario());
                    this.Close();
                }
            }
            //Aqui entra ud luis carlos! Actividades compuestas! ...dice beto
            else {

                dataGridEjecutados.DataSource = actividad.getDataTableActividadesEjecutadasHijaPorIDPadre(this.IDActividadCompuesta);
                dataGridEjecutados.Columns[4].Visible = false;
                dataGridEjecutados.Refresh();

                dataGridActividad.DataSource = actividad.getDataTableActividadesEjecutablesHijasPorIDPadre(this.IDActividadCompuesta, this.IDActividadCompuesta);
                dataGridActividad.Columns[4].Visible = false;
                dataGridActividad.Refresh();

                dataGridPorEjecutar.DataSource = actividad.getDataTableActividadesNOEjecutablesHijasPorIDPadre(this.IDActividadCompuesta);
                dataGridPorEjecutar.Columns[4].Visible = false;
                dataGridPorEjecutar.Refresh();

                

                //cuando se finalizo la actividad compuesta
                if (dataGridActividad.RowCount == 0)
                {
                    Controlador cont;
                    cont = new Controlador();
                    cont.finalizarActividadBitacora(IDExpediente, IDActividadCompuesta, padreMDI.getUsuario());
                    miPadre.cargarDataGridActividad(padreMDI.getUsuario());
                    this.Close();

                }

            }
            

        }

        private void buttonEjecutarActividad_Click(object sender, EventArgs e)        
        {
            //this.buttonEjecutarActividad.Enabled = true;
            Actividad actividadAEjecutar = new Actividad();
            int IDActividad = System.Int32.Parse(this.dataGridActividad[0, this.dataGridActividad.CurrentRow.Index].Value.ToString());
            //if ( padreMDI.getUsuario().actividadValida(IDActividad,this.IDExpediente){
            //if (actividadAEjecutar.getExclusiva(IDActividadCompuesta))

            if (padreMDI.getUsuario().actividadValida(IDActividad,IDExpediente))
            {
                if (actividadAEjecutar.getExclusiva(IDActividadCompuesta))
                {
                    Controlador cont = new Controlador();
                    for (int i = 0; i < dataGridActividad.RowCount; ++i)
                    {
                        if (i != dataGridActividad.CurrentRow.Index)
                        {
                            int IDActividadNOEjecutar = System.Int32.Parse(this.dataGridActividad[0, i].Value.ToString());
                            cont.finalizarActividadBitacora(IDExpediente, IDActividadNOEjecutar, padreMDI.getUsuario());
                        }
                    }
                    cont.finalizarActividadBitacora(IDExpediente, IDActividadCompuesta, padreMDI.getUsuario());
                }

                actividadAEjecutar.setAtributosSegunID(IDActividad);
                actividadAEjecutar.setIDExpediente(this.IDExpediente);
                Controlador control = new Controlador();
                //Si es repetible


                if (dataGridActividad[4, dataGridActividad.CurrentRow.Index].Value.ToString().Equals("True", StringComparison.OrdinalIgnoreCase))
                {
                    //Para que se vuelva a escribir ya debe estar finalizada
                    if (control.checkActividadRealizada(IDActividad, IDExpediente))
                        actividadAEjecutar.insertarEnBitacora(this.IDExpediente, IDActividad, -1, -1, -1, -1, false, "El usuario " + padreMDI.getUsuario() + " inici� la ejecuci�n de la actividad " + actividadAEjecutar.getNombre() + ".");
                }
                //Mientras la actividad no este a medio ejecutar, osea se esta ejecutando por primera vez
                //entonces se escribe en bit�cora, si no, no se vuelve a escribir.
                else
                {
                    if (!control.checkActividadIniciada(IDActividad, IDExpediente))
                    {
                        actividadAEjecutar.insertarEnBitacora(this.IDExpediente, IDActividad, -1, -1, -1, -1, false, "El usuario " + padreMDI.getUsuario() + " inici� la ejecuci�n de la actividad " + actividadAEjecutar.getNombre() + ".");
                    }
                }

                if (dataGridActividad[3, dataGridActividad.CurrentRow.Index].Value.ToString().Equals("Compuesta"))
                {

                    //     MessageBox.Show("Compuesta");
                    //  MessageBox.Show("Simple");
                    //  FormActividad formActividad = new FormActividad(IDActividad, IDExpediente,1);
                    //  formActividad.Show();

                    FormListadoActividad formListadoActividad = new FormListadoActividad(padreMDI.getUsuario(),IDActividad, IDExpediente, false, this);
                    formListadoActividad.MdiParent = padreMDI;
                    formListadoActividad.setPadreMDI(padreMDI);
                    formListadoActividad.Show();
                }
                else
                {
                    //    MessageBox.Show("Simple");
                    FormActividad formActividad = new FormActividad(IDActividad, IDExpediente, this);
                    formActividad.MdiParent = padreMDI;
                    formActividad.setPadreMDI(padreMDI);
                    formActividad.Show();
                }
            }
            else
            {
                MessageBox.Show("Su cuenta no tiene los derechos suficientes para realizar esta operaci�n");
            }
        //}
        //else{MessageBox.Show("Su cuenta no cuenta con los derechos para ejecutar esta actividad"}
        }

        private void dataGridActividad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEjecutarActividad.Enabled = true;
            Actividad actividadAEjecutar =new Actividad();
            int IDActividad = System.Int32.Parse( this.dataGridActividad[0, this.dataGridActividad.CurrentRow.Index].Value.ToString());
            actividadAEjecutar.setAtributosSegunID(IDActividad);
            actividadAEjecutar.setIDExpediente(this.IDExpediente);
            //Mae Luis Carlos aqu� tiene una instancia de Actividad, con todos los datos que ocupa.
            mensajeTemporal = "Aqui sigue lo de Luis Carlos!!!" + '\n' + '\n';
            mensajeTemporal += actividadAEjecutar.ToString();

            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente, this);
            formActividad.MdiParent = padreMDI;
            formActividad.setPadreMDI(padreMDI);
            formActividad.Show();
        }

        private void dataGridActividad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEjecutarActividad.Enabled = true;
            Actividad actividadAEjecutar = new Actividad();
            int IDActividad = System.Int32.Parse(this.dataGridActividad[0, this.dataGridActividad.CurrentRow.Index].Value.ToString());
            actividadAEjecutar.setAtributosSegunID(IDActividad);
            actividadAEjecutar.setIDExpediente(this.IDExpediente);
            //Mae Luis Carlos aqu� tiene una instancia de Actividad, con todos los datos que ocupa.
            mensajeTemporal = "Aqui sigue lo de Luis Carlos!!!" + '\n' + '\n';
            mensajeTemporal += actividadAEjecutar.ToString();

            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente, this);
            formActividad.MdiParent = padreMDI;
            formActividad.setPadreMDI(padreMDI);
            formActividad.Show();
        }
               
        private void dataGridActividad_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEjecutarActividad.Enabled = true;
        }

        private void buttonEjecutarActividad_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonEjecutarActividad.BackColor = Color.Red;
        }

        private void buttonEjecutarActividad_MouseEnter(object sender, EventArgs e)
        {
            this.buttonEjecutarActividad.BackColor = Color.Lime;
        }

        private void buttonEjecutarActividad_MouseLeave(object sender, EventArgs e)
        {
            this.buttonEjecutarActividad.BackColor = Color.LimeGreen;
        }

        private void buttonEjecutarActividad_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonEjecutarActividad.BackColor = Color.LimeGreen;
        }

        private void buttonEjecutarActividad_EnabledChanged(object sender, EventArgs e)
        {
            this.buttonEjecutarActividad.BackColor = Color.LimeGreen;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Asigna el padre MDI
        /// </summary>
        /// <param name="v"></param>
        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }
               
    }
}