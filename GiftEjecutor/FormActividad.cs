using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormActividad : Form
    {
        string mensajeTemporal="------";
        int IDActividad;
        int IDExpediente;
        public FormActividad()
        {
            InitializeComponent();
        }
        public FormActividad(int IDActividad, int IDExpediente)
        {

            InitializeComponent();
            this.IDActividad = IDActividad;
            this.IDExpediente = IDExpediente;
            ActividadSimple actividadSimple = new ActividadSimple();
            actividadSimple.setAtributosPorID(this.IDActividad);
            this.textBoxDescripcion.Text = actividadSimple.descripcion;
            this.textBoxNombre.Text = actividadSimple.nombre;
        }
        private void FormActividad_Load(object sender, EventArgs e)
        {
            this.cargarDataGridComandos();
        }
        private void cargarDataGridComandos() {
            Comando comando = new Comando();
            this.dataGridComandos.DataSource = comando.getDataTableComandosPorIDActividad(this.IDActividad);
            dataGridComandos.Refresh();
        }

        private void buttonEjecutarComando_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mensajeTemporal);
        }

        private void dataGridComandos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buttonEjecutarComando.Enabled = true;
            Comando comandoAEjecutar =new Comando();
            int IDComando = System.Int32.Parse( this.dataGridComandos[0, this.dataGridComandos.CurrentRow.Index].Value.ToString());
            comandoAEjecutar.setAtributosSegunID(IDComando);
            comandoAEjecutar.setIDExpediente(this.IDExpediente);
            //Mae alberto aquí tiene una instancia del comando a ejecutar, con todos los datos que ocupa.
            mensajeTemporal = "Aquí es donde entra en acción alberto!!!!, mae me parece que aquí puede tomar todo lo que ocupa para desplegar el form y aplicarle el comando correspondiente" + '\n' + '\n';
            mensajeTemporal += comandoAEjecutar.ToString();
        }
    }
}