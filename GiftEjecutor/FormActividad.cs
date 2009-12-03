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
        private Ventanota padreMDI;
        private int IDActividad;
        private int IDExpediente;
        private Comando comandoAEjecutar;
        private FormListadoActividad miPadre;
        private bool recienInstanciado;


        public FormActividad()
        {
            InitializeComponent();
        }
        public FormActividad(int IDAct, int IDExp, FormListadoActividad padre)
        {

            InitializeComponent();

            this.IDActividad = IDAct;
            this.IDExpediente = IDExp;
            this.miPadre = padre;
            ActividadSimple actividadSimple = new ActividadSimple();
            actividadSimple.setAtributosPorID(this.IDActividad);

            //ya no va a haber TextBoxDescripcion no textBoxNombre porque al profe no le gustó la idea. Ricardo
            //this.textBoxDescripcion.Text = actividadSimple.descripcion
            //this.textBoxNombre.Text = actividadSimple.nombre;

            this.labelEncabezadoComando.Text = "Comandos de la Actividad ''" + actividadSimple.nombre+"''";
            this.Text = "Comandos de la Actividad ''" + actividadSimple.nombre + "''";
            //this.cargarDataGridComandos();//lo quite de FormActividad_Load, luisk // NO puede estar aqui, porque no se le ha establecido el MDI Parent todavia
        }
        //si es actividad compuesta


        private void FormActividad_Load(object sender, EventArgs e)
        {
            this.cargarDataGridComandos();//lo movi para el constructor
            //this.Hide();
        }

        public void cargarDataGridComandos() {
            Comando comando = new Comando(padreMDI.getUsuario());
            comando.setIDExpediente(IDExpediente);
            this.dataGridEjecutados.DataSource = comando.getDataTableComandosPorIDActividadYaRealizado(this.IDActividad);
            dataGridEjecutados.Refresh();
            this.dataGridComandos.DataSource = comando.getDataTableComandosPorIDActividad(this.IDActividad);
            dataGridComandos.Refresh();
            this.dataGridNoPosibles.DataSource = comando.getDataTableComandosPorIDActividadNoRealizados(this.IDActividad);
            dataGridNoPosibles.Refresh();
            miPadre.cargarDataGridActividad(this.padreMDI.getUsuario());
            if (dataGridComandos.RowCount == 0 )
            {
                 Close();
                this.buttonEjecutarComando.Enabled = false;
            }
            else
            {
                dataGridComandos.FirstDisplayedScrollingRowIndex = 0;
                dataGridComandos.Refresh();
                dataGridComandos.CurrentCell = dataGridComandos.Rows[0].Cells[0];
                dataGridComandos.Rows[0].Selected = true;
                ejecutarComando();
            }
        }

 

        private void buttonEjecutarComando_Click(object sender, EventArgs e)
        {
            ejecutarComando();
        }

        private void ejecutarComando()
        {
            //LINEA AGREGADA POR RICARDO:
            this.comandoAEjecutar = new Comando(padreMDI.getUsuario());

            int fila = dataGridComandos.CurrentRow.Index;
            String strTipo = dataGridComandos[3, fila].Value.ToString();
            int tipoComando = comandoAEjecutar.getTipoComando(strTipo);
            //TEMPORALES
            int IDDatos = -1;
            //FIN TEMPS
            int IDComando = Int32.Parse(dataGridComandos[0, fila].Value.ToString());
            comandoAEjecutar.setAtributosSegunID(IDComando);

            //Mientras no sea de creacion se debe elegir con cual instancia se desea trabajar
            if (tipoComando != 1)
            {

                FormElegirInstancia instancia = new FormElegirInstancia(comandoAEjecutar.IDFormularioATrabajar, IDExpediente, tipoComando, comandoAEjecutar.getID(), IDActividad, this);
                instancia.MdiParent = padreMDI;
                instancia.setPadreMDI(padreMDI);

                //Solo si hay mas de una instancia se muestra, si no no
                if (instancia.getRowCount() > 1)
                    instancia.Show();
                else
                {
                    instancia.setIndex(0);
                    instancia.ejecutarComando();
                }
            }
            else//es de creacion
            {
                FormFormulario formFormulario = new FormFormulario(comandoAEjecutar.IDFormularioATrabajar, IDExpediente, IDActividad, IDDatos, tipoComando, comandoAEjecutar.getID(), "", this);
                formFormulario.MdiParent = padreMDI;
                formFormulario.setPadreMDI(padreMDI);
                formFormulario.Show();
            }
            // this.cargarDataGridComandos(); 
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

        private void FormActividad_Enter(object sender, EventArgs e)
        {
            this.cargarDataGridComandos();
        }

        private void FormActividad_Leave(object sender, EventArgs e)
        {
            this.cargarDataGridComandos();
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }

        private void labelComandosSinEjecutar_Click(object sender, EventArgs e)
        {

        }
    }
}