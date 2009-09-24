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
        private int IDTupla;
        private int IDFormulario;
        private int IDExpediente;
        private int tipoComando;
        private int IDComando;
        private ConsultaElegirInstancia consultaBD;
        private Formulario miFormulario;

        public FormElegirInstancia(int IDForm, int IDExp, int tipoComando, int IDComando)
        {
            InitializeComponent();
            this.IDTupla = -1;
            this.IDFormulario = IDForm;
            this.IDExpediente = IDExp;
            this.tipoComando = tipoComando;
            this.IDComando = IDComando;
            this.consultaBD = new ConsultaElegirInstancia();
            this.miFormulario = new Formulario(IDFormulario);

            llenarGrid();
        }

        private void llenarGrid() {
            
            SqlDataReader datos = consultaBD.getDatosFormuario(miFormulario.getNombre(), IDExpediente);
            DataTable tabla = new DataTable();
            DataRow fila;
            DataColumn correlativo = new DataColumn();
            DataColumn nombreFormulario = new DataColumn();
            DataColumn fechaCreado = new DataColumn();

            correlativo.ColumnName = "correlativo";
            correlativo.DataType = Type.GetType("System.String");

            tabla.Columns.Add(correlativo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tabla.NewRow();
                    fila["correlativo"] = datos.GetValue(0);
                    tabla.Rows.Add(fila);
                }
            }
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
            //IDTupla = 
            this.Hide();
        }
    }
}