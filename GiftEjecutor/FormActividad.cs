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
            this.textBoxDescripcion.Text = actividadSimple.descripcion;
            this.textBoxNombre.Text = actividadSimple.nombre;
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
            int fila = dataGridComandos.CurrentRow.Index;
            String strTipo = dataGridComandos[3, fila].Value.ToString();            
            int tipoComando = comandoAEjecutar.getTipoComando(strTipo);
            //TEMPORALES
            int IDDatos = -1;
            //FIN TEMPS

            int IDComando = Int32.Parse(dataGridComandos[0, fila].Value.ToString());

            //Mientras no sea de creacion se debe elegir con cual instancia se desea trabajar
            if (tipoComando != 1) {
               // comandoAEjecutar.IDFormularioATrabajar;
               // IDExpediente;
                FormElegirInstancia instancia = new FormElegirInstancia();
                instancia.Show();
                //ciclo que espera a que el usuario responda
                while ( !instancia.isInstanciaElegida() );                

            }

            comandoAEjecutar.setAtributosSegunID(IDComando);
            if (strTipo.Equals("Máscara"))
            {
                ComandoMascara cm = new ComandoMascara();
                cm.setAtributosComandoMascaraSegunID(IDComando);
                MessageBox.Show(cm.ToString());
                ConsultaFormulario cf = new ConsultaFormulario();
                //cf.a
                //cf.actualizarUnCampoSegunID(IDDatos, cf.getNombreFormulario(comandoAEjecutar.IDFormularioATrabajar), cm.nombreCampoEfecto, cm.valorCampoEfecto, "varchar");

                cf.actualizarTodosLosCampos(IDDatos, cf.getNombreFormulario(comandoAEjecutar.IDFormularioATrabajar), cm.nombreCampoEfecto, cm.valorCampoEfecto, "varchar");
                cf.insertarEnBitacora(IDExpediente, this.IDActividad, IDComando, IDDatos, comandoAEjecutar.IDFormularioATrabajar, true, "Se modificó el campo " + cm.nombreCampoEfecto);
            }
            else//ejecuta lo de alberto
            {

                FormFormulario formFormulario = new FormFormulario(comandoAEjecutar.IDFormularioATrabajar, IDExpediente, IDDatos, tipoComando, comandoAEjecutar.getID());
                formFormulario.Show();


            }
            /* TEMPORAL
            if(comandoAEjecutar.getID() == 23){
            FormFormulario formFormulario = new FormFormulario(3);
            formFormulario.Show();
                }
                else {
                    FormFormulario formFormulario = new FormFormulario(3, 1, 2);
                    formFormulario.Show();
            
                }
             */ 
        }

        private void dataGridComandos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.buttonEjecutarComando.Enabled = true;
            
            this.comandoAEjecutar = new Comando();
            
            int IDComando = System.Int32.Parse( this.dataGridComandos[0, this.dataGridComandos.CurrentRow.Index].Value.ToString());
            comandoAEjecutar.setAtributosSegunID(IDComando);
            /*
            comandoAEjecutar.setIDExpediente(this.IDExpediente);
            //Mae alberto aquí tiene una instancia del comando a ejecutar, con todos los datos que ocupa.
            mensajeTemporal = "Aquí es donde entra en acción alberto!!!!, mae me parece que aquí puede tomar todo lo que ocupa para desplegar el form y aplicarle el comando correspondiente" + '\n' + '\n';
            mensajeTemporal += comandoAEjecutar.ToString();
             */
        }
    }
}