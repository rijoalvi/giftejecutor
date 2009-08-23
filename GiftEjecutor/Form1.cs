using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace GiftEjecutor
{
    public partial class Principal : Form
    {
        MySqlConnection mySqlConexion = new MySqlConnection("datasource=grupoingegift5.bluechiphosting.com;username=grupoin2_user;password=Qwerty123;database=grupoin2_GiftBD");
        public Principal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //string sentenciaMySql = "SELECT * FROM Funcionario;";
           // MySqlDataReader datos = hacerConsulta(sentenciaMySql);
            FlujoTrabajo flujo = new FlujoTrabajo();
            this.dataGridView1.DataSource= flujo.getDataTableTodosLosFlujosDeTrabajo();

        }
        private MySqlDataReader hacerConsulta(string sentenciaMySql)
        {

            MySqlDataReader datos = null;
            mySqlConexion.Open();
            //bool exito;
            try
            {
                //create a new mysqlconnection
                MySqlCommand comando = new MySqlCommand(sentenciaMySql, mySqlConexion);
                datos = comando.ExecuteReader();

            }
            catch (MySqlException ex)
            {
              //  exito = false;
                MessageBox.Show(ex.Message);
            }


            return datos;
        }

    }
}