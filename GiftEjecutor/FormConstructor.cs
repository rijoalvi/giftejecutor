using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class FormConstructor : Form
    {
        public FormConstructor()
        {
            InitializeComponent();
        }

        private void FormConstructor_Load(object sender, EventArgs e)
        {
            FlujoTrabajo flujo = new FlujoTrabajo();
            dataGridFlujosTrabajo.DataSource = flujo.getDataTableTodosLosFlujosDeTrabajo();
        }

           // string queryString = "SELECT DISTINCT CustomerID FROM Orders";

        private void dataGridFlujosTrabajo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         //   textBoxIDFlujoTrabajo.Text=dataGridFlujosTrabajo[0,dataGridFlujosTrabajo.sele]
        }

        private void dataGridFlujosTrabajo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  btnDetalles.Enabled = true;
            System.Windows.Forms.DataGridViewCellStyle b = new DataGridViewCellStyle();
            b.BackColor = System.Drawing.Color.White;
           // txtCanton.Text = "hola";
           // txtCanton.Text = this.dataGridView1.CurrentRow.Index.ToString();
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < dataGridFlujosTrabajo.RowCount; i++)
                {
                    this.dataGridFlujosTrabajo[j, i].Style = b;

                }
            }
            //this.dataGridView1.CurrentRow.co
            System.Windows.Forms.DataGridViewCellStyle azul = new DataGridViewCellStyle();
            azul.BackColor = System.Drawing.Color.RoyalBlue;
            azul.ForeColor = Color.White;

            for (int i = 0; i < 3; i++){
                this.dataGridFlujosTrabajo[i, this.dataGridFlujosTrabajo.CurrentRow.Index].Style = azul;
            }
            textBoxIDFlujoTrabajo.Text = this.dataGridFlujosTrabajo[0, this.dataGridFlujosTrabajo.CurrentRow.Index].Value.ToString();
        }

        private void buttonConstruir_Click(object sender, EventArgs e)
        {
            //Aqui se construyen las tablas!!!
            ConstructorTablasFormularios tmp = new ConstructorTablasFormularios();
            tmp.construirTablas(this.dataGridFlujosTrabajo[0, this.dataGridFlujosTrabajo.CurrentRow.Index].Value.ToString());
            tmp.agregarFlujoTablaFlujos((int)(this.dataGridFlujosTrabajo[0, this.dataGridFlujosTrabajo.CurrentRow.Index].Value));
        }

/*public static void ReadData(string connectionString)
{
    string queryString = "SELECT DISTINCT CustomerID FROM Orders";

    using (OdbcConnection connection = new OdbcConnection(connectionString))
    {
        OdbcCommand command = new OdbcCommand(queryString, connection);

        connection.Open();

        // Execute the DataReader and access the data.
        OdbcDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("CustomerID={0", reader[0]);
        

        // Call Close when done reading.
        reader.Close();


    }
}
}*/


    }
}