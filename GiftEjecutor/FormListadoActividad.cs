using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormListadoActividad : Form
    {
        string mensajeTemporal="------";
        int IDFlujo;
        public int IDActividadCompuesta;
        int IDExpediente;
        bool soyUnFlujoNoActividadCompuesta;
        ActividadCompuesta actividadCompuesta;
        public FormListadoActividad()
        {
            InitializeComponent();
        }
        
        public FormListadoActividad(int IDFlujo, int IDExpediente, bool soyUnFlujo)
        {
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
                this.Text = "Actividades del Flujo''" + flujo.getNombreFlujo() + "''";
                this.cargarDataGridActividad();
            }
            //Aqui es para mostrar actividades compuestas
            else {
                this.IDActividadCompuesta = IDFlujo;
                actividadCompuesta = new ActividadCompuesta();
                actividadCompuesta.setIDExpediente(IDExpediente);
                actividadCompuesta.setAtributosPorID(IDActividadCompuesta);
             //   MessageBox.Show(actividadCompuesta.ToString());
                this.labelEncabezadoActividades.Text = "Actividades de la actividad ''" + actividadCompuesta.getNombre() + "'' Paralela: " + actividadCompuesta.esParalela;

                this.IDExpediente = IDExpediente;
                soyUnFlujoNoActividadCompuesta = false;
                this.cargarDataGridActividad();           
            }





        }
        
        private void FormListadoActividad_Load(object sender, EventArgs e)
        {
            //this.cargarDataGridActividad();
        }

        public void cargarDataGridActividad() {
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
            }
            //Aqui entra ud luis carlos! Actividades compuestas! ...dice beto
            else {

                dataGridEjecutados.DataSource = actividad.getDataTableActividadesEjecutadasHijaPorIDPadre(this.IDActividadCompuesta);
                dataGridEjecutados.Columns[4].Visible = false;
                dataGridEjecutados.Refresh();

                dataGridActividad.DataSource = actividad.getDataTableActividadesEjecutablesHijasPorIDPadre(this.IDActividadCompuesta);
                dataGridActividad.Columns[4].Visible = false;
                dataGridActividad.Refresh();

                dataGridPorEjecutar.DataSource = actividad.getDataTableActividadesNOEjecutablesHijasPorIDPadre(this.IDActividadCompuesta);
                dataGridPorEjecutar.Columns[4].Visible = false;
                dataGridPorEjecutar.Refresh();
//
               /* dataGridActividad.DataSource = actividadCompuesta.getDataTableTodasActividadesHija(45);
                //dataGridActividad.Columns[4].Visible = false;
                dataGridActividad.Refresh();*/


            }

        }

        private void buttonEjecutarActividad_Click(object sender, EventArgs e)        
        {
            //this.buttonEjecutarActividad.Enabled = true;
            Actividad actividadAEjecutar = new Actividad();
            int IDActividad = System.Int32.Parse(this.dataGridActividad[0, this.dataGridActividad.CurrentRow.Index].Value.ToString());
            actividadAEjecutar.setAtributosSegunID(IDActividad);
            actividadAEjecutar.setIDExpediente(this.IDExpediente);
            Controlador control = new Controlador();
            //Si es repetible


            if (dataGridActividad[4, dataGridActividad.CurrentRow.Index].Value.ToString().Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                //Para que se vuelva a escribir ya debe estar finalizada
                if ( control.checkActividadRealizada(IDActividad, IDExpediente) )
                    actividadAEjecutar.insertarEnBitacora(this.IDExpediente, IDActividad, -1, -1, -1, -1, false, "Se inició la ejecución de la actividad " + actividadAEjecutar.getNombre() + ".");
            }
            //Mientras la actividad no este a medio ejecutar, osea se esta ejecutando por primera vez
            //entonces se escribe en bitácora, si no, no se vuelve a escribir.
            else
            {
                if (!control.checkActividadRealizada(IDActividad, IDExpediente))
                {
                    actividadAEjecutar.insertarEnBitacora(this.IDExpediente, IDActividad, -1, -1, -1, -1, false, "Se inició la ejecución de la actividad " + actividadAEjecutar.getNombre() + ".");
                }
            }



            if (dataGridActividad[3, dataGridActividad.CurrentRow.Index].Value.ToString().Equals("Compuesta"))
            {

           //     MessageBox.Show("Compuesta");
              //  MessageBox.Show("Simple");
              //  FormActividad formActividad = new FormActividad(IDActividad, IDExpediente,1);
              //  formActividad.Show();

                FormListadoActividad formListadoActividad = new FormListadoActividad(IDActividad, IDExpediente, false);
                formListadoActividad.Show();
            }
            else {
            //    MessageBox.Show("Simple");
                FormActividad formActividad = new FormActividad(IDActividad, IDExpediente, this);
                formActividad.Show();
            }







        }

        private void dataGridActividad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEjecutarActividad.Enabled = true;
            Actividad actividadAEjecutar =new Actividad();
            int IDActividad = System.Int32.Parse( this.dataGridActividad[0, this.dataGridActividad.CurrentRow.Index].Value.ToString());
            actividadAEjecutar.setAtributosSegunID(IDActividad);
            actividadAEjecutar.setIDExpediente(this.IDExpediente);
            //Mae Luis Carlos aquí tiene una instancia de Actividad, con todos los datos que ocupa.
            mensajeTemporal = "Aqui sigue lo de Luis Carlos!!!" + '\n' + '\n';
            mensajeTemporal += actividadAEjecutar.ToString();

            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente, this);
            formActividad.Show();
        }

        private void dataGridActividad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEjecutarActividad.Enabled = true;
            Actividad actividadAEjecutar = new Actividad();
            int IDActividad = System.Int32.Parse(this.dataGridActividad[0, this.dataGridActividad.CurrentRow.Index].Value.ToString());
            actividadAEjecutar.setAtributosSegunID(IDActividad);
            actividadAEjecutar.setIDExpediente(this.IDExpediente);
            //Mae Luis Carlos aquí tiene una instancia de Actividad, con todos los datos que ocupa.
            mensajeTemporal = "Aqui sigue lo de Luis Carlos!!!" + '\n' + '\n';
            mensajeTemporal += actividadAEjecutar.ToString();

            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente, this);
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

        private void FormListadoActividad_Load_1(object sender, EventArgs e)
        {

        }

        private void FormListadoActividad_Enter(object sender, EventArgs e)
        {
            //this.cargarDataGridActividad(false);
        }

        private void FormListadoActividad_Leave(object sender, EventArgs e)
        {
            //this.cargarDataGridActividad(false);
        }
               
    }
}