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
        Comando comandoAEjecutar;        

        public FormActividad()
        {
            InitializeComponent();
        }
        public FormActividad(int IDAct, int IDExp)
        {

            InitializeComponent();

            this.IDActividad = IDAct;
            this.IDExpediente = IDExp;
            ActividadSimple actividadSimple = new ActividadSimple();
            actividadSimple.setAtributosPorID(this.IDActividad);

            //ya no va a haber TextBoxDescripcion no textBoxNombre porque al profe no le gustó la idea. Ricardo
            //this.textBoxDescripcion.Text = actividadSimple.descripcion
            //this.textBoxNombre.Text = actividadSimple.nombre;

            this.labelEncabezadoComando.Text = "Comandos de la Actividad ''" + actividadSimple.nombre+"''";
            this.Text = "Comandos de la Actividad ''" + actividadSimple.nombre + "''";
        }

        private void FormActividad_Load(object sender, EventArgs e)
        {
            this.cargarDataGridComandos();
        }

        private void cargarDataGridComandos() {
            Comando comando = new Comando();
            comando.setIDExpediente(IDExpediente);
            this.dataGridEjecutados.DataSource = comando.getDataTableComandosPorIDActividadYaRealizado(this.IDActividad);
            dataGridEjecutados.Refresh();
            this.dataGridComandos.DataSource = comando.getDataTableComandosPorIDActividad(this.IDActividad);
            dataGridComandos.Refresh();
            this.dataGridNoPosibles.DataSource = comando.getDataTableComandosPorIDActividadNoRealizados(this.IDActividad);
            dataGridNoPosibles.Refresh();
        }

        private void buttonEjecutarComando_Click(object sender, EventArgs e)
        {
            //LINEA AGREGADA POR RICARDO:
            this.comandoAEjecutar = new Comando();
            
            int fila = dataGridComandos.CurrentRow.Index;
            String strTipo = dataGridComandos[3, fila].Value.ToString();            
            int tipoComando = comandoAEjecutar.getTipoComando(strTipo);
            //TEMPORALES
            int IDDatos = -1;
            //FIN TEMPS
            int IDComando = Int32.Parse(dataGridComandos[0, fila].Value.ToString());
            comandoAEjecutar.setAtributosSegunID(IDComando);
            
            //Mientras no sea de creacion se debe elegir con cual instancia se desea trabajar
            if (tipoComando != 1) {
               
                FormElegirInstancia instancia = new FormElegirInstancia(comandoAEjecutar.IDFormularioATrabajar, IDExpediente, tipoComando, comandoAEjecutar.getID(), IDActividad);
                instancia.Show();
            }            
            else//es de creacion
            {                
                FormFormulario formFormulario = new FormFormulario(comandoAEjecutar.IDFormularioATrabajar, IDExpediente, IDDatos, tipoComando, comandoAEjecutar.getID());
                formFormulario.Show();
            }
        }

        private void dataGridComandos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.buttonEjecutarComando.Enabled = true;

            //NOTA (OJO LUIS CARLOS): LAS SIGUIENTES TRES LÍNEAS DE CODIGO LAS COMENTE PORQUE NO CREO QUE VAN AQUI SINO 
            //EN buttonEjecutarComando_Click(object sender, EventArgs e). RICARDO

            //this.comandoAEjecutar = new Comando();
            //int IDComando = System.Int32.Parse( this.dataGridComandos[0, this.dataGridComandos.CurrentRow.Index].Value.ToString());
            //comandoAEjecutar.setAtributosSegunID(IDComando);


            /*
            comandoAEjecutar.setIDExpediente(this.IDExpediente);
            //Mae alberto aquí tiene una instancia del comando a ejecutar, con todos los datos que ocupa.
            mensajeTemporal = "Aquí es donde entra en acción alberto!!!!, mae me parece que aquí puede tomar todo lo que ocupa para desplegar el form y aplicarle el comando correspondiente" + '\n' + '\n';
            mensajeTemporal += comandoAEjecutar.ToString();
             */
        }

        private void cambiarColorBotonOver(object sender, EventArgs e)
        {
            this.buttonEjecutarComando.BackColor = Color.Lime;
        }

        private void cambiarColorBotonOut(object sender, EventArgs e)
        {
            this.buttonEjecutarComando.BackColor = Color.LimeGreen;
        }

        private void cambiarColorBotonClick(object sender, MouseEventArgs e)
        {
            this.buttonEjecutarComando.BackColor = Color.Red;
        }

        private void CambiarColorBotonOut(object sender, MouseEventArgs e)
        {
            this.buttonEjecutarComando.BackColor = Color.LimeGreen;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEjecutarComando_EnabledChanged(object sender, EventArgs e)
        {
            this.buttonEjecutarComando.BackColor = Color.LimeGreen;
        }

        private void buttonCerrarColorClaro(object sender, EventArgs e)
        {
            this.buttonCerrar.BackColor = Color.Red;
        }

        private void buttonCerrarColorOscuro(object sender, EventArgs e)
        {
            this.buttonCerrar.BackColor = Color.OrangeRed;
        }

        private void dataGridComandos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}