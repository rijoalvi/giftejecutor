using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace GiftEjecutor
{
    public partial class FormElegirInstancia : Form
    {
        private Ventanota padreMDI;

        private int IDTupla;
        private int IDFormulario;
        private int IDExpediente;
        private int tipoComando;
        private int IDComando;
        private int IDActividad;
        private FormActividad miPadre;
        private ConsultaElegirInstancia consultaBD;
        private Formulario miFormulario;

        public FormElegirInstancia(int IDForm, int IDExp, int tipoComando, int IDComando, int IDActividad, FormActividad padre)
        {
            //cm.nombreCampoEfecto, cm.valorCampoEfecto
            InitializeComponent();
            this.IDTupla = -1;
            this.IDFormulario = IDForm;
            this.IDExpediente = IDExp;
            this.tipoComando = tipoComando;
            this.IDComando = IDComando;
            this.IDActividad = IDActividad;
            this.miPadre = padre;
            this.consultaBD = new ConsultaElegirInstancia();
            this.miFormulario = new Formulario(IDFormulario);
            llenarGrid();
        }

        private void llenarGrid() {
            
            SqlDataReader datos = consultaBD.getDatosFormuario(miFormulario.getNombre(), IDExpediente, IDFormulario);
            DataTable tabla = new DataTable();
            DataRow fila;
            DataColumn correlativo = new DataColumn();
            DataColumn nombreFormulario = new DataColumn();
            DataColumn fechaCreado = new DataColumn();


            correlativo.ColumnName = "correlativo";
            correlativo.DataType = Type.GetType("System.String");
            nombreFormulario.ColumnName = "nombreFormulario";
            nombreFormulario.DataType = Type.GetType("System.String");
            fechaCreado.ColumnName = "fechaCreado";
            fechaCreado.DataType = Type.GetType("System.String");

            tabla.Columns.Add(correlativo);
            tabla.Columns.Add(nombreFormulario);
            tabla.Columns.Add(fechaCreado);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tabla.NewRow();
                    fila["correlativo"] = datos.GetValue(0);
                    fila["nombreFormulario"] = miFormulario.getNombre();
                    fila["fechaCreado"] = datos.GetValue(1);
                    tabla.Rows.Add(fila);
                }
            }

            dataGridInstancias.DataSource = tabla;
            dataGridInstancias.Columns[0].Visible = false;
        }

        public int getIDTupla() {
            return IDTupla;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void botonEjecutar_Click(object sender, EventArgs e)
        {
            IDTupla = int.Parse(this.dataGridInstancias[0, this.dataGridInstancias.CurrentRow.Index].Value.ToString());
            if (tipoComando == 5) //Mascara
            {
                ComandoMascara cm = new ComandoMascara();
                cm.setAtributosComandoMascaraSegunID(IDComando);
                //MessageBox.Show(cm.ToString());
                ConsultaFormulario cf = new ConsultaFormulario();
                //cf.actualizarUnCampoSegunID(IDDatos, cf.getNombreFormulario(comandoAEjecutar.IDFormularioATrabajar), cm.nombreCampoEfecto, cm.valorCampoEfecto, "varchar");

                cf.actualizarUnCampoSegunID(IDTupla, miFormulario.getNombre(), cm.nombreCampoEfecto, cm.valorCampoEfecto, "varchar");

                cf.insertarEnBitacora(IDExpediente, IDActividad, IDComando, tipoComando, IDTupla, IDFormulario, true, "Se modificó el campo " + cm.nombreCampoEfecto);
                FormFormulario formFormulario = new FormFormulario(IDFormulario, IDExpediente, IDActividad, IDTupla, tipoComando, IDComando, cf.ToString(), miPadre);
                formFormulario.MdiParent = padreMDI;
                formFormulario.setPadreMDI(padreMDI);
                formFormulario.Show(); 
            }
            else //Los otros
            {                
                FormFormulario formFormulario = new FormFormulario(IDFormulario, IDExpediente, IDActividad, IDTupla, tipoComando, IDComando, "", miPadre);
                formFormulario.MdiParent = padreMDI;
                formFormulario.setPadreMDI(padreMDI);
                formFormulario.Show();                
            }
            this.Hide();
        }

        public void setPadreMDI(Ventanota v)
        {
            padreMDI = v;
        }
    }
}