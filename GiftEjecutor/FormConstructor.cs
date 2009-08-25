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

            string queryString = "SELECT DISTINCT CustomerID FROM Orders";

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