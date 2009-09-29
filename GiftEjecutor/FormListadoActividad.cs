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
        int IDExpediente;
        bool soyUnFlujoNoActividadCompuesta;
        
        public FormListadoActividad()
        {
            InitializeComponent();
        }
        
        public FormListadoActividad(int IDFlujo, int IDExpediente, bool soyUnFlujo)
        {
            soyUnFlujoNoActividadCompuesta = soyUnFlujo;
            //Si se van a mostrar las actividades de un flujo
            if (soyUnFlujoNoActividadCompuesta)
            {                
                this.IDFlujo = IDFlujo;
                this.IDExpediente = IDExpediente;
                InitializeComponent();
                this.cargarDataGridActividad();
                FlujoTrabajo flujo;
                flujo = new FlujoTrabajo(IDFlujo);
                this.labelEncabezadoActividades.Text = "Actividades del flujo ''" + flujo.getNombreFlujo() + "''";
                this.Text = "Actividades del Flujo''" + flujo.getNombreFlujo() + "''";
            }
            //Aqui es para mostrar actividades compuestas
            else { 
                            
            }
        }
        
        private void FormListadoActividad_Load(object sender, EventArgs e)
        {
            this.cargarDataGridActividad();
        }

        private void cargarDataGridActividad() {
            Actividad actividad = new Actividad();
            actividad.setIDExpediente(IDExpediente);

            if (soyUnFlujoNoActividadCompuesta)
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
            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente);
            formActividad.Show();
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

            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente);
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

            FormActividad formActividad = new FormActividad(IDActividad, IDExpediente);
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
               
    }
}